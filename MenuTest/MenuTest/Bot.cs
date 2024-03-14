using MenuTest;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaWars
{
    public class Bot
    {
        public int[,] myMap = new int[Game.mapSize, Game.mapSize];//bot`s map
        public int[,] enemyMap = new int[Game.mapSize, Game.mapSize];//player`s map

        public int[,] myDeadMap = new int[Game.mapSize, Game.mapSize];//bot`s dead map
        public int[,] enemyDeadMap = new int[Game.mapSize, Game.mapSize];//player`s dead map

        public Button[,] myButtons = new Button[Game.mapSize, Game.mapSize];
        public Button[,] enemyButtons = new Button[Game.mapSize, Game.mapSize];

        public int lastx, lasty, direction, count = 0, sec = 0, th = 0, fth = 0;
        public bool first = true, second = false, third = false;

        public Bot(int[,] myMap, int[,] enemyMap, Button[,] myButtons, Button[,] enemyButtons)
        {
            this.myMap = myMap;
            this.enemyMap = enemyMap;
            this.enemyButtons = enemyButtons;
            this.myButtons = myButtons;
        }

        public bool IsInsideMap(int i, int j)
        {
            if (i <= 0 || j <= 0 || i >= Game.mapSize || j >= Game.mapSize)
            {
                return false;
            }
            return true;
        }

        public bool IsEmpty(int i, int j, int length)
        {
            bool isEmpty = true;

            for (int k = j; k < j + length; k++)
            {
                if (myMap[i, k] != 0)
                {
                    isEmpty = false;
                    break;
                }
            }

            return isEmpty;
        }
        public void DeathNote(int i, int j)
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

        public void EnemyDeathNote(int i, int j, int k)
        {
            if (k == 1)
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
            if (k == 2)
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

            if (k== 3)
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

            if (k ==4 )
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
        public bool IsDeathMap(int i, int j, int length)
        {
            for (int k = 0; k < length; k++)
            {
                if (myDeadMap[i, j + k] == 1)
                    return true;
            }

            return false;
        }

        public int[,] ConfigureShips()
        {
            Random random = new Random();
            int x, y;

            do
            {
                do
                {
                    x = random.Next(1, Game.mapSize);
                    y = random.Next(1, Game.mapSize);
                } while (!IsInsideMap(x, y + 4));
            } while (!IsEmpty(x, y, 4));

            for (int i = 0; i < 4; i++)
            {
                myMap[x, y + i] = 1;
                DeathNote(x, y + i);
            }

            for (int j = 0; j < 2; j++)
            {
                do
                {
                    do
                    {
                        x = random.Next(1, Game.mapSize);
                        y = random.Next(1, Game.mapSize);
                    } while (!IsInsideMap(x, y + 3));
                } while (!IsEmpty(x, y, 3) || IsDeathMap(x, y, 3));
                for (int i = 0; i < 3; i++)
                {
                    myMap[x, y + i] = 1;
                    DeathNote(x, y + i);
                }
            }
            for (int j = 0; j < 3; j++)
            {
                do
                {
                    do
                    {
                        x = random.Next(1, Game.mapSize);
                        y = random.Next(1, Game.mapSize);
                    } while (!IsInsideMap(x, y + 2));
                } while (!IsEmpty(x, y, 2) || IsDeathMap(x, y, 2));
                for (int i = 0; i < 2; i++)
                {
                    myMap[x, y + i] = 1;
                    DeathNote(x, y + i);
                }
            }
            for (int j = 0; j < 4; j++)
            {
                do
                {
                    do
                    {
                        x = random.Next(1, Game.mapSize);
                        y = random.Next(1, Game.mapSize);
                    } while (!IsInsideMap(x, y + 1));
                } while (!IsEmpty(x, y, 1) || IsDeathMap(x, y, 1));
                myMap[x, y] = 1;
                DeathNote(x, y);
            }
            return myMap;
        }



        public bool IsDeathEnemyMap(int i, int j)
        {
            if (enemyDeadMap[i, j] == 1)
                return true;

            return false;
        }


        public bool Shoot()
        {
            bool hit = false;
            int posX = 1, posY = 1;
            Random r = new Random();


            if (second)
            {
                bool find = false;
                do
                {
                    direction = r.Next(1, 4);
                    switch (direction)
                    {
                        case 1:
                            if (IsInsideMap(lastx, lasty + 1))
                                if (!(enemyButtons[lastx, lasty + 1].BackColor == Color.Blue || enemyButtons[lastx, lasty + 1].BackColor == Color.Black) && !IsDeathEnemyMap(lastx, lasty + 1))
                                {
                                    posX = lastx;
                                    posY = lasty + 1;
                                    find = true;
                                }
                                else sec++;
                            break;
                        case 2:
                            if (IsInsideMap(lastx + 1, lasty))
                                if (!(enemyButtons[lastx + 1, lasty].BackColor == Color.Blue || enemyButtons[lastx + 1, lasty].BackColor == Color.Black) && !IsDeathEnemyMap(lastx + 1, lasty))
                                {
                                    posX = lastx + 1;
                                    posY = lasty;
                                    find = true;
                                }
                                else sec++;
                            break;
                        case 3:
                            if (IsInsideMap(lastx, lasty - 1))
                                if (!(enemyButtons[lastx, lasty - 1].BackColor == Color.Blue || enemyButtons[lastx, lasty - 1].BackColor == Color.Black) && !IsDeathEnemyMap(lastx, lasty - 1))
                                {
                                    posX = lastx;
                                    posY = lasty - 1;
                                    find = true;
                                }
                                else sec++;
                            break;
                        case 4:
                            if (IsInsideMap(lastx - 1, lasty))
                                if (!(enemyButtons[lastx - 1, lasty].BackColor == Color.Blue || enemyButtons[lastx - 1, lasty].BackColor == Color.Black) && !IsDeathEnemyMap(lastx - 1, lasty))
                                {
                                    posX = lastx - 1;
                                    posY = lasty;
                                    find = true;
                                }
                                else sec++;
                            break;
                    }
                } while (!find && !(sec >= 4));
                if (sec >= 4)
                {
                    EnemyDeathNote(lastx, lasty, 1);
                    sec = 0;
                    first = true;
                    second = false;
                }
            }

            if (third)
            {
                bool find = false;
                switch (direction)
                {
                    case 1:
                        if (IsInsideMap(lastx, lasty + 1))
                            if (!(enemyButtons[lastx, lasty + 1].BackColor == Color.Blue || enemyButtons[lastx, lasty + 1].BackColor == Color.Black) && !IsDeathEnemyMap(lastx, lasty + 1))
                            {
                                posX = lastx;
                                posY = lasty + 1;
                                find = true;
                            }
                            else th++;
                        if (!find)
                        {
                            if (IsInsideMap(lastx, lasty - 2 - fth))
                                if (!(enemyButtons[lastx, lasty - 2 - fth].BackColor == Color.Blue || enemyButtons[lastx, lasty - 2 - fth].BackColor == Color.Black) && !IsDeathEnemyMap(lastx, lasty - 2 - fth))
                                {
                                    posX = lastx;
                                    posY = lasty - 2 - fth;
                                    find = true;
                                }
                        }
                        else th++;
                        break;
                    case 2:
                        if (IsInsideMap(lastx + 1, lasty))
                            if (!(enemyButtons[lastx + 1, lasty].BackColor == Color.Blue || enemyButtons[lastx + 1, lasty].BackColor == Color.Black) && !IsDeathEnemyMap(lastx + 1, lasty))
                            {
                                posX = lastx + 1;
                                posY = lasty;
                                find = true;
                            }
                            else th++;
                        if (!find)
                        {
                            if (IsInsideMap(lastx - 2 - fth, lasty))
                                if (!(enemyButtons[lastx - 2 - fth, lasty].BackColor == Color.Blue || enemyButtons[lastx - 2 - fth, lasty].BackColor == Color.Black) && !IsDeathEnemyMap(lastx - 2 - fth, lasty))
                                {
                                    posX = lastx - 2 - fth;
                                    posY = lasty;
                                    find = true;
                                }
                        }
                        else th++;
                        break;
                    case 3:
                        if (IsInsideMap(lastx, lasty + 2 - fth))
                            if (!(enemyButtons[lastx, lasty + 2 - fth].BackColor == Color.Blue ||
                                enemyButtons[lastx, lasty + 2 - fth].BackColor == Color.Black) && !IsDeathEnemyMap(lastx, lasty + 2 - fth))
                            {
                                posX = lastx;
                                posY = lasty + 2 - fth;
                                find = true;
                            }
                            else th++;
                        if (!find)
                        {
                            if (IsInsideMap(lastx, lasty - 1))
                                if (!(enemyButtons[lastx, lasty - 1].BackColor == Color.Blue || enemyButtons[lastx, lasty - 1].BackColor == Color.Black) && !IsDeathEnemyMap(lastx, lasty - 1))
                                {
                                    posX = lastx;
                                    posY = lasty - 1;
                                    find = true;
                                }
                        }
                        else th++;
                        break;
                    case 4:
                        if (IsInsideMap(lastx + 2 - fth, lasty))
                            if (!(enemyButtons[lastx + 2 - fth, lasty].BackColor == Color.Blue ||
                                enemyButtons[lastx + 2 - fth, lasty].BackColor == Color.Black) && !IsDeathEnemyMap(lastx + 2 - fth, lasty))
                            {
                                posX = lastx + 2 - fth;
                                posY = lasty;
                                find = true;
                            }
                            else th++;
                        if (!find)
                        {
                            if (IsInsideMap(lastx - 1, lasty))
                                if (!(enemyButtons[lastx - 1, lasty].BackColor == Color.Blue || enemyButtons[lastx - 1, lasty].BackColor == Color.Black) && !IsDeathEnemyMap(lastx - 1, lasty))
                                {
                                    posX = lastx - 1;
                                    posY = lasty;
                                    find = true;
                                }
                        }
                        else th++;
                        break;
                }
                if (th >= 2)
                {
                    EnemyDeathNote(lastx, lasty, count);
                    th = 0;
                    first = true;
                    third = false;
                    count = 0;
                }
            }
            if (first)
            {
                posX = r.Next(1, Game.mapSize);
                posY = r.Next(1, Game.mapSize);

                while ((enemyButtons[posX, posY].BackColor == Color.Blue || enemyButtons[posX, posY].BackColor == Color.Black || IsDeathEnemyMap(posX, posY)) || !IsInsideMap(posX, posY))
                {
                    posX = r.Next(1, Game.mapSize);
                    posY = r.Next(1, Game.mapSize);
                }
            }

            if (enemyMap[posX, posY] != 0)
            {
                hit = true;
                enemyMap[posX, posY] = 0;
                enemyButtons[posX, posY].BackColor = Color.Blue;
                enemyButtons[posX, posY].Text = "X";
                lastx = posX;
                lasty = posY;
                if (first)
                {
                    first = false;
                    second = true;
                    count++;
                }
                else if (second)
                {
                    second = false;
                    third = true;
                    count++;
                }
                else if (third)
                {
                    th = 0;
                    count++;
                    fth++;
                    if (count == 4)
                    {
                        EnemyDeathNote(lastx, lasty, 4);
                        count = 0;
                        first = true;
                        third = false;
                    }
                }
            }
            else
            {
                hit = false;
               if (enemyButtons[posX, posY].BackColor != Color.Blue)
                    enemyButtons[posX, posY].BackColor = Color.Black;
                if (second)
                {
                    if (sec == 4)
                    {
                        EnemyDeathNote(lastx, lasty, 1);
                        sec = 0;
                        first = true;
                        second = false;
                        count = 0;

                    }
                    sec++;
                }
                if (third)
                {
                    if (th == 2)
                    {
                        EnemyDeathNote(lastx, lasty, 2);
                        th = 0;
                        first = true;
                        third = false;
                        count = 0;
                    }
                    if (th == 3)
                    {
                        EnemyDeathNote(lastx, lasty, 3);
                        th = 0;
                        first = true;
                        third = false;
                        count = 0;
                    }
                    th++;
                }
            }
            if (hit)
            {
                Shoot();
            }
            return hit;
        }
    }
}
