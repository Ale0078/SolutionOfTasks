using System;

using Task_Logic.Logic.Components.Interfaces;
using Task_Logic.UserInterface.Components.Abstracts;

namespace FirstTask.Views
{
    public class ConsoleView<T> : View<T>
    {
        public ConsoleView(ViewModels<T> viewModelsToContainBoards) : base(viewModelsToContainBoards) 
        {
        }

        public override bool Dispay()
        {
            try
            {
                foreach (IBoard<T> board in ViewModelsToContainBoards.Boards) 
                {
                    Console.WriteLine(board);
                }

                return true;
            }
            catch (Exception) 
            {
                return false;
            }
        }
    }
}
