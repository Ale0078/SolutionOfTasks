using System.Text;

using Task_Logic.Logic.Components.Interfaces;

namespace Task_Logic.Logic.Components
{
    public class ChessBoard<T> : IBoard<T>
    {
        private readonly ICell<T>[] cells;
        private readonly T[] valuesToSetCells;

        public int Length => ColumnCount * RowCount; // Length of the board if it is in one line
        public int ColumnCount { get; init; }
        public int RowCount { get; init; }

        public T this[int index] => cells[index].CellColor;

        public ChessBoard(int columnCount, int rowCount, params T[] valuesToCells) 
        {
            ColumnCount = columnCount;
            RowCount = rowCount;

            cells = new ICell<T>[Length];
            valuesToSetCells = valuesToCells;
        }

        public bool BuildBoard() 
        {
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            cells[i * ColumnCount + j] = new WeightCell<T>(valuesToSetCells[0]);
                        }
                        else
                        {
                            cells[i * ColumnCount + j] = new BlackCell<T>(valuesToSetCells[1]);
                        }
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            cells[i * ColumnCount + j] = new BlackCell<T>(valuesToSetCells[1]);
                        }
                        else
                        {
                            cells[i * ColumnCount + j] = new WeightCell<T>(valuesToSetCells[0]);
                        }
                    }
                }
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < cells.Length; i++)
            {
                builder.Append(cells[i].ToString());
                if ((i + 1) % ColumnCount == 0)
                {
                    builder.Append('\n');
                }
            }

            return builder.ToString();
        }
    }
}
