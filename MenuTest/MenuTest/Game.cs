using SeaWars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuTest
{
    public partial class Game : Form
    {
        public const int mapSize = 11;
        public int cellSize = 30;
        public string alphabet = "АБВГДЕЗЖИК";

        public int[,] myMap = new int[mapSize, mapSize];
        public int[,] enemyMap = new int[mapSize, mapSize];
        public int[,] myDeadMap = new int[Game.mapSize, Game.mapSize];

        public Button[,] myButtons = new Button[mapSize, mapSize];
        public Button[,] enemyButtons = new Button[mapSize, mapSize];

        public int[] countShip = new int[4];
        public int MovesAmount = 0;

        public bool isEmpty1 = true;
        public bool isPlaying = false;
        public bool Blocked1 = false, Blocked2 = false, Blocked3 = false, Blocked4 = false, Blocked = false;
        public bool One = false, Two = false, Three = false, Four = false;
        public bool first = true, second = false, third = false;
        public bool horizont = true;
        public Bot bot;
        public Game()
        {
            InitializeComponent();
            this.Text = "Морской бой";
            RecordsWriter.OpenNewFile("records");
            countShip[0] = 4;
            countShip[1] = 3;
            countShip[2] = 2;
            countShip[3] = 1;
            RecordsWriter.OpenNewFile("records");
            Init();
        }
        public void Init()
        {
            isPlaying = false;
            CreateMaps();
            bot = new Bot(enemyMap, myMap, enemyButtons, myButtons);
            enemyMap = bot.ConfigureShips();
        }

        public void DeathNote(int i, int j)
        {
            if (One)
            {
                if (IsInsideMap(i + 1, j))
                    myDeadMap[i + 1, j] = 1;
                if (IsInsideMap(i - 1, j))
                    myDeadMap[i - 1, j] = 1;
                if (IsInsideMap(i, j + 1))
                    myDeadMap[i, j + 1] = 1;
                if (IsInsideMap(i, j - 1))
                    myDeadMap[i, j - 1] = 1;
                if (IsInsideMap(i + 1, j + 1))
                    myDeadMap[i + 1, j + 1] = 1;
                if (IsInsideMap(i + 1, j - 1))
                    myDeadMap[i + 1, j - 1] = 1;
                if (IsInsideMap(i - 1, j + 1))
                    myDeadMap[i - 1, j + 1] = 1;
                if (IsInsideMap(i - 1, j - 1))
                    myDeadMap[i - 1, j - 1] = 1;
            }
            if (Two)
            {
                if (IsInsideMap(i + 1, j))
                    if (myMap[i + 1, j] == 1)
                    {
                        if (IsInsideMap(i + 2, j - 1))
                            myDeadMap[i + 2, j - 1] = 1;
                        if (IsInsideMap(i + 2, j + 1))
                            myDeadMap[i + 2, j + 1] = 1;
                        if (IsInsideMap(i + 2, j))
                            myDeadMap[i + 2, j] = 1;
                    }
                    else
                        myDeadMap[i + 1, j] = 1;
                if (IsInsideMap(i - 1, j))
                    if (myMap[i - 1, j] == 1)
                    {
                        if (IsInsideMap(i - 2, j - 1))
                            myDeadMap[i - 2, j - 1] = 1;
                        if (IsInsideMap(i - 2, j + 1))
                            myDeadMap[i - 2, j + 1] = 1;
                        if (IsInsideMap(i - 2, j))
                            myDeadMap[i - 2, j] = 1;
                    }
                    else
                        myDeadMap[i - 1, j] = 1;
                if (IsInsideMap(i, j + 1))
                    if (myMap[i, j + 1] == 1)
                    {
                        if (IsInsideMap(i + 1, j + 2))
                            myDeadMap[i + 1, j + 2] = 1;
                        if (IsInsideMap(i, j + 2))
                            myDeadMap[i, j + 2] = 1;
                        if (IsInsideMap(i - 1, j + 2))
                            myDeadMap[i - 1, j + 2] = 1;
                    }
                    else
                        myDeadMap[i, j + 1] = 1;
                if (IsInsideMap(i, j - 1))
                    if (myMap[i, j - 1] == 1)
                    {
                        if (IsInsideMap(i + 1, j - 2))
                            myDeadMap[i + 1, j - 2] = 1;
                        if (IsInsideMap(i, j - 2))
                            myDeadMap[i, j - 2] = 1;
                        if (IsInsideMap(i - 1, j - 2))
                            myDeadMap[i - 1, j - 2] = 1;
                    }
                    else
                        myDeadMap[i, j - 1] = 1;
                if (IsInsideMap(i + 1, j + 1))
                    myDeadMap[i + 1, j + 1] = 1;
                if (IsInsideMap(i + 1, j - 1))
                    myDeadMap[i + 1, j - 1] = 1;
                if (IsInsideMap(i - 1, j + 1))
                    myDeadMap[i - 1, j + 1] = 1;
                if (IsInsideMap(i - 1, j - 1))
                    myDeadMap[i - 1, j - 1] = 1;
            }

            if (Three)
            {
                if (IsInsideMap(i + 1, j))
                    if (myMap[i + 1, j] == 1)
                    {
                        if (IsInsideMap(i + 2, j - 1))
                            myDeadMap[i + 2, j - 1] = 1;
                        if (IsInsideMap(i + 2, j + 1))
                            myDeadMap[i + 2, j + 1] = 1;
                        if (IsInsideMap(i + 3, j - 1))
                            myDeadMap[i + 3, j - 1] = 1;
                        if (IsInsideMap(i + 3, j + 1))
                            myDeadMap[i + 3, j + 1] = 1;
                        if (IsInsideMap(i + 3, j))
                            myDeadMap[i + 3, j] = 1;
                    }
                    else
                        myDeadMap[i + 1, j] = 1;
                if (IsInsideMap(i - 1, j))
                    if (myMap[i - 1, j] == 1)
                    {
                        if (IsInsideMap(i - 2, j - 1))
                            myDeadMap[i - 2, j - 1] = 1;
                        if (IsInsideMap(i - 2, j + 1))
                            myDeadMap[i - 2, j + 1] = 1;
                        if (IsInsideMap(i - 2, j - 1))
                            myDeadMap[i - 3, j - 1] = 1;
                        if (IsInsideMap(i - 3, j + 1))
                            myDeadMap[i - 3, j + 1] = 1;
                        if (IsInsideMap(i - 3, j))
                            myDeadMap[i - 3, j] = 1;
                    }
                    else
                        myDeadMap[i - 1, j] = 1;
                if (IsInsideMap(i, j + 1))
                    if (myMap[i, j + 1] == 1)
                    {
                        if (IsInsideMap(i + 1, j + 2))
                            myDeadMap[i + 1, j + 2] = 1;
                        if (IsInsideMap(i - 1, j + 2))
                            myDeadMap[i - 1, j + 2] = 1;
                        if (IsInsideMap(i + 1, j + 3))
                            myDeadMap[i + 1, j + 3] = 1;
                        if (IsInsideMap(i, j + 3))
                            myDeadMap[i, j + 3] = 1;
                        if (IsInsideMap(i - 1, j + 3))
                            myDeadMap[i - 1, j + 3] = 1;
                    }
                    else
                        myDeadMap[i, j + 1] = 1;
                if (IsInsideMap(i, j - 1))
                    if (myMap[i, j - 1] == 1)
                    {
                        if (IsInsideMap(i + 1, j - 2))
                            myDeadMap[i + 1, j - 2] = 1;
                        if (IsInsideMap(i - 1, j - 2))
                            myDeadMap[i - 1, j - 2] = 1;
                        if (IsInsideMap(i + 1, j - 3))
                            myDeadMap[i + 1, j - 3] = 1;
                        if (IsInsideMap(i, j - 3))
                            myDeadMap[i, j - 3] = 1;
                        if (IsInsideMap(i - 1, j - 3))
                            myDeadMap[i - 1, j - 3] = 1;
                    }
                    else
                        myDeadMap[i, j - 1] = 1;
                if (IsInsideMap(i + 1, j + 1))
                    myDeadMap[i + 1, j + 1] = 1;
                if (IsInsideMap(i + 1, j - 1))
                    myDeadMap[i + 1, j - 1] = 1;
                if (IsInsideMap(i - 1, j + 1))
                    myDeadMap[i - 1, j + 1] = 1;
                if (IsInsideMap(i - 1, j - 1))
                    myDeadMap[i - 1, j - 1] = 1;

            }

            if (Four)
            {
                if (IsInsideMap(i + 1, j))
                    if (myMap[i + 1, j] == 1)
                    {
                        if (IsInsideMap(i + 4, j))
                            myDeadMap[i + 4, j] = 1;
                        if (IsInsideMap(i + 3, j + 1))
                            myDeadMap[i + 3, j + 1] = 1;
                        if (IsInsideMap(i + 3, j - 1))
                            myDeadMap[i + 3, j - 1] = 1;
                        if (IsInsideMap(i + 4, j + 1))
                            myDeadMap[i + 4, j + 1] = 1;
                        if (IsInsideMap(i + 4, j - 1))
                            myDeadMap[i + 4, j - 1] = 1;
                        if (IsInsideMap(i + 2, j + 1))
                            myDeadMap[i + 2, j + 1] = 1;
                        if (IsInsideMap(i + 2, j - 1))
                            myDeadMap[i + 2, j - 1] = 1;
                    }
                    else
                        myDeadMap[i + 1, j] = 1;
                if (IsInsideMap(i - 1, j))
                    if (myMap[i - 1, j] == 1)
                    {
                        if (IsInsideMap(i - 4, j))
                            myDeadMap[i - 4, j] = 1;
                        if (IsInsideMap(i - 3, j + 1))
                            myDeadMap[i - 3, j + 1] = 1;
                        if (IsInsideMap(i - 3, j - 1))
                            myDeadMap[i - 3, j - 1] = 1;
                        if (IsInsideMap(i - 2, j + 1))
                            myDeadMap[i - 2, j + 1] = 1;
                        if (IsInsideMap(i - 2, j - 1))
                            myDeadMap[i - 2, j - 1] = 1;
                        if (IsInsideMap(i - 4, j + 1))
                            myDeadMap[i - 4, j + 1] = 1;
                        if (IsInsideMap(i - 4, j - 1))
                            myDeadMap[i - 4, j - 1] = 1;
                    }
                    else
                        myDeadMap[i - 1, j] = 1;
                if (IsInsideMap(i, j + 1))
                    if (myMap[i, j + 1] == 1)
                    {
                        if (IsInsideMap(i + 1, j + 3))
                            myDeadMap[i + 1, j + 3] = 1;
                        if (IsInsideMap(i - 1, j + 3))
                            myDeadMap[i - 1, j + 3] = 1;
                        if (IsInsideMap(i, j + 4))
                            myDeadMap[i, j + 4] = 1;
                        if (IsInsideMap(i + 1, j + 4))
                            myDeadMap[i + 1, j + 4] = 1;
                        if (IsInsideMap(i + 1, j + 2))
                            myDeadMap[i + 1, j + 2] = 1;
                        if (IsInsideMap(i - 1, j + 4))
                            myDeadMap[i - 1, j + 4] = 1;
                        if (IsInsideMap(i - 1, j + 2))
                            myDeadMap[i - 1, j + 2] = 1;
                    }
                    else
                        myDeadMap[i, j + 1] = 1;
                if (IsInsideMap(i, j - 1))
                    if (myMap[i, j - 1] == 1)
                    {
                        if (IsInsideMap(i + 1, j - 3))
                            myDeadMap[i + 1, j - 3] = 1;
                        if (IsInsideMap(i - 1, j - 3))
                            myDeadMap[i - 1, j - 3] = 1;
                        if (IsInsideMap(i, j - 4))
                            myDeadMap[i, j - 4] = 1;
                        if (IsInsideMap(i + 1, j - 2))
                            myDeadMap[i + 1, j - 2] = 1;
                        if (IsInsideMap(i + 1, j - 4))
                            myDeadMap[i + 1, j - 4] = 1;
                        if (IsInsideMap(i - 1, j - 2))
                            myDeadMap[i - 1, j - 2] = 1;
                        if (IsInsideMap(i - 1, j - 4))
                            myDeadMap[i - 1, j - 4] = 1;
                    }
                    else
                        myDeadMap[i, j - 1] = 1;
                if (IsInsideMap(i + 1, j + 1))
                    myDeadMap[i + 1, j + 1] = 1;
                if (IsInsideMap(i + 1, j - 1))
                    myDeadMap[i + 1, j - 1] = 1;
                if (IsInsideMap(i - 1, j + 1))
                    myDeadMap[i - 1, j + 1] = 1;
                if (IsInsideMap(i - 1, j - 1))
                    myDeadMap[i - 1, j - 1] = 1;
            }
        }

        public void DeleteDeathNote(int i, int j)
        {
            if (IsInsideMap(i + 1, j))
                myDeadMap[i + 1, j] = 0;
            if (IsInsideMap(i - 1, j))
                myDeadMap[i - 1, j] = 0;
            if (IsInsideMap(i, j + 1))
                myDeadMap[i, j + 1] = 0;
            if (IsInsideMap(i, j - 1))
                myDeadMap[i, j - 1] = 0;
            if (IsInsideMap(i + 1, j + 1))
                myDeadMap[i + 1, j + 1] = 0;
            if (IsInsideMap(i + 1, j - 1))
                myDeadMap[i + 1, j - 1] = 0;
            if (IsInsideMap(i - 1, j + 1))
                myDeadMap[i - 1, j + 1] = 0;
            if (IsInsideMap(i - 1, j - 1))
                myDeadMap[i - 1, j - 1] = 0;
        }

        public bool CheckIfMapIsNotEmpty()
        {
                bool isEmpty1 = true;
                bool isEmpty2 = true;
                for (int i = 1; i < mapSize; i++)
                {
                    for (int j = 1; j < mapSize; j++)
                    {
                        if (myMap[i, j] != 0)
                            isEmpty1 = false;
                        if (enemyMap[i, j] != 0)
                            isEmpty2 = false;
                    }
                }
                if (isEmpty1 || isEmpty2)
                    return false;
                else return true;
        }

        public bool WhoWins()
        {
                bool isEmpty1 = true;
                bool isEmpty2 = true;
                for (int i = 1; i < mapSize; i++)
                {
                    for (int j = 1; j < mapSize; j++)
                    {
                        if (myMap[i, j] != 0)
                            isEmpty1 = false;
                        if (enemyMap[i, j] != 0)
                            isEmpty2 = false;
                    }
                }
                if (isEmpty2) return true;
                else return false;

        }
        public bool IsInsideMap(int i, int j)
        {
            if (i < 0 || j <0 || i >= mapSize || j >= mapSize)
            {
                return false;
            }
            return true;
        }

        public bool IsDeathMap(int i, int j, int length)
        {
            for (int k = 0; k < length; k++)
            {
                if (myDeadMap[i, j + k] == 1)
                    return true;
            }

            return false;
        }

        public bool CheckedHorizont(int i, int j)
        {
            bool check = false, check1 = false, check2 = false;
            if (IsInsideMap(i, j + 1))
                if (myMap[i, j + 1] == 1) check1 = true; else check1 = false;
            if (IsInsideMap(i, j - 1))
                if (myMap[i, j - 1] == 1) check2 = true; else check2 = false;
            if (check1 || check2) check = true;
            return check;
        }

        public bool CheckedVertical(int i, int j)
        {
            bool check = false, check1 = false, check2 = false;
            if (IsInsideMap(i + 1, j))
                if (myMap[i + 1, j] == 1) check1 = true; else check1 = false;
            if (IsInsideMap(i - 1, j))
                if (myMap[i - 1, j] == 1) check2 = true; else check2 = false;
            if (check1 || check2) check = true;
            return check;
        }

        public void ConfigureShips(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button;

            if (!isPlaying && !Blocked)
            {
                if (One && !Blocked1)
                {
                    if (myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] == 0 && !IsDeathMap(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize, 1))
                    {
                        pressedButton.BackColor = Color.Red;
                        myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] = 1;
                        countShip[0]--;
                        DeathNote(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize);
                        Block(1);
                    }
                    else
                    {
                        pressedButton.BackColor = Color.White;
                        myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] = 0;
                        if (myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] == 1)
                        {
                            countShip[0]++;
                            DeleteDeathNote(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize);
                        }
                    }
                }

                if (Two && !Blocked2)
                {
                    if (myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] == 0 && !IsDeathMap(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize, 1))
                    {
                        if (first)
                        {
                            pressedButton.BackColor = Color.Red;
                            myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] = 1;
                            first = false;
                        }
                        else
                        {
                            if (CheckedHorizont(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize) || CheckedVertical(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize))
                            {
                                pressedButton.BackColor = Color.Red;
                                myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] = 1;
                                countShip[1]--;
                                DeathNote(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize);
                                Block(2);
                                first = true;
                            }
                        }
                    }
                    else
                    {
                        pressedButton.BackColor = Color.White;
                        myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] = 0;
                        if (myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] == 1)
                        {
                            if (first) first = false;
                            else
                            {
                                countShip[0]++;
                                DeleteDeathNote(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize);
                                first = true;
                            }
                        }
                    }
                }

                if (Three && !Blocked3)
                {
                    if (myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] == 0 && !IsDeathMap(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize, 1))
                    {
                        if (first)
                        {
                            pressedButton.BackColor = Color.Red;
                            myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] = 1;
                            first = false;
                            second = true;
                        }
                        else if (second)
                        {
                            if (CheckedVertical(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize))
                            {
                                pressedButton.BackColor = Color.Red;
                                myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] = 1;
                                second = false;
                                horizont = false;
                            }
                            if (CheckedHorizont(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize))
                            {
                                pressedButton.BackColor = Color.Red;
                                myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] = 1;
                                second = false;
                                horizont = true;
                            }

                        }
                        else
                        {
                            if (horizont)
                            {
                                if (CheckedHorizont(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize))
                                {
                                    pressedButton.BackColor = Color.Red;
                                    myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] = 1;
                                    countShip[2]--;
                                    DeathNote(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize);
                                    Block(3);
                                    first = true;
                                }
                            }
                            else if (CheckedVertical(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize))
                            {
                                pressedButton.BackColor = Color.Red;
                                myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] = 1;
                                countShip[2]--;
                                DeathNote(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize);
                                Block(3);
                                first = true;
                            }
                        }
                    }
                    else
                    {
                        pressedButton.BackColor = Color.Red;
                        myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] = 1;
                        if (myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] == 1)
                        {
                            if (second)
                            {
                                first = true;
                                countShip[2]--;
                                DeleteDeathNote(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize);
                            }
                            else if (first)
                            {
                                first = false;
                                DeleteDeathNote(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize);
                            }
                            else second = true;
                        }
                    }
                }

                if (Four && !Blocked4)
                {
                    if (myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] == 0 && !IsDeathMap(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize, 1))
                    {
                        if (first)
                        {
                            pressedButton.BackColor = Color.Red;
                            myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] = 1;
                            first = false;
                            second = true;
                        }
                        else if (second)
                        {
                            if (CheckedVertical(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize))
                            {
                                pressedButton.BackColor = Color.Red;
                                myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] = 1;
                                second = false;
                                third = true;
                                horizont = false;
                            }
                            if (CheckedHorizont(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize))
                            {
                                pressedButton.BackColor = Color.Red;
                                myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] = 1;
                                second = false;
                                third = true;
                                horizont = true;
                            }

                        }
                        else if (third)
                        {
                            if (horizont)
                            {
                                if (CheckedHorizont(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize))
                                {
                                    pressedButton.BackColor = Color.Red;
                                    myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] = 1;
                                    third = false;
                                }
                            }
                            else if (CheckedVertical(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize))
                            {
                                pressedButton.BackColor = Color.Red;
                                myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] = 1;
                                third = false;
                            }
                        }
                        else
                        {
                            if (horizont)
                            {
                                if (CheckedHorizont(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize))
                                {
                                    pressedButton.BackColor = Color.Red;
                                    myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] = 1;
                                    countShip[3]--;
                                    DeathNote(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize);
                                    Block(4);
                                    first = true;
                                }
                            }
                            else if (CheckedVertical(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize))
                            {
                                pressedButton.BackColor = Color.Red;
                                myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] = 1;
                                countShip[3]--;
                                DeathNote(pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize);
                                Block(4);
                                first = true;
                            }
                        }
                    }
                }
                
            }

        }

        public void Deck1(object sender, EventArgs e)
        {
            RadioButton first = sender as RadioButton;
            if (first.Checked) One = true;
            else One = false;

        }


        public void Deck2(object sender, EventArgs e)
        {
            RadioButton second = sender as RadioButton;
            if (second.Checked) Two = true;
            else Two = false;
        }

        public void Deck3(object sender, EventArgs e)
        {
            RadioButton third = sender as RadioButton;
            if (third.Checked) Three = true;
            else Three = false;
        }

        public void Deck4(object sender, EventArgs e)
        {
            RadioButton fourth = sender as RadioButton;
            if (fourth.Checked) Four = true;
            else Four = false;
        }
        public void Block(int count)
        {
            switch (count)
            {
                case 1:
                    {
                        if (countShip[0] == 0) Blocked1 = true; else Blocked1 = false;
                    }
                    break;
                case 2: if (countShip[1] == 0) Blocked2 = true; else Blocked2 = false; break;
                case 3: if (countShip[2] == 0) Blocked3 = true; else Blocked3 = false; break;
                case 4: if (countShip[3] == 0) Blocked4 = true; else Blocked4 = false; break;
            }

            if (Blocked1 && Blocked2 && Blocked3 && Blocked4) Blocked = true;
            else Blocked = false;
        }
        public void CreateMaps()
        {
            this.Width = mapSize * 2 * cellSize + 50;
            this.Height = (mapSize + 3) * cellSize + 20;
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    myMap[i, j] = 0;

                    Button button = new Button();
                    button.Location = new Point(j * cellSize, i * cellSize);
                    button.Size = new Size(cellSize, cellSize);
                    button.BackColor = Color.White;
                    if (j == 0 || i == 0)
                    {
                        button.BackColor = Color.Gray;
                        if (i == 0 && j > 0)
                            button.Text = alphabet[j - 1].ToString();
                        if (j == 0 && i > 0)
                            button.Text = i.ToString();
                    }
                    else
                    {
                        button.Click += new EventHandler(ConfigureShips);
                    }
                    myButtons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    myMap[i, j] = 0;
                    enemyMap[i, j] = 0;

                    Button button = new Button();
                    button.Location = new Point(450 + j * cellSize, i * cellSize);
                    button.Size = new Size(cellSize, cellSize);
                    button.BackColor = Color.White;
                    if (j == 0 || i == 0)
                    {
                        button.BackColor = Color.Gray;
                        if (i == 0 && j > 0)
                            button.Text = alphabet[j - 1].ToString();
                        if (j == 0 && i > 0)
                            button.Text = i.ToString();
                    }
                    else
                    {
                        button.Click += new EventHandler(PlayerShoot);
                    }
                    enemyButtons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
            RadioButton OneDeck = new RadioButton();
            OneDeck.Location = new Point(330, cellSize * 2);
            OneDeck.CheckedChanged += new EventHandler(Deck1);
            this.Controls.Add(OneDeck);

            RadioButton TwoDeck = new RadioButton();
            TwoDeck.Location = new Point(330, cellSize * 3);
            TwoDeck.CheckedChanged += new EventHandler(Deck2);
            this.Controls.Add(TwoDeck);

            RadioButton ThreeDeck = new RadioButton();
            ThreeDeck.Location = new Point(330, cellSize * 4);
            ThreeDeck.CheckedChanged += new EventHandler(Deck3);
            this.Controls.Add(ThreeDeck);

            RadioButton FourDeck = new RadioButton();
            FourDeck.Location = new Point(330, cellSize * 5);
            FourDeck.CheckedChanged += new EventHandler(Deck4);
            this.Controls.Add(FourDeck);


        }

        public void PlayerShoot(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                Button pressedButton = sender as Button;
                bool playerTurn = Shoot(enemyMap, pressedButton);
                if (!playerTurn)
                    bot.Shoot();

                if (!CheckIfMapIsNotEmpty())
                {
                    
                    if (WhoWins())
                    {
                        RecordsWriter.SetNewRecord(MovesAmount);
                        string message = "Победа!";
                        MessageBox.Show(message);
                        Menu MainMenu = new Menu();
                        this.Hide();
                        MainMenu.Show();
                    }
                    else
                    {
                        string message = "Вы проиграли!";
                        MessageBox.Show(message);
                        Menu MainMenu = new Menu();
                        this.Hide();
                        MainMenu.Show();
                    }
                    this.Controls.Clear();
                    Init();
                }

            }
           

        }
        public bool Shoot(int[,] map, Button pressedButton)
        {
            bool hit = false;
            if (isPlaying)
            {
                int delta = 0;
                if (pressedButton.Location.X > 450)
                    delta = 450;
               if (pressedButton.BackColor != Color.Black && pressedButton.BackColor != Color.Blue)
               {
                  if (map[pressedButton.Location.Y / cellSize, (pressedButton.Location.X - delta) / cellSize] != 0)
                    {
                        hit = true;
                        map[pressedButton.Location.Y / cellSize, (pressedButton.Location.X - delta) / cellSize] = 0;
                        pressedButton.BackColor = Color.Blue;
                        pressedButton.Text = "X";
                        MovesAmount++;
                    }
                    else
                    {
                        hit = false;

                        pressedButton.BackColor = Color.Black;
                        MovesAmount++;
                    }
              }
               else hit = true;
               
            }

            return hit;
        }

        public void StartGameButton_Click(object sender, EventArgs e)
        {
            if (Blocked== false)
            {
                string message1 = "Сначала расставьте корабли";
                MessageBox.Show(message1);
            }
            if (Blocked == true)
            {
                isPlaying = true;
                string message = "Игра началась";
                MessageBox.Show(message);
                StartGameButton.Enabled = false;
            }
            

        }
        private void GameMainMenu_Click(object sender, EventArgs e)
        {
            Menu MainMenu = new Menu();
            this.Hide();
            MainMenu.Show();
        }

        private void ExitFromGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
