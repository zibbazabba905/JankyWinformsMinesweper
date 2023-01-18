using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sweeper03
{
    public class UIClass
    {
        public Form MainWindow;
        public Panel InfoPanel;
        public Panel FieldPanel;

        public UIClass()
        {
            MainWindow = new Form()
            {
                //AutoSize = true,
                Width = 330,
                Height = 390
            };
            MakeFieldPanel();
            MakeInfoPanel();
        }

        private void MakeInfoPanel()
        {


            InfoPanel = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 40
            };

            Label BombsLeft = new Label()
            {
                Text = $"{ GameData.MineCount:000}", //GameData.MineCount.ToString(),
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Top  
            };
            Button RestartButton = new Button()
            {
                Text = "Restart",
                AutoSize = true,
                Anchor = AnchorStyles.Top
                
            };
            Label Timer = new Label()
            {
                Text = $"{ GameData.TimeInSeconds:000}",  //$"D3 -> {GameData.TimeInSeconds:D3}",
                //AutoSize = true,
                Anchor = AnchorStyles.Right | AnchorStyles.Top,
                TextAlign = System.Drawing.ContentAlignment.TopRight
            };
            TextBox Test = new TextBox()
            {
                Text = "blah",
                Anchor = AnchorStyles.Right,
                Width = 20,
                Height = 20
            };


            RestartButton.Click += (o, s) => SweeperGame.RestartGame();
            InfoPanel.Controls.Add(BombsLeft);
            InfoPanel.Controls.Add(RestartButton);
            InfoPanel.Controls.Add(Timer);

            MainWindow.Controls.Add(InfoPanel);
            
        }
        private void MakeFieldPanel()
        {
            FieldPanel = new Panel()
            {
                Dock = DockStyle.Fill,
            };            
            MainWindow.Controls.Add(FieldPanel);
        }

        public void AddButton(Button button)
        {
            FieldPanel.Controls.Add(button);
        }

        public void ShowWindow()
        {
            MainWindow.ShowDialog();
        }

        public void CloseWindow()
        {
            MainWindow.Close();
        }

    }
}
