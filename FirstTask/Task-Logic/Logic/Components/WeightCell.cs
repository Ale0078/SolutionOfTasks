using System;

using Task_Logic.Logic.Components.Interfaces;

namespace Task_Logic.Logic.Components
{
    public class WeightCell<T> : ICell<T>
    {
        public T Color { get; }

        public WeightCell(T cellValue) 
        {
            Color = cellValue;
        }

        public override string ToString()
        {
            return Convert.ToString(Color);
        }
    }
}
