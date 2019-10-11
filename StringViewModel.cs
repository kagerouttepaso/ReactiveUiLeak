using System;
using ReactiveUI;

namespace ReactiveUiLeak
{
    public class StringViewModel : ReactiveObject
    {
        public StringViewModel(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Value { get; }
    }
}
