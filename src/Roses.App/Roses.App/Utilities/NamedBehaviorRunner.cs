using System;
using System.Collections;
using System.Collections.Generic;

namespace Roses.App.Utilities
{
    public class NamedBehaviorRunner <TItem> : IEnumerable<Action<TItem>>
    {
        private readonly Action<TItem> _defaultAction;
        private readonly Dictionary<string, Action<TItem>> _namedActionsDictionary = new();

        public NamedBehaviorRunner(Action<TItem> defaultAction)
        {
            _defaultAction = defaultAction 
                             ?? throw new ArgumentException(nameof(defaultAction));
        }

        public void Add(string namedBehavior, Action<TItem> action)
        {
            if (string.IsNullOrWhiteSpace(namedBehavior))
            {
                throw new ArgumentException(nameof(namedBehavior));
            }

            _namedActionsDictionary[namedBehavior] = action ?? throw new ArgumentException(nameof(action));
        }
        public void Invoke(string namedBehavior, TItem item)
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