using Task_Logic.Logic.Components.Interfaces;

namespace Task_Logic.UserInterface.Components.Abstracts
{
    public abstract class Controller<T>
    {
        protected IBoardBuilder<T> BuilderToCreateBoard { get; set; }
        protected View<T> ViewToDispayBoard { get; set; }

        public Controller(View<T> viewToDispayBoard, IBoardBuilder<T> builderToCreateBoard) 
        {
            BuilderToCreateBoard = builderToCreateBoard;
            ViewToDispayBoard = viewToDispayBoard;
        }

        public abstract bool AddBoard();
        public abstract void SetBoardToBuilder(IBoardBuilder<T> boardBuilder);
        public abstract IBoard<T> BuildBoard();
        public abstract void Display();
    }
}
