using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Resources;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace _4_4
{
    public interface ICommand
    {
        event EventHandler CanExecuteChanged;
        void Execute(object parameter);
        bool CanExecute(object parameter);
    }

    class MainViewModel : INotifyPropertyChanged
    {
        public List<Class1> Data
        {
            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged(nameof(Data));
            }
        }
        private List<Class1> data;
        public ICommand CalcCommand;
        public RelayCommand DataCommand;

        public MainViewModel()
        {
            CalcCommand = new RelayCommand(property => calc());
        }
        void calc()
        {
            List<int> even = new List<int>();
            List<int> odd = new List<int>();
            List<Class1> _Data = new List<Class1>();
            int sum_even = 0;
            int sum_odd = 0;
            for (int i = 0; i < 12;)
            {
                if ((i + 1) % 2 == 0) odd.Add((int)Char.GetNumericValue(Barcode[i]));
                else even.Add((int)Char.GetNumericValue(Barcode[i]));
                i++;
            }

            foreach (int sign in odd)
                sum_odd += sign;

            foreach (int sign in even)
                sum_even += sign;

            int value = (sum_odd * 3) + sum_even;
            _Data.Add(new Class1
            {
                _0 = (10 - (value % 10)).ToString(),
                _1 = Barcode[11].ToString(),
                _2 = Barcode[10].ToString(),
                _3 = Barcode[9].ToString(),
                _4 = Barcode[8].ToString(),
                _5 = Barcode[7].ToString(),
                _6 = Barcode[6].ToString(),
                _7 = Barcode[5].ToString(),
                _8 = Barcode[4].ToString(),
                _9 = Barcode[3].ToString(),
                _10 = Barcode[2].ToString(),
                _11 = Barcode[1].ToString(),
                _12 = Barcode[0].ToString()

            });
            _Data.Add(new Class1
            {
                _0 = sum_odd.ToString(),
                _1 = odd[5].ToString(),
                _3 = odd[4].ToString(),
                _5 = odd[3].ToString(),
                _7 = odd[2].ToString(),
                _9 = odd[1].ToString(),
                _11 = odd[0].ToString()
            });
            _Data.Add(new Class1
            {
                _0 = sum_even.ToString(),
                _2 = even[5].ToString(),
                _4 = even[4].ToString(),
                _6 = even[3].ToString(),
                _8 = even[2].ToString(),
                _10 = even[1].ToString(),
                _12 = even[0].ToString()
            });
            Data = _Data;
        }

        public string Barcode
        {
            get
            {
                return barcode;
            }
            set
            {
                if ((value.Length < 12) || (value.Length > 13))
                {
                    MessageBox.Show("Invalid barcode", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    barcode = value;
                    OnPropertyChanged(nameof(Barcode));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        private string barcode;
    }
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
