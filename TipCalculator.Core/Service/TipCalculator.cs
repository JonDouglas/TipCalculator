using System;

namespace TipCalculator.Core.Service
{
    public class TipCalculator : ITipCalculator
    {
        public double TipAmount(double subTotal, int generosity)
        {
            return (generosity * subTotal) / 100.0;
        }
    }
}
