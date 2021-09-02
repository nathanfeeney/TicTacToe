using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            NewGame();

        }

        #endregion

        private void NewGame()
        {
            throw new NotImplementedException();
        }
    }
}
