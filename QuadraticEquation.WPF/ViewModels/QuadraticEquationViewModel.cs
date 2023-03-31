using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuadraticEquation.WPF.Commands;
using QuadraticEquation.WPF.Stores;

namespace QuadraticEquation.WPF.ViewModels
{
    public class QuadraticEquationViewModel : ViewModelBase
    {
        public QuadraticEquationListingViewModel QuadraticEquationListingViewModel { get; }
        public QuadraticEquationDetailsViewModel QuadraticEquationDetailsViewModel { get; }
        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
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
        public ICommand AddQuadraticEquationCommand { get; }
        public ICommand LoadQuadraticEquationsCommand { get; }
        public QuadraticEquationViewModel(QuadraticEquationsStore quadraticEquationsStore, SelectedQuadraticEquationStore selectedQuadraticEquationStore, ModalNavigationStore modalNavigationStore)
        {
            QuadraticEquationListingViewModel = new QuadraticEquationListingViewModel(quadraticEquationsStore, selectedQuadraticEquationStore, modalNavigationStore);
            QuadraticEquationDetailsViewModel = new QuadraticEquationDetailsViewModel(selectedQuadraticEquationStore);
            AddQuadraticEquationCommand = new OpenAddQuadraticEquationCommand(quadraticEquationsStore, modalNavigationStore);
            LoadQuadraticEquationsCommand = new LoadQuadraticEquationsCommand(this, quadraticEquationsStore);
        } 
        public static QuadraticEquationViewModel LoadViewModel(QuadraticEquationsStore quadraticEquationsStore, SelectedQuadraticEquationStore selectedQuadraticEquationStore, ModalNavigationStore modalNavigationStore)
        {
            QuadraticEquationViewModel viewModel = new QuadraticEquationViewModel(quadraticEquationsStore,selectedQuadraticEquationStore, modalNavigationStore);
            viewModel.LoadQuadraticEquationsCommand.Execute(null);
            return viewModel;
        }
    }
}
