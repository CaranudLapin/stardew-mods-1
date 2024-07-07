using SmartTodo.Models;
using StardewValley;

namespace SmartTodo.Components.TodoItems
{
    /// <summary>A HarvestableCropsTodoItem todo item.</summary>
    /// <remarks>Initializes a new instance of the <see cref="HarvestableCropsTodoItem"/> class.</remarks>
    /// <param name="text">The text of the todo item.</param>
    internal class HarvestableCropsTodoItem : BaseTodoItem
    {
        private readonly GameLocation Location;

        private int RemainingHarvestCount { get; set; }

        public HarvestableCropsTodoItem(GameLocation location, bool isChecked = false, Action<ITodoItem>? addToCompletedCache = null) : base("", isChecked, addToCompletedCache)
        {
            this.Location = location;
            this.RemainingHarvestCount = location.getTotalCropsReadyForHarvest();

            this.UpdateText();
        }

        public override void OnUpdateTicked()
        {
            if (!IsChecked)
            {
                var unharvestedCount = this.Location.getTotalCropsReadyForHarvest();
                if (unharvestedCount != this.RemainingHarvestCount)
                {
                    this.RemainingHarvestCount = unharvestedCount;

                    this.UpdateText();

                    if (this.RemainingHarvestCount == 0)
                    {
                        this.MarkCompleted();
                    }
                }
            }
        }

        private void UpdateText()
        {
            this.Text = $"Harvest crops ({this.Location.GetDisplayName() ?? this.Location.Name}) ({this.RemainingHarvestCount} remaining)";
        }
    }
}