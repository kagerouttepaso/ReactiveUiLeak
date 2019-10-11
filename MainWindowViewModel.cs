using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using DynamicData;
using ReactiveUI;

namespace ReactiveUiLeak
{
    public class MainWindowViewModel : ReactiveObject
    {
        public ReadOnlyCollection<StringViewModel> Collection => _collection;
        private readonly ReadOnlyObservableCollection<StringViewModel> _collection;

        public MainWindowViewModel()
        {
            Observable.Timer(dueTime: TimeSpan.Zero,
                             period: TimeSpan.FromMilliseconds(5),
                             scheduler: RxApp.TaskpoolScheduler)
                .Select(x => new StringViewModel(x.ToString()))
                .ToObservableChangeSet(limitSizeTo: 300)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out _collection)
                .DisposeMany()
                .Subscribe();
        }
    }
}
