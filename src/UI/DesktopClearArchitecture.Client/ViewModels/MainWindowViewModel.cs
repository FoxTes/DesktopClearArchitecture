namespace DesktopClearArchitecture.Client.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using DesktopClearArchitecture.Shared.ViewModels;
    using DesktopClearArchitecture.UI.Modules.Home.Views;
    using DesktopClearArchitecture.UI.Modules.Products.Views;
    using ModernWpf.Controls;
    using Prism.Regions;
    using Reactive.Bindings;
    using Shared.Constants;
    using Views;

    /// <summary>
    /// View model for <see cref="MainWindow"/>.
    /// </summary>
    public class MainWindowViewModel : NavigationViewModelBase
    {
        /// <inheritdoc />
        public MainWindowViewModel(IRegionManager regionManager)
        {
            var nameMenuItems = GetNavigationMenuItems(NavigationMenuItems)
                .Select(x => x.Content.ToString())
                .ToList();

            NavigationSearchItems = NavigationSearchText
                .Skip(1)
                .Throttle(TimeSpan.FromMilliseconds(500))
                .Select(term => term?.Trim())
                .DistinctUntilChanged()
                .Select(x => nameMenuItems
                    .Where(y => y.Contains(x, StringComparison.OrdinalIgnoreCase))
                    .ToArray())
                .ToReadOnlyReactivePropertySlim();

            NavigationMenuItemInvoked.Subscribe(args =>
                regionManager.RequestNavigate(RegionNames.MainContent, args.InvokedItemContainer.Tag.ToString()));
        }

        /// <summary>
        /// Navigation menu items.
        /// </summary>
        public static List<NavigationViewItemBase> NavigationMenuItems { get; set; } = new()
        {
            new NavigationViewItem
            {
                Content = "Home",
                Icon = new SymbolIcon(Symbol.Home),
                Tag = nameof(HomeControl)
            },
            new NavigationViewItemSeparator(),
            new NavigationViewItem
            {
                Content = "Products",
                Icon = new SymbolIcon(Symbol.AllApps),
                Tag = nameof(ProductsControl)
            },
            new NavigationViewItem
            {
                Content = "Music",
                Icon = new SymbolIcon(Symbol.MusicInfo)
            },
            new NavigationViewItem
            {
                Content = "Games",
                Icon = new SymbolIcon(Symbol.AllApps),
                MenuItemsSource = new List<NavigationViewItemBase>
                {
                    new NavigationViewItem
                    {
                        Content = "Action",
                        Icon = new SymbolIcon(Symbol.Filter),
                    },
                    new NavigationViewItem
                    {
                        Content = "RPG",
                        Icon = new SymbolIcon(Symbol.Account),
                    }
                }
            }
        };

        /// <summary>
        /// Navigation search text.
        /// </summary>
        public ReactivePropertySlim<string> NavigationSearchText { get; } = new(string.Empty);

        /// <summary>
        /// Navigation search items.
        /// </summary>
        public ReadOnlyReactivePropertySlim<string[]> NavigationSearchItems { get; }

        /// <summary>
        /// Navigation search text.
        /// </summary>
        public NavigationViewItemBase NavigationSelectedItem { get; } = NavigationMenuItems.FirstOrDefault();

        /// <summary>
        /// Navigation menu item invoked.
        /// </summary>
        public ReactiveCommand<NavigationViewItemInvokedEventArgs> NavigationMenuItemInvoked { get; } = new();

        private static IEnumerable<NavigationViewItemBase> GetNavigationMenuItems(
            IEnumerable<NavigationViewItemBase> items)
        {
            if (items == null)
                yield break;

            foreach (var item in items.OfType<NavigationViewItem>())
            {
                yield return item;

                foreach (var subItem in GetNavigationMenuItems(
                    (IEnumerable<NavigationViewItemBase>)item.MenuItemsSource))
                    yield return subItem;
            }
        }
    }
}