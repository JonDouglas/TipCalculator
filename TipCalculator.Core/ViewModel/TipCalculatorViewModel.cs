using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipCalculator.Core.Service;

namespace TipCalculator.Core.ViewModel
{
    public class TipCalculatorViewModel : ViewModelBase
    {
        //private readonly ITipCalculator _calculator;
        private int _generosity;
        private double _subTotal;
        private double _tip;

        //public TipCalculatorViewModel(ITipCalculator calculator)
        //{
        //    _calculator = calculator;
        //    _subTotal = 100;
        //    _generosity = 10;
        //    Recalcuate();

        //}

        public TipCalculatorViewModel()
        {
            _subTotal = 100;
            _generosity = 10;
            Recalcuate();
        }

        public double SubTotal
        {
            get { return _subTotal; }
            set
            {
                _subTotal = value;
                OnPropertyChanged("SubTotal");
                Recalcuate();
            }
        }

        public int Generosity
        {
            get { return _generosity; }
            set
            {
                _generosity = Limit(value);
                OnPropertyChanged("Generosity");
                Recalcuate();
            }
        }

        public double Tip
        {
            get { return _tip; }
            set
            {
                _tip = value;
                OnPropertyChanged("Tip");
            }
        }

        private int Limit(int value)
        {
            if (value < 0)
                value = 0;
            if (value > 100)
                value = 100;
            return value;
        }

        private void Recalcuate()
        {
            Tip = (Generosity * SubTotal) / 100.0;
        }
    }
}
