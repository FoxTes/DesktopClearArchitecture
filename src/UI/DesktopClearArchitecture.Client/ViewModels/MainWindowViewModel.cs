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
        private static readonly NavigationViewItemBase[] NavigationViewItems =
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

        private readonly IRegionManager _regionManager;

        /// <inheritdoc />
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            var navigationViewItems = GetNavigationViewItems(NavigationViewItems)
                .ToList();
            var dataNavigationViewItems = navigationViewItems
                .Select(z => new DataNavigationView
                {
                    NameContentElement = z.Content.ToString(),
                    NameControl = z.Tag.ToString()
                })
                .ToList();

            AutoSuggestBoxItems = AutoSuggestBoxSearchText
                .Skip(1)
                .Throttle(TimeSpan.FromMilliseconds(500))
                .Select(term => term?.Trim())
                .DistinctUntilChanged()
                .Select(x => dataNavigationViewItems
                    .Where(y => y.NameContentElement.Contains(x, StringComparison.OrdinalIgnoreCase))
                    .ToArray())
                .ToReadOnlyReactivePropertySlim();

            NavigationSelectedItem = NavigationMenuQuerySubmitted
                .DistinctUntilChanged()
                .Select(args => navigationViewItems.FirstOrDefault(x => (string)x.Content == args.QueryText))
                .ToReactiveProperty(NavigationViewItems.FirstOrDefault());

            NavigationMenuItemInvoked
                .DistinctUntilChanged()
                .Subscribe(args =>
                    MenuRequestNavigate(args.InvokedItemContainer.Tag.ToString(), args.IsSettingsInvoked));

            NavigationMenuQuerySubmitted
                .DistinctUntilChanged()
                .Subscribe(args =>
                    MenuRequestNavigate(((DataNavigationView)args.ChosenSuggestion).NameControl));

            CreateNavigationMenu
                .Subscribe(_ =>
                {
                    NavigationMenuItems.Value = NavigationViewItems
                        .OrderBy(_ => Guid.NewGuid())
                        .ToArray();
                });
        }

        /// <summary>
        /// Navigation search text.
        /// </summary>
        public ReactivePropertySlim<string> AutoSuggestBoxSearchText { get; } = new(string.Empty);

        /// <summary>
        /// Navigation search items.
        /// </summary>
        public ReadOnlyReactivePropertySlim<DataNavigationView[]> AutoSuggestBoxItems { get; }

        /// <summary>
        /// Navigation menu items.
        /// </summary>
        public ReactivePropertySlim<NavigationViewItemBase[]> NavigationMenuItems { get; } = new(NavigationViewItems);

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

        /// <summary>
        /// Create navigation menu.
        /// </summary>
        public ReactiveCommand CreateNavigationMenu { get; } = new();

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