using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuadraticEquation.WPF.Commands;
using QuadraticEquation.WPF.Stores;
using QuadraticEquation.WPF.ViewModels;

namespace QuadraticEquation.WPF.ViewModels
{
    public class AddQuadraticEquationViewModel : ViewModelBase
    {
        public QuadraticEquationDetailsFormViewModel QuadraticEquationDetailsFormViewModel { get; }

        public AddQuadraticEquationViewModel(QuadraticEquationsStore quadraticEquationsStore, ModalNavigationStore modalNavigationStore)
        {
            ICommand submitCommand = new AddQuadraticEquationCommand(this, quadraticEquationsStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            QuadraticEquationDetailsFormViewModel = new QuadraticEquationDetailsFormViewModel(submitCommand, cancelCommand);
        }
    }
}
