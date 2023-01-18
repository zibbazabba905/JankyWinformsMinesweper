using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sweeper03
{
    public class Cell
    {
        public static int WIDTH = 30;
        public static int HEIGHT = 30;

        public int KeyNubmer { get; set; }
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public bool IsBomb { get; set; }
        public bool IsFlag { get; set; }
        public bool Visited { get; set; }

        private Cell[,] ParentGrid;

        public Button button = new Button();
        //list of neighbors
        public Cell(int inYpos, int inXpos, Cell[,] inParent)
        {

            button = new Button()
            {
                Width = WIDTH,
                Height = HEIGHT,
                //Text = $"{inXpos}:{inYpos}",
            };
            
            //FIX button.MouseUp
            button.Click += (o, s) =>
            {
                RevealCell();
            };
            ParentGrid = inParent;
            Xpos = inXpos;
            Ypos = inYpos;
        }
        public override string ToString()
        {
            return $"Cell: {Xpos}:{Ypos} " + base.ToString();
        }
        public void RevealCell()
        {
            Visited = true;
            SweeperGame.GameData.RemoveCellFromFullList(this);

            if (IsBomb)
            {
                button.BackColor = System.Drawing.Color.Red;
                MessageBox.Show("Boom");
                return;
            }
            button.BackColor = System.Drawing.Color.DarkGray;

            int bombCount = 0;
            foreach (Cell cell in Neighbors())
            {
                if (!cell.IsBomb)
                    continue;
                bombCount++;
            }

            if (!(bombCount == 0))
            {
                button.Text = $"{bombCount}";
                return;
            }
            //FIX Neighbors.foreach()
            CallNeighbors();
        }
        List<Cell> Neighbors()
        {
            List<Cell> localList = new List<Cell>();

            for (int y = Ypos -1; y < Ypos +2; y++)
            {
                if (y < 0 || y > ParentGrid.GetLength(0) -1)
                    continue;
                for (int x = Xpos - 1; x < Xpos + 2; x++)
                {
                    if (x < 0 || x > ParentGrid.GetLength(1) - 1)
                        continue;
                    //FIX make compare function?
                    if (!(ParentGrid[x, y] == this))
                    localList.Add(ParentGrid[x, y]);
                }
            }
            return localList;
        }
        private void CallNeighbors()
        {
            foreach (Cell cell in Neighbors())
            {
                if (!cell.Visited)
                    cell.RevealCell();
            }
        }
    }
}
