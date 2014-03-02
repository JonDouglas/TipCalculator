namespace TipCalculator.Core.Service
{
    public interface ITipCalculator
    {
        double TipAmount(double subTotal, int generosity);
    }
}
