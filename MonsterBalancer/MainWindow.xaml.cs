using MoonMonsterConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MonsterBalancer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Builder buildRoster = new Builder();
        test secondTest = new test();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Console.Write("Player One please select your roster;" + "\n");

            Roster playerOne = buildRoster.buildRosterFromConsole(secondTest.getDataBase());
            Console.Write("Player Two please selecet your roster:" + "\n");
            Roster playerTwo = buildRoster.buildRosterFromConsole(secondTest.getDataBase());
            BattleGround firstLoop = new BattleGround(playerOne, playerTwo, secondTest.getDataBase());
            firstLoop.iterator(playerOne, playerTwo);
            

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
