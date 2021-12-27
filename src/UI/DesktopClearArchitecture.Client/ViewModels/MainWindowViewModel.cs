namespace DesktopClearArchitecture.Client.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using DesktopClearArchitecture.Shared.ViewModels;
    using DesktopClearArchitecture.UI.Modules.Games.Views;
    using DesktopClearArchitecture.UI.Modules.Home.Views;
    using DesktopClearArchitecture.UI.Modules.Music.Views;
    using DesktopClearArchitecture.UI.Modules.Products.Views;
    using DesktopClearArchitecture.UI.Modules.Settings.Views;
    using Models;
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
        private readonly IRegionManager _regionManager;

        /// <inheritdoc />
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            var navigationViewItems = GetNavigationViewItems(NavigationMenuItems)
                .ToList();
            var dataNavigationViewItems = navigationViewItems
                .Select(z => new DataNavigationView
                {
                    NameContentElement = z.Content.ToString(),
                    NameControl = z.Tag.ToString()
                })
                .ToList();

            NavigationSearchItems = NavigationSearchText
                .Skip(1)
                .Throttle(TimeSpan.FromMilliseconds(500))
                .Select(term => term?.Trim())
                .DistinctUntilChanged()
                .Select(x => dataNavigationViewItems
                    .Where(y => y.NameContentElement.Contains(x, StringComparison.OrdinalIgnoreCase))
                    .ToArray())
                .ToReadOnlyReactivePropertySlim();

            NavigationSelectedItem = NavigationMenuQuerySubmitted
                .Select(args => navigationViewItems.FirstOrDefault(x => (string)x.Content == args.QueryText))
                .ToReactiveProperty(NavigationMenuItems.FirstOrDefault());

            NavigationMenuItemInvoked.Subscribe(args =>
                MenuRequestNavigate(args.InvokedItemContainer.Tag.ToString()));

            NavigationMenuQuerySubmitted.Subscribe(args =>
                MenuRequestNavigate(((DataNavigationView)args.ChosenSuggestion).NameControl));
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
                Icon = new SymbolIcon(Symbol.MusicInfo),
                Tag = nameof(MusicControl)
            },
            new NavigationViewItem
            {
                Content = "Games",
                Icon = new SymbolIcon(Symbol.AllApps),
                Tag = nameof(GamesControl),
                MenuItemsSource = new List<NavigationViewItemBase>
                {
                    new NavigationViewItem
                    {
                        Content = "Action",
                        Icon = new SymbolIcon(Symbol.Filter),
                        Tag = nameof(GamesControl)
                    },
                    new NavigationViewItem
                    {
                        Content = "RPG",
                        Icon = new SymbolIcon(Symbol.Account),
                        Tag = nameof(GamesControl)
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
        public ReadOnlyReactivePropertySlim<DataNavigationView[]> NavigationSearchItems { get; }

        /// <summary>
        /// Navigation search text.
        /// </summary>
        public ReactiveProperty<NavigationViewItemBase> NavigationSelectedItem { get; }

        /// <summary>
        /// Navigation menu item invoked.
        /// </summary>
        public ReactiveCommand<NavigationViewItemInvokedEventArgs> NavigationMenuItemInvoked { get; } = new();

        /// <summary>
        /// Navigation menu query submitted.
        /// </summary>
        public ReactiveCommand<AutoSuggestBoxQuerySubmittedEventArgs> NavigationMenuQuerySubmitted { get; } = new();

        private static IEnumerable<NavigationViewItemBase> GetNavigationViewItems(
            IEnumerable<NavigationViewItemBase> items)
        {
            if (items == null)
                yield break;

            foreach (var item in items.OfType<NavigationViewItem>())
            {
                yield return item;

                foreach (var subItem in GetNavigationViewItems(
                    (IEnumerable<NavigationViewItemBase>)item.MenuItemsSource))
                    yield return subItem;
            }
        }

        private void MenuRequestNavigate(string nameControl, bool isSettings = false) =>
            _regionManager.RequestNavigate(RegionNames.MainContent, isSettings ? nameof(SettingsControl) : nameControl);
    }
}