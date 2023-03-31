using QuadraticEquation.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation.WPF.ViewModels
{
    public class QuadraticEquationDetailsViewModel : ViewModelBase
    {
        private readonly SelectedQuadraticEquationStore _selectedQuadraticEquationStore;
        private Domain.Models.QuadraticEquation SelectedQuadraticEquation => _selectedQuadraticEquationStore.SelectedQuadraticEquation;
        public bool HasSelectedQuadraticEquation => SelectedQuadraticEquation!= null;
        public double A
        {
            get
            {
                return (SelectedQuadraticEquation?.A != null) ? SelectedQuadraticEquation.A : 1;
            }
        }
        public double B
        {
            get
            {
                return (SelectedQuadraticEquation?.B != null) ? SelectedQuadraticEquation.B : 0;
            }
        }
        public double C
        {
            get
            {
                return (SelectedQuadraticEquation?.C != null) ? SelectedQuadraticEquation.C : 0;
            }
        }


        public Domain.Models.Complex FirstAnswer => SelectedQuadraticEquation?.Answers[0];
        public Domain.Models.Complex SecondAnswer => SelectedQuadraticEquation?.Answers[1];
        public string QaudraticEquationDisplay => SelectedQuadraticEquation?.ToString();

        public QuadraticEquationDetailsViewModel(SelectedQuadraticEquationStore selectedQuadraticEquationStore)
        {
            _selectedQuadraticEquationStore = selectedQuadraticEquationStore;
            _selectedQuadraticEquationStore.SelectedQuadraticEquationChanged += SelectedQuadraticEquationStore_SelectedQuadraticEquationChanged;
        }

        protected override void Dispose()
        {
            _selectedQuadraticEquationStore.SelectedQuadraticEquationChanged -= SelectedQuadraticEquationStore_SelectedQuadraticEquationChanged;
            base.Dispose();
        }
        private void SelectedQuadraticEquationStore_SelectedQuadraticEquationChanged()
        {
            OnPropertyChanged(nameof(HasSelectedQuadraticEquation));
            OnPropertyChanged(nameof(QaudraticEquationDisplay));
            OnPropertyChanged(nameof(A));
            OnPropertyChanged(nameof(B));
            OnPropertyChanged(nameof(C));
            OnPropertyChanged(nameof(FirstAnswer));
            OnPropertyChanged(nameof(SecondAnswer));
        }
    }
}
