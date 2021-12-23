namespace DesktopClearArchitecture.Client.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using DesktopClearArchitecture.Shared.ViewModels;
    using ModernWpf.Controls;
    using Reactive.Bindings;
    using Views;

    /// <summary>
    /// View model for <see cref="MainWindow"/>.
    /// </summary>
    public class MainWindowViewModel : NavigationViewModelBase
    {
        /// <inheritdoc />
        public MainWindowViewModel()
        {
            var nameMenuItems = GetNavigationMenuItems(NavigationMenuItems)
                .Select(x => x.Content)
                .Cast<string>()
                .ToList();

            NavigationSearchItems = NavigationSearchText
                .Skip(1)
                .Throttle(TimeSpan.FromMilliseconds(500))
                .Select(term => term?.Trim())
                .DistinctUntilChanged()
                .Do(_ => NavigationSearchItems?.ClearOnScheduler())
                .SelectMany(x => nameMenuItems.Where(y => y.Contains(x, StringComparison.OrdinalIgnoreCase)))
                .ToReactiveCollection();

            NavigationSelectedItem = NavigationMenuItems.FirstOrDefault();
        }

        /// <summary>
        /// Navigation search text.
        /// </summary>
        public ReactivePropertySlim<string> NavigationSearchText { get; } = new(string.Empty);

        /// <summary>
        /// Navigation search items.
        /// </summary>
        public ReactiveCollection<string> NavigationSearchItems { get; }

        /// <summary>
        /// Navigation menu items.
        /// </summary>
        public List<NavigationViewItemBase> NavigationMenuItems { get; set; } = new()
        {
            new NavigationViewItem
            {
                Content = "Home",
                Icon = new SymbolIcon(Symbol.Home)
            },
            new NavigationViewItemSeparator(),
            new NavigationViewItem
            {
                Content = "Products",
                Icon = new SymbolIcon(Symbol.AllApps)
            },
            new NavigationViewItem
            {
                Content = "Music",
                Icon = new SymbolIcon(Symbol.MusicInfo),
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
        public NavigationViewItemBase NavigationSelectedItem { get; }

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