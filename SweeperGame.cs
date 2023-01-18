using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
namespace Sweeper03
{
    public class SweeperGame
    {
        public static UIClass UIClass = new UIClass();
        public static GameData GameData = new GameData(10, 10);
        static void Main()
        {
            StartGame();
        }

        public static void StartGame()
        {
            UIClass.ShowWindow();
        }
        public static void RestartGame()
        {
            //some way of restarting this I'm tired now
            //UIClass = new UIClass();
            //GameData = new GameData(10,10);
        }

    }
}
