using System.Reactive.Disposables;
using ReactiveUI;

namespace ReactiveUiLeak
{
    public class MainWindowViewBase : ReactiveWindow<MainWindowViewModel>
    {
    }

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindowView : MainWindowViewBase
    {
        public MainWindowView()
        {
            InitializeComponent();

            ViewModel = new MainWindowViewModel();

            this.WhenActivated(d =>
            {
                this.OneWayBind(ViewModel,
                    vm => vm.Collection,
                    v => v.listBox.ItemsSource)
                    .DisposeWith(d);
            });
        }
    }
}
