// using SmartTodo.Models;
// using StardewValley;
// using StardewValley.SpecialOrders;

// namespace SmartTodo.Components.TodoItems
// {
//     /// <summary>A SpecialOrdersBoardTodoItem todo item.</summary>
//     /// <remarks>Initializes a new instance of the <see cref="SpecialOrdersBoardTodoItem"/> class.</remarks>
//     /// <param name="text">The text of the todo item.</param>
//     internal class SpecialOrdersBoardTodoItem : BaseTodoItem
//     {

//         public SpecialOrderType Type { get; }

//         public SpecialOrdersBoardTodoItem(
//         SpecialOrderType type,
//         bool isChecked = false,
//         Action<ITodoItem>? addToCompletedCache = null
//     ) : base(
//         "",
//         isChecked,
//         11,
//         addToCompletedCache
//     )
//         {
//             this.Type = type;

//             string locationText = type switch
//             {
//                 SpecialOrderType.Standard => "in town",
//                 SpecialOrderType.Qi => "in Mr. Qi's Walnut Room",
//                 _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
//             };

//             this.Text = $"Check the special orders board {locationText}";
//         }

//         public override void OnUpdateTicked()
//         {
//             if (!IsChecked)
//             {
//                 SpecialOrder leftOrder = Game1.player.team.GetAvailableSpecialOrder(0, Type.ToStardewSpecialOrderTypeString());
//                 SpecialOrder rightOrder = Game1.player.team.GetAvailableSpecialOrder(1, Type.ToStardewSpecialOrderTypeString());

//                 bool noOrderIsAvailable = leftOrder is null && rightOrder is null;
//                 bool alreadyAcceptedOrder = Game1.player.team.acceptedSpecialOrderTypes.Contains(Type.ToStardewSpecialOrderTypeString());

//                 if (noOrderIsAvailable || alreadyAcceptedOrder)
//                 {
//                     this.MarkCompleted();
//                 }
//             }
//         }
//     }
// }