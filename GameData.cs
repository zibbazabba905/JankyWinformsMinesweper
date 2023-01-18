using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sweeper03
{
    public class GameData
    {
        public Cell[,] CellArray { get; set; }

        public static int GridWidth { get; set; } = 10;
        public static int GridHeight { get; set; } = 10;

        public List<Cell> RemainingCells = new List<Cell>();
        public List<Cell> MinedCells;


        public static int MineCount { get; set; } = 10;
        public static int TimeInSeconds { get; set; } = 000;


        public GameData(int inXsize, int inYsize)
        {
            GridWidth = inXsize;
            GridHeight = inYsize;
            CellArray = BuildArray(GridWidth, GridHeight);
            MinedCells = SetMines(MineCount);
        }
        private Cell[,] BuildArray(int GridWidth, int GridHeight)
        {
            @Cell[,] localCell = new Cell[GridWidth,GridHeight];

            for (int x = 0; x < GridHeight; x++)
            {
                for (int y = 0; y < GridWidth; y++)
                {
                    int posX = x * 30;
                    int posY = y * 30;
                    localCell[x, y] = new Cell(y, x, localCell);
                    localCell[x, y].button.Location = new System.Drawing.Point(posX, posY);
                    RemainingCells.Add(localCell[x, y]);
                    SweeperGame.UIClass.AddButton(localCell[x, y].button);
                }
            }
            return localCell;
        }
        private List<Cell> SetMines(int MineCount)
        {
            List<Cell> localMinedCells = new List<Cell>();

            //random generator problem. fixed.
            Random randomNumber = new Random();
            for (int i = 0; i < MineCount; i++)
            {
                Cell SetCell = RemainingCells[randomNumber.Next(0, RemainingCells.Count)];
                SetCell.IsBomb = true;
                RemoveCellFromFullList(SetCell);
            }
            return localMinedCells;
        }

        public void RemoveCellFromFullList(Cell cell)
        {
            RemainingCells.Remove(cell);
            WinCheck();
        }
        private void WinCheck()
        {
            if (RemainingCells.Count > 0)
                return;
            MessageBox.Show("Win");
        }
    }
}
