using Task_Logic.Logic.Components.Interfaces;
using Task_Logic.Logic.Components.Builders.Abstracts;

namespace Task_Logic.Logic.Components.Builders
{
    public class ChessBoardBuilder<T> : BoardBuilder<T>
    {
        public ChessBoardBuilder(int columnCount, int rowCount, T[] valuesToSetsCells)
            : base(columnCount, rowCount, valuesToSetsCells) 
        { }

        public override IBoard<T> Create() 
        {
            IBoard<T> board = new ChessBoard<T>(
                columnCount: ColumnCount,
                rowCount: RowCount,
                valuesToCells: ValuesToSetsCells);
            board.BuildBoard();

            return board;
        }
    }
}
