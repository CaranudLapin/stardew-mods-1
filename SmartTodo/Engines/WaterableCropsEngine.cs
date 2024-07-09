using SmartTodo.Components.TodoItems;
using SmartTodo.Models;
using StardewValley;

namespace SmartTodo.Engines
{
    internal class WaterableCropsEngine(
        Action<string, StardewModdingAPI.LogLevel> log,
        Func<bool> isEnabled
    ) : BaseEngine<WaterableCropsTodoItem>(log, isEnabled, UpdateFrequency.EveryTick)
    {

        private readonly IEnumerator<GameLocation?> locations = GameHelper.EndlessLocationsEnumerator();

        public override void UpdateItems()
        {
            if (!locations.MoveNext() || locations.Current is null)
            {
                // try again next time!
                return;
            }

            GameLocation thisLocation = locations.Current;

            this.Log($"Checking waterable crops in {thisLocation.Name}");

            int waterableCount = thisLocation.getTotalUnwateredCrops();
            if (waterableCount > 0)
            {
                items.Add(new WaterableCropsTodoItem(thisLocation));
            }
        }
    }
}