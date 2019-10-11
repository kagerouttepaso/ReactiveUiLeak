using System.Reactive.Disposables;
using ReactiveUI;

namespace ReactiveUiLeak
{
    public class StringViewBase : ReactiveUserControl<StringViewModel>
    {
    }

    public partial class StringView : StringViewBase
    {
        public StringView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                this.OneWayBind(ViewModel,
                    vm => vm.Value,
                    v => v._textBlock.Text)
                    .DisposeWith(d);
            });
        }
    }
}
