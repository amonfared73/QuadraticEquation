using Microsoft.EntityFrameworkCore;
using QuadraticEquation.Domain.Commands;
using QuadraticEquation.Domain.Queries;
using QuadraticEquation.EntityFramework;
using QuadraticEquation.EntityFramework.Commands;
using QuadraticEquation.EntityFramework.Queries;
using QuadraticEquation.WPF.Stores;
using QuadraticEquation.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace QuadraticEquation.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 02:39
    public partial class App : Application
    {
        private readonly SelectedQuadraticEquationStore _selectedQuadraticEquationStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly QuadraticEquationsStore _quadraticEquationsStore;

        private readonly QuadraticEquationDbContextFactory _quadraticEquationDbContextFactory;

        private readonly IGetAllQuadraticEquationsQuery _getAllQuadraticEquationsQuery;
        private readonly ICreateQuadraticEquationCommand _createQuadraticEquationCommand;
        private readonly IUpdateQuadraticEquationCommand _updateQuadraticEquationCommand;
        private readonly IDeleteQuadraticEquationCommand _deleteQuadraticEquationCommand;

        public App()
        {
            string connectionString = "Data Source=QuadraticEquations.db";
            _quadraticEquationDbContextFactory = new QuadraticEquationDbContextFactory(new DbContextOptionsBuilder().UseSqlite(connectionString).Options);

            _getAllQuadraticEquationsQuery = new GetAllQuadraticEquationsQuery(_quadraticEquationDbContextFactory);
            _createQuadraticEquationCommand = new CreateQuadraticEquationCommand(_quadraticEquationDbContextFactory);
            _updateQuadraticEquationCommand = new UpdateQuadraticEquationCommand(_quadraticEquationDbContextFactory);
            _deleteQuadraticEquationCommand = new DeleteQuadraticEquationCommand(_quadraticEquationDbContextFactory);

            _quadraticEquationsStore = new QuadraticEquationsStore(_getAllQuadraticEquationsQuery, _createQuadraticEquationCommand,_updateQuadraticEquationCommand,_deleteQuadraticEquationCommand);
            _selectedQuadraticEquationStore = new SelectedQuadraticEquationStore(_quadraticEquationsStore);
            _modalNavigationStore = new ModalNavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            using (QuadraticEquationDbContext context = _quadraticEquationDbContextFactory.Create())
            {
                context.Database.Migrate();
            }
            
            QuadraticEquationViewModel quadraticEquationViewModel =  QuadraticEquationViewModel.LoadViewModel(_quadraticEquationsStore, _selectedQuadraticEquationStore, _modalNavigationStore);
            
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modalNavigationStore, quadraticEquationViewModel)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
