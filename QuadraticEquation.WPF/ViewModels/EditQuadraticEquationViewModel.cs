using QuadraticEquation.WPF.Commands;
using QuadraticEquation.Domain.Models;
using QuadraticEquation.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuadraticEquation.WPF.ViewModels
{
    
    public class EditQuadraticEquationViewModel : ViewModelBase
    {
        public Guid QuadraticEquationId { get; }
        public QuadraticEquationDetailsFormViewModel QuadraticEquationDetailsFormViewModel { get; }

        public EditQuadraticEquationViewModel(Domain.Models.QuadraticEquation quadraticEquation, QuadraticEquationsStore quadraticEquationsStore, ModalNavigationStore modalNavigationStore)
        {
            QuadraticEquationId = quadraticEquation.Id;
            ICommand submitCommand = new EditQuadraticEquationCommand(this, quadraticEquationsStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            QuadraticEquationDetailsFormViewModel = new QuadraticEquationDetailsFormViewModel(submitCommand, cancelCommand)
            {
                A = quadraticEquation.A,
                B = quadraticEquation.B,
                C = quadraticEquation.C
            };
        }
    }
}
