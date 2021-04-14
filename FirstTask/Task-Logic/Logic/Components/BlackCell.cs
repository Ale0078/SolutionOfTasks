using System;

using Task_Logic.Logic.Components.Interfaces;

namespace Task_Logic.Logic.Components 
{
    internal class BlackCell<T> : ICell<T>
    {
        public T Color { get; }

        public BlackCell(T cellValue) 
        {
            Color = cellValue;
        }

        public override string ToString()
        {
            return Convert.ToString(Color);
        }
    }
}
