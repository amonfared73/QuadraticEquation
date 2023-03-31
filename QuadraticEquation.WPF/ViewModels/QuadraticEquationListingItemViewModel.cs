using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuadraticEquation.WPF.Commands;
using QuadraticEquation.Domain.Models;
using QuadraticEquation.WPF.Stores;

namespace QuadraticEquation.WPF.ViewModels
{
    public class QuadraticEquationListingItemViewModel : ViewModelBase
    {
        public Domain.Models.QuadraticEquation QuadraticEquation { get; private set; }
        public double A => QuadraticEquation.A;
        public double B => QuadraticEquation.B;
        public double C => QuadraticEquation.C;
        public string QaudraticEquationDisplay => QuadraticEquation.ToString();
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        private bool _isDeleting;
        public bool IsDeleting
        {
            get
            {
                return _isDeleting;
            }
            set
            {
                _isDeleting = value;
                OnPropertyChanged(nameof(IsDeleting));
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
        public QuadraticEquationListingItemViewModel(Domain.Models.QuadraticEquation quadraticEquation, QuadraticEquationsStore quadraticEquationsStore, ModalNavigationStore modalNavigationStore)
        {
            QuadraticEquation = quadraticEquation;
            _ = QuadraticEquation.Solve();
            EditCommand = new OpenEditQuadraticEquationCommand(this, quadraticEquationsStore, modalNavigationStore);
            DeleteCommand = new DeleteQuadraticEquationCommand(this, quadraticEquationsStore);
        }

        public void Update(Domain.Models.QuadraticEquation quadraticEquation)
        {
            QuadraticEquation = quadraticEquation;
            OnPropertyChanged(nameof(A));  
            OnPropertyChanged(nameof(B));
            OnPropertyChanged(nameof(C));
            OnPropertyChanged(nameof(QaudraticEquationDisplay));
        }
    }
}
