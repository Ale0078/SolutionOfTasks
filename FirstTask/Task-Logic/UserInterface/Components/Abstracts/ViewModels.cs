using System.Collections.Generic;

using Task_Logic.Logic.Components.Interfaces;

namespace Task_Logic.UserInterface.Components.Abstracts
{
    public abstract class ViewModels<T>
    {
        public List<IBoard<T>> Boards { get; }

        public ViewModels() 
        {
            Boards = new List<IBoard<T>>();
        }

        public abstract bool AddBoard(IBoard<T> board);
    }
}
