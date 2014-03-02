using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using TipCalculator.Core.ViewModel;

namespace TipCalculator.Droid
{
    [Activity(Label = "TipCalculator.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class TipActivity : Activity
    {
        TextView subTotalTextView;
        public TextView generosityTextView;
        TextView tipToLeaveTextView;
        public TextView tipTextView;
        SeekBar generositySeekBar;
        EditText subTotalEditText;

        private TipCalculatorViewModel viewModel;

        public TipCalculatorViewModel ViewModel
        {
            get { return viewModel ?? (viewModel = new TipCalculatorViewModel()); }
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            subTotalTextView = FindViewById<TextView>(Resource.Id.lblSubTotal);
            generosityTextView = FindViewById<TextView>(Resource.Id.lblGenerosity);
            tipToLeaveTextView = FindViewById<TextView>(Resource.Id.lblTipToLeave);
            tipTextView = FindViewById<TextView>(Resource.Id.lblTip);
            generositySeekBar = FindViewById<SeekBar>(Resource.Id.seekGenerosityProgress);
            subTotalEditText = FindViewById<EditText>(Resource.Id.txtSubTotal);

            generositySeekBar.SetOnSeekBarChangeListener(new SeekBarChangeListener(this));
            subTotalEditText.AfterTextChanged += (sender, e) =>
            {
                double value = 0;
                try
                {
                    value = Double.Parse(subTotalEditText.Text.ToString());
                }
                catch (Exception)
                {
                    value = 0;
                    throw;
                }
                ViewModel.SubTotal = value;
                tipTextView.Text = ViewModel.Tip.ToString();
            };
        }
    }

    public class SeekBarChangeListener : Java.Lang.Object, SeekBar.IOnSeekBarChangeListener
    {
        TipActivity context;

        public SeekBarChangeListener(TipActivity context)
        {
            this.context = context;
        }

        public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
        {
            context.generosityTextView.Text = progress.ToString();
            context.ViewModel.Generosity = progress;
            context.tipTextView.Text = context.ViewModel.Tip.ToString();
        }

        public void OnStartTrackingTouch(SeekBar seekBar)
        {
        }

        public void OnStopTrackingTouch(SeekBar seekBar)
        {
        }
    }
}

