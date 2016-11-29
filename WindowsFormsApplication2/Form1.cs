using System;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        private Soldier Computer { get; set; }
        private Soldier Player { get; set; }

        public Form1()
        {
            InitializeComponent();
            
            Computer = new Soldier();
            Player = new Soldier();
            
            ResetGUI();
        }

        private void btnShoot_Click(object sender, EventArgs e)
        {
            Player.Action = Actions.Shoot;
            Computer.GenerateRandomAction();
            
            if(Computer.Action == Actions.Shotgun)
            {
                AnnounceWinner("Computer");
            }
            else if(Computer.Action == Actions.Load)
            {
                AnnounceWinner("Player");
            }
            else if(Computer.Action == Actions.Block)
            {
                Player.AmmunitionCount--;

                if(Player.AmmunitionCount == 0)
                {
                    btnShoot.Enabled = false;
                }
            }
            else if(Computer.Action == Actions.Shoot)
            {
                Player.AmmunitionCount--;
                Computer.AmmunitionCount--;
            }

            UpdateLabels();
        }

        private void UpdateLabels()
        {
            lblPlayerAction.Text = Player.Action.ToString();
            lblPlayerAmmunitionCount.Text = Player.AmmunitionCount.ToString();

            lblComputerAction.Text = Computer.Action.ToString();
            lblComputerAmmunitionCount.Text = Computer.AmmunitionCount.ToString();
        }
    
        private void ResetGUI()
        {
            lblWinner.Text = string.Empty;
            btnRestart.Enabled = false;

            lblPlayerAction.Text = "-";
            lblPlayerAmmunitionCount.Text = "-";

            lblComputerAction.Text = "-";
            lblComputerAmmunitionCount.Text = "-";

            btnShoot.Enabled = false;
            btnShotgun.Enabled = false;
            btnBlock.Enabled = true;
            btnLoad.Enabled = true;
        }

        private void AnnounceWinner(string winner)
        {
            lblWinner.Text = winner + " won the game";
            LockControls();
            btnRestart.Enabled = true;
        }

        private void LockControls()
        {
            btnShoot.Enabled = false;
            btnBlock.Enabled = false;
            btnLoad.Enabled = false;
            btnShotgun.Enabled = false;
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            Player.Action = Actions.Block;
            Computer.GenerateRandomAction();

            if (Computer.Action == Actions.Shotgun)
            {
                AnnounceWinner("Computer");
            }
            else if (Computer.Action == Actions.Load)
            {
                Computer.AmmunitionCount++;
            }
            else if (Computer.Action == Actions.Block)
            {
                
            }
            else if (Computer.Action == Actions.Shoot)
            {
                Computer.AmmunitionCount--;
            }

            UpdateLabels();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Player.Action = Actions.Load;
            Computer.GenerateRandomAction();

            if (Computer.Action == Actions.Shotgun)
            {
                AnnounceWinner("Computer");
            }
            else if (Computer.Action == Actions.Load)
            {
                Computer.AmmunitionCount++;
                Player.AmmunitionCount++;

                btnShoot.Enabled = true;
            }
            else if (Computer.Action == Actions.Block)
            {
                Player.AmmunitionCount++;
                btnShoot.Enabled = true;
            }
            else if (Computer.Action == Actions.Shoot)
            {
                AnnounceWinner("Computer");
            }

            if(Player.AmmunitionCount < 3)
            {
                btnShotgun.Enabled = false;
            }
            else
            {
                btnShotgun.Enabled = true;
            }

            UpdateLabels();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Player.Reset();
            Computer.Reset();

            ResetGUI();
        }

        private void btnShotgun_Click(object sender, EventArgs e)
        {
            Player.Action = Actions.Shotgun;
            Player.AmmunitionCount -= 3;
            Computer.GenerateRandomAction();

            AnnounceWinner("Player");

            UpdateLabels();
        }
        
    }
}
