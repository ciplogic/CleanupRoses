using System;
using Roses.App.Entities;

namespace Roses.App.Controllers.Common
{
    public class QualityItemDailyChangeState : IItemDailyChangeState
    {
        private readonly Func<Item, int> _earlyChanges;
        private readonly Func<Item, int> _lateChanges;

        public QualityItemDailyChangeState(Func<Item, int> earlyChanges, Func<Item, int> lateChanges)
        {
            _earlyChanges = earlyChanges;
            _lateChanges = lateChanges;
        }

        public void ApplyEarlyChanges(Item item)
        {
            item.Quality = _earlyChanges(item);
        }

        public void ApplyLateChanges(Item item)
        {
            item.Quality = _lateChanges(item);
        }
    }
}