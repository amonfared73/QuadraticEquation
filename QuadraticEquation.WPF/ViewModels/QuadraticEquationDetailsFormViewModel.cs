using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuadraticEquation.WPF.ViewModels
{
    public class QuadraticEquationDetailsFormViewModel : ViewModelBase
    {
        private double _a, _b, _c;
        public double A
        {
            get
            {
                return _a;
            }
            set
            {
                _a = value;
                OnPropertyChanged(nameof(A));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }
        public double B
        {
            get
            {
                return _b;
            }
            set
            {
                _b = value;
                OnPropertyChanged(nameof(B));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }
        public double C
        {
            get
            {
                return _c;
            }
            set
            {
                _c = value;
                OnPropertyChanged(nameof(C));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }
        public bool CanSubmit
        {
            get
            {
                return A != 0.0 || string.IsNullOrEmpty(A.ToString()) || string.IsNullOrEmpty(B.ToString()) || string.IsNullOrEmpty(C.ToString());
            }
        }
        private bool _isSubmitting;
        public bool IsSubmitting
        {
            get
            {
                return _isSubmitting;
            }
            set
            {
                _isSubmitting = value;
                OnPropertyChanged(nameof(IsSubmitting));
            }
        }
        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }
        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);
        public QuadraticEquationDetailsFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }

    }
}
