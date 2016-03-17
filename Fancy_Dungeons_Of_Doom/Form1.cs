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
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace Fancy_Dungeons_Of_Doom
{
    public partial class Form1 : Form
    {
        const int WorldWidth = 20;
        const int WorldHeight = 10;
        public Player player;
        public static bool drive;
        private Client myClient;

        GameButton[,] world;
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            Label.CheckForIllegalCrossThreadCalls = false;
            //player = new Player("Jesus", 200, 40);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreatePlayer();

            //Kör enbart om man är förste spelare in.
            //CreateGameField();
            //CreateObjects();
            DisplayObjects();
        }

        public void CreateGameField()
        {
            world = new GameButton[WorldWidth, WorldHeight];
            for (int i = 0; i < WorldWidth; i++)
            {
                for (int j = 0; j < WorldHeight; j++)
                {
                    GameButton newBtn = new GameButton();
                    // Sätt koordinater
                    world[i, j] = newBtn;
                    newBtn.X = i;
                    newBtn.Y = j;
                    // Sätt ut knappen rätt i Forms
                    newBtn.Location = new System.Drawing.Point(55 * i, 55 * j);
                    // Ge den ett “unikt” namn
                    newBtn.Name = "btn" + i + j;
                    // Storlek på knappen
                    newBtn.Size = new System.Drawing.Size(55, 55);
                    newBtn.TabIndex = 0;
                    newBtn.Margin = Padding.Empty;
                    newBtn.FlatStyle = FlatStyle.Flat;
                    newBtn.FlatAppearance.BorderSize = 0;

                    newBtn.BackColor = Color.Green;
                    // Sätt samma event för alla knappar
                    if (newBtn.X == player.X && newBtn.Y == player.Y)
                    {
                        newBtn.Image = Image.FromFile(@"C:\Users\Administrator\Documents\Visual Studio 2015\Projects\Fancy_Dungeons_Of_Doom\Fancy_Dungeons_Of_Doom\Image\PlayerIkon small.png");
                    }

                    // Lägg till knappen I Forms
                    this.gamePanel.Controls.Add(newBtn);
                   
                }
            }
        }

        public void CreateObjects()
        {
            //Placera ut mur och drake
            world[18, 9].MonsterInRoom = new Dragon("Golden Dragon", 1000, 200);
            world[18, 8].Block = true;
            world[19, 8].Block = true;

            //Placera ut treasure
            world[19, 9].ItemInRoom = new Treasure();

            // Placera ut monster Witch
            for (int i = 0; i < 2; i++)
            {
                Room tempPlaceForMonster = world[random.Next(0, 20), random.Next(0, 10)];
                if (tempPlaceForMonster.Block == false && tempPlaceForMonster.MonsterInRoom == null)
                    tempPlaceForMonster.MonsterInRoom = new Witch("Witch", random.Next(20, 50), random.Next(5, 20), new Weapon("Staf", 4, 8));
            }

            //PLacera ut monster Boar
            for (int i = 0; i < 7; i++)
            {
                Room tempPlaceForMonster = world[random.Next(0, 20), random.Next(0, 10)];
                if (tempPlaceForMonster.Block == false && tempPlaceForMonster.MonsterInRoom == null)
                    tempPlaceForMonster.MonsterInRoom = new Boar("Boar", random.Next(20, 50), random.Next(5, 20));
            }

            // Placera ut Potions
            for (int i = 0; i < 4; i++)
            {
                Room tempPlaceForPotion = world[random.Next(0, 20), random.Next(0, 10)];
                if (tempPlaceForPotion.Block == false && tempPlaceForPotion.MonsterInRoom == null && tempPlaceForPotion.ItemInRoom == null)
                    tempPlaceForPotion.ItemInRoom = new Potion("Juice", random.Next(1, 7), random.Next(5, 15));
            }

            // Placera ut svärd
            for (int i = 0; i < 4; i++)
            {
                Room tempPlaceForPotion = world[random.Next(0, 20), random.Next(0, 10)];
                if (tempPlaceForPotion.Block == false && tempPlaceForPotion.MonsterInRoom == null && tempPlaceForPotion.ItemInRoom == null)
                    tempPlaceForPotion.ItemInRoom = new Weapon("Sword", random.Next(3, 7), random.Next(5, 10));
            }


            //placera ut the ring

            world[random.Next(1, 20), random.Next(1, 10)].ItemInRoom = new TheRing();
        }

        void CreatePlayer()
        {
            player = new Player("Player", 500, 80);
            myClient = new Client(this);
            Thread playerThread = new Thread(() => myClient.Start(player));
            playerThread.Start();
            //playerThread.Join();
        }

        public void btnUp_Click(object sender, EventArgs e)
        {
            MovePlayer(player, "up");

            //int x = player.X;
            //int y = player.Y;
            //world[player.X, player.Y].Image = null;
            //if ( player.Y-1 >= 0 && world[x, y-1].Block == false)
            //{
            //    CheckForItem(x, (y - 1));
            //    CheckForMonster(x, (y - 1));
            //    player.Y--;
            //    drive = true;
            //}
            //DisplayPlayer();
            //drive = false;
        }

        public void btnLeft_Click(object sender, EventArgs e)
        {
            MovePlayer(player, "left");

            //int x = player.X;
            //int y = player.Y;
            //world[player.X, player.Y].Image = null;
            //if (player.X-1 >= 0 && world[x-1, y].Block == false)
            //{
            //    CheckForItem((x - 1), y);
            //    CheckForMonster((x - 1), y);
            //    player.X--;
            //    drive = true;
            //}
            //DisplayPlayer();
            //drive = false;
        }

        public void btnDown_Click(object sender, EventArgs e)
        {
            MovePlayer(player, "down");

            //int x = player.X;
            //int y = player.Y;
            //world[player.X, player.Y].Image = null;
            //if (player.Y + 1 < WorldHeight && world[x, y+1].Block == false)
            //{
            //    CheckForItem(x, (y + 1));
            //    CheckForMonster(x, (y+1));
            //    player.Y++;
            //    drive = true;
            //}
            //DisplayPlayer();
            //drive = false;
        }

        public void btnRight_Click(object sender, EventArgs e)
        {
            MovePlayer(player, "right");


            //int x = player.X;
            //int y = player.Y;
            //world[player.X, player.Y].Image = null;
            //if (player.X + 1 < WorldWidth && world[x + 1, y].Block == false)
            //{
            //    CheckForItem((x + 1), y);
            //    CheckForMonster((x + 1), y);
            //    player.X++;
            //    drive = true;
            //}
            //DisplayPlayer();
            //drive = false;
        }

        public string GetParam(string param)
        {
            return param;
        }
        public void DisplayPlayer(int inputX, int inputY)
        {

            player.X = inputX;
            player.Y = inputY;
            
            world[inputX, inputY].Image = Image.FromFile(@"C:\Users\Administrator\Documents\Visual Studio 2015\Projects\Fancy_Dungeons_Of_Doom\Fancy_Dungeons_Of_Doom\Image\PlayerIkon small.png");
            lblAttack.Text = player.AttackStrength.ToString();
            lblHealth.Text = player.Health.ToString();
        }

        void DisplayObjects()
        {
            for (int y = 0; y < WorldHeight; y++)
            {
                for (int x = 0; x < WorldWidth; x++)
                {
                    GameButton room = world[x, y];

                    if (room.MonsterInRoom != null)
                        if (room.MonsterInRoom is Dragon)
                            room.Image = Image.FromFile(@"C:\Users\Administrator\Documents\Visual Studio 2015\Projects\Fancy_Dungeons_Of_Doom\Fancy_Dungeons_Of_Doom\Image\Dragon.jpg");
                        else
                            room.Image = Image.FromFile(@"C:\Users\Administrator\Documents\Visual Studio 2015\Projects\Fancy_Dungeons_Of_Doom\Fancy_Dungeons_Of_Doom\Image\Monster.jpg");
                    else if (room.ItemInRoom != null)
                        if (room.ItemInRoom is Treasure)
                            room.Image = Image.FromFile(@"C:\Users\Administrator\Documents\Visual Studio 2015\Projects\Fancy_Dungeons_Of_Doom\Fancy_Dungeons_Of_Doom\Image\Treasure.png");
                        else
                            room.Image = Image.FromFile(@"C:\Users\Administrator\Documents\Visual Studio 2015\Projects\Fancy_Dungeons_Of_Doom\Fancy_Dungeons_Of_Doom\Image\Items2.png");
                    else if (room.Block == true)
                        room.Image = Image.FromFile(@"C:\Users\Administrator\Documents\Visual Studio 2015\Projects\Fancy_Dungeons_Of_Doom\Fancy_Dungeons_Of_Doom\Image\Wall.png");
                }
            }
        }

        private void CheckForMonster(int nextX, int nextY)
        {
            int a=0;
            if (world[nextX, nextY].MonsterInRoom != null)
            {
                MessageBox.Show("OHH no, you bumbed into "+ world[nextX, nextY].MonsterInRoom.Name+". Do you wish to engage " + world[nextX, nextY].MonsterInRoom.Name +" in a fight?");
                Monster monster = world[nextX, nextY].MonsterInRoom;

                var forFun = new FormFight();
                if (forFun.GameFightMonster(monster, player).Health <= 0)
                {
                    world[nextX, nextY].MonsterInRoom = null;
                    a++;
                }
                
            }
            
        }

        void CheckForItem(int nextX, int nextY)
        {
            if (world[nextX, nextY].ItemInRoom != null)
            {
                MessageBox.Show(world[nextX, nextY].ItemInRoom.FoundItem(player));
            }
            world[nextX, nextY].ItemInRoom = null;
        }
        public void MovePlayer(Player player, string move)
        {
            drive = false;

            int tempPlayerPosition;
            int tempPlayerNotPosition;
            int tempMove;
            int posX;
            int posY;
            int dimension;

            switch (move)
            {
                case "right":
                    tempPlayerPosition = player.X;
                    tempPlayerNotPosition = player.Y;
                    tempMove = 1;
                    posX = 1;
                    posY = 0;
                    dimension = WorldWidth;
                    break;
                case "left":
                    tempPlayerPosition = player.X;
                    tempPlayerNotPosition = player.Y;
                    tempMove = -1;
                    posX = -1;
                    posY = 0;
                    dimension = 0;
                    break;
                case "up":
                    tempPlayerPosition = player.Y;
                    tempPlayerNotPosition = player.X;
                    tempMove = -1;
                    posY = -1;
                    posX = 0;
                    dimension = 0;
                    break;
                case "down":
                    tempPlayerPosition = player.Y;
                    tempPlayerNotPosition = player.X;
                    tempMove = 1;
                    posY = 1;
                    posX = 0;
                    dimension = WorldHeight;
                    break;
                default:
                    tempPlayerPosition = player.X;
                    tempMove = 0;
                    posY = 1;
                    posX = 0;
                    tempPlayerNotPosition = player.X;
                    dimension = 10;
                    break;
            }

            world[player.X, player.Y].Image = null;
            if (move == "up" || move == "left")
            {
                if (tempPlayerPosition + tempMove >= dimension && world[(player.X + posX), (player.Y + posY)].Block == false)
                {
                    CheckForItem((player.X + posX), (player.Y + posY));
                    CheckForMonster((player.X + posX), (player.Y + posY));
                    tempPlayerPosition += tempMove;
                    player.X += posX;
                    player.Y += posY;
                }
            }
            else if (move == "right" || move == "down")
            {
                if (tempPlayerPosition + tempMove < dimension && world[(player.X + posX), (player.Y + posY)].Block == false)
                {
                    CheckForItem((player.X + posX), (player.Y + posY));
                    CheckForMonster((player.X + posX), (player.Y + posY));
                    tempPlayerPosition += tempMove;
                    player.X += posX;
                    player.Y += posY;
                }
            }
            drive = true;
                //DisplayPlayer();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            myClient.KillYourself();
        }
    }
}
