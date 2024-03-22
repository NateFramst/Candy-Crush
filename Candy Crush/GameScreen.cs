using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Candy_Crush
{
    public partial class GameScreen : UserControl
    {

        List<Candy> candies = new List<Candy>();

        List<Rectangle> grid = new List<Rectangle>();

        bool mouseDown;

        bool circleMoving = false;

        bool swap;

        int counter;

        int counter2;

        int counter3;
        int startX = 0;
        int startY = 0;
        int squareSize = 40;
        int multiplier = 1;

        int Cxpos;
        int Cypos;


        int lastCxpos, lastCypos;
        int lastValidCxpos, lastValidCypos;

        int gridLocation;

        Random random = new Random();

        Pen whitePen = new Pen(Color.White);

        public GameScreen()
        {
            InitializeComponent();
            GameInitialize();
        }

        void GameInitialize()
        {
            //each grid square is 30 pixels X 30 pixels
            for (int i = 0; i < 100; i++)
            {
                if (grid.Count % 10 == 0)
                {
                    startY += squareSize;
                    multiplier = 1;
                    Rectangle square = new Rectangle(startX + squareSize * multiplier, startY, squareSize, squareSize);
                    grid.Add(square);
                }
                else
                {
                    Rectangle square = new Rectangle(startX + squareSize * multiplier, startY, squareSize, squareSize);
                    grid.Add(square);
                }
                multiplier++;
            }
            for (int i = 0; i < 100; i++)
            {
                candies.Add(new Candy(random.Next(0, 4), counter, true));
                counter++;
            }
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {


            foreach (Rectangle rect in grid)
            {
                e.Graphics.DrawRectangle(whitePen, rect.X, rect.Y, rect.Height, rect.Width);
            }

            foreach (Candy candy in candies)
            {
                if (candy.candyVisible)
                {
                    // e.Graphics.DrawEllipse(whitePen, grid[candy.location]);
                    e.Graphics.FillEllipse(candy.typeBrush, grid[candy.location]);
                }
            }

            if (circleMoving)
            {
                foreach (Candy c in candies)
                {
                    if (c.location == gridLocation - 1)
                    {
                        c.candyVisible = false;
                        if (c.location - 10 < 0)
                        {
                            if (grid[c.location].X == 40)
                            {
                                if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos) || grid[c.location].Contains(Cxpos, Cypos))
                                {
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                    lastValidCxpos = lastCxpos;
                                    lastValidCypos = lastCypos;
                                    if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos))
                                    {
                                        if (!grid[c.location].Contains(Cxpos, Cypos))
                                        {
                                            swap = true;
                                        }
                                    }

                                }
                                else
                                {
                                    Cursor.Position = new Point(lastValidCxpos, lastValidCypos);
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                    Refresh();
                                }
                            }
                            else if (grid[c.location].X == 400)
                            {
                                if (grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos) || grid[c.location].Contains(Cxpos, Cypos))
                                {
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                    lastValidCxpos = lastCxpos;
                                    lastValidCypos = lastCypos;
                                    if (grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos))
                                    {
                                        if (!grid[c.location].Contains(Cxpos, Cypos))
                                        {
                                            swap = true;
                                        }
                                    }

                                }
                                else
                                {
                                    Cursor.Position = new Point(lastValidCxpos, lastValidCypos);
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                    Refresh();
                                }
                            }
                            if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos) || grid[c.location].Contains(Cxpos, Cypos))
                            {
                                e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                lastValidCxpos = lastCxpos;
                                lastValidCypos = lastCypos;
                                if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos))
                                {
                                    if (!grid[c.location].Contains(Cxpos, Cypos))
                                    {
                                        swap = true;
                                    }
                                }

                            }
                            else
                            {
                                Cursor.Position = new Point(lastValidCxpos, lastValidCypos);
                                e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                Refresh();
                            }
                        }
                        else if (c.location + 10 > 100)
                        {
                            if (grid[c.location].X == 40)
                            {
                                if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location - 10].Contains(Cxpos, Cypos) || grid[c.location].Contains(Cxpos, Cypos))
                                {
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                    lastValidCxpos = lastCxpos;
                                    lastValidCypos = lastCypos;
                                    if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location - 10].Contains(Cxpos, Cypos))
                                    {
                                        if (!grid[c.location].Contains(Cxpos, Cypos))
                                        {
                                            swap = true;
                                        }
                                    }

                                }
                                else
                                {
                                    Cursor.Position = new Point(lastValidCxpos, lastValidCypos);
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                    Refresh();
                                }
                            }
                            else if (grid[c.location].X == 400)
                            {
                                if (grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location - 10].Contains(Cxpos, Cypos) || grid[c.location].Contains(Cxpos, Cypos))
                                {
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                    lastValidCxpos = lastCxpos;
                                    lastValidCypos = lastCypos;
                                    if (grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location - 10].Contains(Cxpos, Cypos))
                                    {
                                        if (!grid[c.location].Contains(Cxpos, Cypos))
                                        {
                                            swap = true;
                                        }
                                    }

                                }
                                else
                                {
                                    Cursor.Position = new Point(lastValidCxpos, lastValidCypos);
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                    Refresh();
                                }
                            }
                            else if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location - 10].Contains(Cxpos, Cypos) || grid[c.location].Contains(Cxpos, Cypos))
                            {
                                e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                lastValidCxpos = lastCxpos;
                                lastValidCypos = lastCypos;
                                if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location - 10].Contains(Cxpos, Cypos))
                                {
                                    if (!grid[c.location].Contains(Cxpos, Cypos))
                                    {
                                        swap = true;
                                    }
                                }

                            }
                            else
                            {
                                Cursor.Position = new Point(lastValidCxpos, lastValidCypos);
                                e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                Refresh();
                            }
                        }
                        else
                        {
                            if (grid[c.location].X == 40)
                            {
                                if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location - 10].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos) || grid[c.location].Contains(Cxpos, Cypos))
                                {
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                    lastValidCxpos = lastCxpos;
                                    lastValidCypos = lastCypos;
                                    if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos))
                                    {
                                        if (!grid[c.location].Contains(Cxpos, Cypos))
                                        {
                                            swap = true;
                                        }
                                    }

                                }
                                else
                                {
                                    Cursor.Position = new Point(lastValidCxpos, lastValidCypos);
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                    Refresh();
                                }
                            }
                            else if (grid[c.location].X == 400)
                            {
                                if (grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos) || grid[c.location].Contains(Cxpos, Cypos))
                                {
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                    lastValidCxpos = lastCxpos;
                                    lastValidCypos = lastCypos;
                                    if (grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos))
                                    {
                                        if (!grid[c.location].Contains(Cxpos, Cypos))
                                        {
                                            swap = true;
                                        }
                                    }

                                }
                                else
                                {
                                    Cursor.Position = new Point(lastValidCxpos, lastValidCypos);
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                    Refresh();
                                }
                            }
                            if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos) || grid[c.location - 10].Contains(Cxpos, Cypos) || grid[c.location].Contains(Cxpos, Cypos))
                            {
                                e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                lastValidCxpos = lastCxpos;
                                lastValidCypos = lastCypos;
                                if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos) || grid[c.location - 10].Contains(Cxpos, Cypos))
                                {
                                    if (!grid[c.location].Contains(Cxpos, Cypos))
                                    {
                                        swap = true;
                                    }
                                }

                            }
                            else
                            {
                                Cursor.Position = new Point(lastValidCxpos, lastValidCypos);
                                e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                Refresh();
                            }
                        }
                        if (swap)
                        {
                            foreach (Rectangle rect in grid)
                            {
                                if (rect.Contains(lastValidCxpos,lastValidCypos) &! grid[c.location].Contains(lastValidCxpos, lastValidCypos))
                                {
                                    e.Graphics.FillEllipse(candies[counter3].typeBrush, grid[c.location]);
                                    candies[counter3].candyVisible = false;
                                }
                                counter3++;
                                if (grid[c.location].Contains(lastValidCxpos, lastValidCypos))
                                {
                                    candies[counter3].candyVisible = true;
                                }

                            }
                            counter3 = 0;
                        }
                    }
                }
            }




        }

        private void GameScreen_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            counter2 = 0;

            foreach (Rectangle rect in grid)
            {
                if (rect.Contains(Cxpos, Cypos))
                {
                    gridLocation = counter2 + 1;
                    break;
                }
                counter2++;
            }
        }

        private void GameScreen_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            circleMoving = false;
            // counter2 = 0;
        }

        private void GameScreen_MouseMove(object sender, MouseEventArgs e)
        {
            Cxpos = Cursor.Position.X;
            Cypos = Cursor.Position.Y;
            if (mouseDown && counter2 - 1 > -1)
            {
                circleMoving = true;
            }

            PointF mousePosition = this.PointToClient(Cursor.Position);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            lastCxpos = Cxpos;
            lastCypos = Cypos;

            Refresh();
        }
    }
}
