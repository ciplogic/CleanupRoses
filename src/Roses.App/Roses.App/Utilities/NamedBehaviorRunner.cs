using System;
using System.Collections;
using System.Collections.Generic;

namespace Roses.App.Utilities
{
    public class NamedBehaviorRunner<TKey, TItem> : IEnumerable<Action<TItem>>
        where TKey : notnull
    {
        private readonly Action<TItem> _defaultAction;
        private readonly Dictionary<TKey, Action<TItem>> _namedActionsDictionary = new();

        public NamedBehaviorRunner(Action<TItem> defaultAction)
        {
            _defaultAction = defaultAction
                             ?? throw new ArgumentException(nameof(defaultAction));
        }

        public void Add(TKey namedBehavior, Action<TItem> action)
        {
            _namedActionsDictionary[namedBehavior] = action ?? throw new ArgumentException(nameof(action));
        }

        public void Invoke(TKey namedBehavior, TItem item)
        {
            if (_namedActionsDictionary.TryGetValue(namedBehavior, out Action<TItem>? behaviorForNameAction))
            {
                behaviorForNameAction(item);
            }
            else
            {
                _defaultAction(item);
            }
        }

        public IEnumerator<Action<TItem>> GetEnumerator()
            => _namedActionsDictionary.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
