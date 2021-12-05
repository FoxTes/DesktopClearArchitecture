namespace DesktopClearArchitecture.Client.Views
{
    using ReactiveUI;

    /// <inheritdoc cref="System.Windows.Window" />
    public partial class MainWindow
    {
        /// <inheritdoc />
        public MainWindow()
        {
            InitializeComponent();

            this.WhenActivated(_ =>
            {
                this.BindCommand(ViewModel!, vm => vm.Quit, view => view.LoginBtn);
            });
        }
    }
}