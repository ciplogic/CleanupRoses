using Roses.App.Entities;

namespace Roses.App.Controllers.Common
{
    public interface IItemDailyChangeState
    {
        void ApplyEarlyChanges(Item item);
        void ApplyLateChanges(Item item);
    }
}