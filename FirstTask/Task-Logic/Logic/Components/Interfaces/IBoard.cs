namespace Task_Logic.Logic.Components.Interfaces
{
    public interface IBoard<T>
    {
        int ColumnCount { get; init; }
        int RowCount { get; init; }
        int Length { get; }// Length of the board if it is in one line

        T this[int index] { get; }
        bool BuildBoard();
    }
}
