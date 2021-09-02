using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members

        /// <summary>
        /// hold the current results of cells in the active game
        /// </summary>
        private MarkType[] nResults;

        /// <summary>
        /// true if it is player 1's (X) turn or player 2's turn (O)
        /// </summary>
        private bool nPlayerTurn;

        /// <summary>
        /// The game has ended
        /// </summary>
        private bool nGameEnded;


        #endregion
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
        /// <summary>
        /// Start a new game and clears all values
        /// </summary>
        private void NewGame()
        {
            // create a new blank array of free cells
            nResults = new MarkType[9];

            for (var i = 0; i < nResults.Length; i++)
                nResults[i] = MarkType.Free;

            // Make sure player1 starts the game
            nPlayerTurn = true;

            //Interate every button on the grid..
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                // Change background, foreground and content to default values
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            // Make sure the game hasnt finshed
            nGameEnded = false;
        }

        /// <summary>
        /// handles a button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // start new game on the click after it finished
            if (nGameEnded)
            {
                NewGame();
                return;
            }

            // Cast the sender to a button
            var button = (Button)sender;

            // Find the index of button
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            // Dont do anything if cell is occupied
            if (nResults[index] != MarkType.Free)
                return;

            //set the cell value based on which players turn it is
            nResults[index] = nPlayerTurn ? MarkType.Cross : MarkType.Nought;

            button.Content = nPlayerTurn ? "X" : "O";

            if (!nPlayerTurn)
                button.Foreground = Brushes.Red;

            // bitwise operator : used to invert value
            nPlayerTurn ^= true;

        }
    }
}
