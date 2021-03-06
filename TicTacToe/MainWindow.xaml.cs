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

            //check for a winner
            checkForWinner();
        }

        /// <summary>
        /// check if there is 3 in a row
        /// </summary>
        private void checkForWinner()
        {
            #region horizontal wins
            // Check horrizontal
            // Row 0
            if(nResults[0] != MarkType.Free && (nResults[0] & nResults[1] & nResults[2]) == nResults[0])
            {
                //game ends
                nGameEnded = true;

                // Highlighted winning cells in green
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
                Button0_0.Foreground = Button1_0.Foreground = Button2_0.Foreground = Brushes.White;
            }
            // Row 1
            if (nResults[3] != MarkType.Free && (nResults[3] & nResults[4] & nResults[5]) == nResults[3])
            {
                //game ends
                nGameEnded = true;

                // Highlighted winning cells in green
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
                Button0_1.Foreground = Button1_1.Foreground = Button2_1.Foreground = Brushes.White;
            }
            // Row 2
            if (nResults[6] != MarkType.Free && (nResults[6] & nResults[7] & nResults[8]) == nResults[6])
            {
                //game ends
                nGameEnded = true;

                // Highlighted winning cells in green
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
                Button0_2.Foreground = Button1_2.Foreground = Button2_2.Foreground = Brushes.White;
            }
            #endregion

            #region vertical wins
            // Check Verical
            // Column 0
            if (nResults[0] != MarkType.Free && (nResults[0] & nResults[3] & nResults[6]) == nResults[0])
            {
                //game ends
                nGameEnded = true;

                // Highlighted winning cells in green
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
                Button0_0.Foreground = Button0_1.Foreground = Button0_2.Foreground = Brushes.White;
            }
            // Column 1
            if (nResults[1] != MarkType.Free && (nResults[1] & nResults[4] & nResults[7]) == nResults[1])
            {
                //game ends
                nGameEnded = true;

                // Highlighted winning cells in green
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
                Button1_0.Foreground = Button1_1.Foreground = Button1_2.Foreground = Brushes.White;
            }
            // Column 2
            if (nResults[2] != MarkType.Free && (nResults[2] & nResults[5] & nResults[8]) == nResults[2])
            {
                //game ends
                nGameEnded = true;

                // Highlighted winning cells in green
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
                Button2_0.Foreground = Button2_1.Foreground = Button2_2.Foreground = Brushes.White;
            }
            #endregion

            #region diagonal wins
            if (nResults[0] != MarkType.Free && (nResults[0] & nResults[4] & nResults[8]) == nResults[0])
            {
                //game ends
                nGameEnded = true;

                // Highlighted winning cells in green
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
                Button0_0.Foreground = Button1_1.Foreground = Button2_2.Foreground = Brushes.White;
            }
            if (nResults[2] != MarkType.Free && (nResults[2] & nResults[4] & nResults[6]) == nResults[2])
            {
                //game ends
                nGameEnded = true;

                // Highlighted winning cells in green
                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.Green;
                Button2_0.Foreground = Button1_1.Foreground = Button0_2.Foreground = Brushes.White;
            }
            #endregion


            //no more cells left
            if (!nResults.Any(result => result == MarkType.Free))
            {
                nGameEnded = true;

                // turn all cells orange
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Orange;  
                });
            }
        }
    }
}
