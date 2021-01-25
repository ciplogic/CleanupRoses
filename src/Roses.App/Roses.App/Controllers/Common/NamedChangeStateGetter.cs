using System;
using System.Collections;
using System.Collections.Generic;
using Roses.App.Entities;

namespace Roses.App.Controllers.Common
{
    public class NamedChangeStateGetter : IEnumerable<IItemDailyChangeState>
    {
        private readonly IItemDailyChangeState _defaultAction;
        private readonly Dictionary<ItemCategoryEnum, IItemDailyChangeState> _namedActionsDictionary = new();

        public NamedChangeStateGetter(IItemDailyChangeState defaultAction)
        {
            _defaultAction = defaultAction;
        }

        public static QualityItemDailyChangeState Build(Func<Item, int> earlyChanges, Func<Item, int> lateChanges)
        {
            return new(earlyChanges, lateChanges);
        }

        public void Add(ItemCategoryEnum namedBehavior, Func<Item, int> earlyChanges, Func<Item, int> lateChanges)
        {
            _namedActionsDictionary[namedBehavior] = Build(earlyChanges, lateChanges);
        }

        public IItemDailyChangeState Get(ItemCategoryEnum namedBehavior)
        {
            if (_namedActionsDictionary.TryGetValue(namedBehavior, out IItemDailyChangeState? behaviorForNameAction))
            {
                return behaviorForNameAction;
            }

            return _defaultAction;
        }

        public IEnumerator<IItemDailyChangeState> GetEnumerator()
            => _namedActionsDictionary.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}