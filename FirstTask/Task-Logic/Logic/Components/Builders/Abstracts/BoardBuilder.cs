using Task_Logic.Logic.Components.Interfaces;

namespace Task_Logic.Logic.Components.Builders.Abstracts
{
    public abstract class BoardBuilder<T> : IBoardBuilder<T>
    {
        public int ColumnCount { get; }
        public int RowCount { get; }
        public T[] ValuesToSetsCells { get; }

        public BoardBuilder(int columnCount, int rowCount, params T[] valuesToSetsCells) 
        {
            ColumnCount = columnCount;
            RowCount = rowCount;
            ValuesToSetsCells = valuesToSetsCells;
        }

        public abstract IBoard<T> Create();
    }
}
