namespace Task_Logic.UserInterface.Components.Abstracts
{
    public abstract class View<T>
    {
        public ViewModels<T> ViewModelsToContainBoards { get; set; }

        public View(ViewModels<T> viewModelsToContainsBoards) 
        {
            ViewModelsToContainBoards = viewModelsToContainsBoards;
        }

        public abstract bool Dispay();
    }
}
