using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuadraticEquation.WPF.Stores;
using QuadraticEquation.WPF.Commands;

namespace QuadraticEquation.WPF.ViewModels
{
    public class QuadraticEquationListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<QuadraticEquationListingItemViewModel> _quadraticEquationListingItemViewModels;
        private readonly QuadraticEquationsStore _quadraticEquationsStore;
        private readonly SelectedQuadraticEquationStore _selectedQuadraticEquationStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private QuadraticEquationListingItemViewModel _selectedQuadraticEquationListingItemViewModel;
        public QuadraticEquationListingItemViewModel SelectedQuadraticEquationListingItemViewModel
        {
            get
            {
                return _selectedQuadraticEquationListingItemViewModel;
            }
            set
            {
                _selectedQuadraticEquationListingItemViewModel = value;
                _selectedQuadraticEquationStore.SelectedQuadraticEquation = _selectedQuadraticEquationListingItemViewModel?.QuadraticEquation;
                OnPropertyChanged(nameof(SelectedQuadraticEquationListingItemViewModel));
            }
        }
        public IEnumerable<QuadraticEquationListingItemViewModel> QuadraticEquationListingItemViewModels => _quadraticEquationListingItemViewModels;
        public QuadraticEquationListingViewModel(QuadraticEquationsStore quadraticEquationsStore, SelectedQuadraticEquationStore selectedQuadraticEquationStore, ModalNavigationStore modalNavigationStore)
        {
            _quadraticEquationsStore = quadraticEquationsStore;
            _selectedQuadraticEquationStore = selectedQuadraticEquationStore;
            _modalNavigationStore = modalNavigationStore;
            _quadraticEquationListingItemViewModels = new ObservableCollection<QuadraticEquationListingItemViewModel>();

            _quadraticEquationsStore.QuadraticEquationLoaded += QuadraticEquationsStore_QuadraticEquationLoaded;
            _quadraticEquationsStore.QuadraticEquationAdded += QuadraticEquationsStore_QuadraticEquationAdded;
            _quadraticEquationsStore.QuadraticEquationUpdated += QuadraticEquationsStore_QuadraticEquationUpdated;
            _quadraticEquationsStore.QuadraticEquationDeleted += QuadraticEquationsStore_QuadraticEquationDeleted;
        }

        private void QuadraticEquationsStore_QuadraticEquationLoaded()
        {
            _quadraticEquationListingItemViewModels.Clear();
            foreach (Domain.Models.QuadraticEquation quadraticEquation in _quadraticEquationsStore.QuadraticEquations)
            {
                AddQuadraticEquation(quadraticEquation);
            }
        }

        private void QuadraticEquationsStore_QuadraticEquationDeleted(Guid id)
        {
            QuadraticEquationListingItemViewModel itemViewModel = _quadraticEquationListingItemViewModels.FirstOrDefault(y => y.QuadraticEquation.Id == id);
            if (itemViewModel != null)
            {
                _quadraticEquationListingItemViewModels.Remove(itemViewModel);
            }
        }
        private void QuadraticEquationsStore_QuadraticEquationUpdated(Domain.Models.QuadraticEquation quadraticEquation)
        {
            QuadraticEquationListingItemViewModel? quadraticEquationViewModel = _quadraticEquationListingItemViewModels.FirstOrDefault(y => y.QuadraticEquation.Id == quadraticEquation.Id);
            if (quadraticEquationViewModel != null)
            {
                quadraticEquationViewModel.Update(quadraticEquation);
            } 
        }
        private void QuadraticEquationsStore_QuadraticEquationAdded(Domain.Models.QuadraticEquation quadraticEquation)
        {
            AddQuadraticEquation(quadraticEquation);
        }
        protected override void Dispose()
        {
            _quadraticEquationsStore.QuadraticEquationLoaded -= QuadraticEquationsStore_QuadraticEquationLoaded;
            _quadraticEquationsStore.QuadraticEquationAdded -= QuadraticEquationsStore_QuadraticEquationAdded;
            _quadraticEquationsStore.QuadraticEquationUpdated -= QuadraticEquationsStore_QuadraticEquationUpdated;
            _quadraticEquationsStore.QuadraticEquationDeleted -= QuadraticEquationsStore_QuadraticEquationDeleted;
            base.Dispose();
        }
        private void AddQuadraticEquation(Domain.Models.QuadraticEquation quadraticEquation)
        {
            QuadraticEquationListingItemViewModel itemViewModel = new QuadraticEquationListingItemViewModel(quadraticEquation, _quadraticEquationsStore, _modalNavigationStore);
            _quadraticEquationListingItemViewModels.Add(itemViewModel);
        }
        
    }
}
