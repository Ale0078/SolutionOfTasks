using System;

using Task_Logic.Logic.Components.Interfaces;
using Task_Logic.UserInterface.Components.Abstracts;

namespace FirstTask.ViewModels
{
    public class ConsoleViewModel<T> : ViewModels<T>
    {
        public ConsoleViewModel() : base() 
        {        
        }

        public override bool AddBoard(IBoard<T> board)
        {
            try
            {
                Boards.Add(board);

                return true;
            }
            catch (NullReferenceException) 
            {
                return false;
            }
        }
    }
}
