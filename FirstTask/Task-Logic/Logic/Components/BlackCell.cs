using System;

using Task_Logic.Logic.Components.Interfaces;

namespace Task_Logic.Logic.Components 
{
    public class BlackCell<T> : ICell<T>
    {
        public T CellColor { get; }

        public BlackCell(T cellValue) 
        {
            CellColor = cellValue;
        }

        public override string ToString()
        {
            return Convert.ToString(CellColor);
        }
    }
}
