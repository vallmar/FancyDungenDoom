using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DungeonsOfDoom;

namespace Fancy_Dungeons_Of_Doom
{
    public partial class FormFight : Form
    {
        static FormFight form;
        public FormFight()
        {
            InitializeComponent();
        }

        public void FormFight_Load(object sender, EventArgs e)
        {
           pictureBoxPlayer.Image= Image.FromFile(@"C:\Users\Administrator\Source\Repos\FancyDungenDoom\Fancy_Dungeons_Of_Doom\Image\PlayerIkon small.png");
        }

        internal Character GameFightMonster(Character monster, Player player)
        {
            
            lblAttack.Text = player.AttackStrength.ToString();
            lblHealth.Text = player.Health.ToString();
            lblHealthOpp.Text = monster.Health.ToString();
            lblAttackOpp.Text = monster.AttackStrength.ToString();
            pictureBoxPlayer.BackgroundImage = Image.FromFile(@"C:\Users\Administrator\Source\Repos\FancyDungenDoom\Fancy_Dungeons_Of_Doom\Image\PlayerIkon.png");
            this.Show();
            do
            {
                player.Fight(monster);
                if (monster.Health <= 0)
                {
                    player.Backpack.Add(monster);
                    foreach (var item in monster.Backpack)
                    {
                        player.Backpack.Add(item);
                    }
                }
                monster.Fight(player);
                if (player.Health <= 0)
                    MessageBox.Show("You Lost");
                this.Close();
                    
            }
            while (player.Health > 0 && monster.Health > 0);

            return monster;
        }

        private void btnRound_Click(object sender, EventArgs e)
        {
            form.Close();
        }
    }
}
