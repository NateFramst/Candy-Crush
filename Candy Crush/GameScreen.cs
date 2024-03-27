//Does not work
//issue is beyond me
//this was way to difficult for the time I had, unbeknownst to me
//despite that, it's something



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

        //candy lists
        List<Candy> candies = new List<Candy>();

        List<Candy> candiesBackup = new List<Candy>();

        List<Candy> candies3 = new List<Candy>();

        List<Rectangle> grid = new List<Rectangle>();

       //variables
        bool mouseDown, mouseUp;

        bool circleMoving = false;

        bool swap;

        bool addCandies = true;

        int counter, counter2, counter3, counter4;

        int startX = 0;
        int startY = 0;
        int squareSize = 40;
        int multiplier = 1;

        int Cxpos;
        int Cypos;

        int copy;


        int lastCxpos, lastCypos;
        int lastValidCxpos, lastValidCypos;

        int gridLocation;
        //randoms
        Random random = new Random();

        //pens
        Pen whitePen = new Pen(Color.White);

        public GameScreen()
        {
            InitializeComponent();
            GameInitialize();
        }

        //exit code
        private void GameScreen_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Form1.escDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Form1.escDown = false;
                    break;
            }
        }

        // set up screen
        void GameInitialize()
        {
            //each grid square is 30 pixels X 30 pixels
            //make grid
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
            //add candies
            for (int i = 0; i < 100; i++)
            {
                candies.Add(new Candy(random.Next(0, 4), counter, true));
                counter++;
            }
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //drawGrid
            foreach (Rectangle rect in grid)
            {
                e.Graphics.DrawRectangle(whitePen, rect.X, rect.Y, rect.Height, rect.Width);
            }
            //drawCandies
            if (addCandies)
            {
                foreach (Candy candy in candies)
                {
                    if (candy.candyVisible)
                    {
                        // e.Graphics.DrawEllipse(whitePen, grid[candy.location]);
                        e.Graphics.FillEllipse(candy.typeBrush, grid[candy.location]);
                    }
                }
            }
            else if (addCandies == false)
            {
                foreach (Candy candy in candiesBackup)
                {
                    if (candy.candyVisible)
                    {
                        // e.Graphics.DrawEllipse(whitePen, grid[candy.location]);
                        e.Graphics.FillEllipse(candy.typeBrush, grid[candy.location]);
                    }
                }
            }

            //if moving a candy
            if (circleMoving)
            {
                foreach (Candy c in candies)
                {
                    //if candy is in selected area
                    if (c.location == gridLocation - 1)
                    {
                        c.candyVisible = false;
                        //if in first row
                        if (c.location - 10 < 0)
                        {
                            //if in left row
                            if (grid[c.location].X == 40)
                            {
                                //if mouse is in the allowed squares
                                if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos) || grid[c.location].Contains(Cxpos, Cypos))
                                {
                                    //draw mon=ving candy
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                    //set valid cursor positions 
                                    lastValidCxpos = lastCxpos;
                                    lastValidCypos = lastCypos;
                                    //check allowed squares
                                    if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos))
                                    {
                                        //if not orginal square
                                        if (!grid[c.location].Contains(Cxpos, Cypos))
                                        {
                                            swap = true;
                                        }
                                    }

                                }
                                else
                                {
                                    //set back to valid position
                                    Cursor.Position = new Point(lastValidCxpos, lastValidCypos);
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));

                                }
                            }
                            // if in right row
                            else if (grid[c.location].X == 400)
                            {
                                //if in allowed squares
                                if (grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos) || grid[c.location].Contains(Cxpos, Cypos))
                                {
                                    //draw moving candy
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                    //set valid cursor positions
                                    lastValidCxpos = lastCxpos;
                                    lastValidCypos = lastCypos;
                                    //if in allowed squares
                                    if (grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos))
                                    {
                                        //if not in origianl square
                                        if (!grid[c.location].Contains(Cxpos, Cypos))
                                        {
                                            swap = true;
                                        }
                                    }
                                }
                                else
                                {
                                    //set back to valid posistion
                                    Cursor.Position = new Point(lastValidCxpos, lastValidCypos);
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));

                                }
                            }
                            //if in middle of row
                            if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos) || grid[c.location].Contains(Cxpos, Cypos))
                            {
                                //draw moving candy
                                e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                //set valid cursor position 
                                lastValidCxpos = lastCxpos;
                                lastValidCypos = lastCypos;
                                // if in allowed squares
                                if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos))
                                {
                                    // if not in original square
                                    if (!grid[c.location].Contains(Cxpos, Cypos))
                                    {
                                        swap = true;
                                    }
                                }

                            }
                            else
                            {
                                //set back to valid position
                                Cursor.Position = new Point(lastValidCxpos, lastValidCypos);
                                e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                            }
                        }
                        //if in bottom row
                        else if (c.location + 10 > 100)
                        {
                            //if in left row
                            if (grid[c.location].X == 40)
                            {
                                //if in allowed squares
                                if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location - 10].Contains(Cxpos, Cypos) || grid[c.location].Contains(Cxpos, Cypos))
                                {
                                    //draw moving cirlces 
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                    //set valid cursor positions
                                    lastValidCxpos = lastCxpos;
                                    lastValidCypos = lastCypos;
                                    //if in allowed squares
                                    if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location - 10].Contains(Cxpos, Cypos))
                                    {
                                        //if not in original square
                                        if (!grid[c.location].Contains(Cxpos, Cypos))
                                        {
                                            swap = true;
                                        }
                                    }

                                }
                                else
                                {
                                    //set back to original position
                                    Cursor.Position = new Point(lastValidCxpos, lastValidCypos);
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                }
                            }
                            //if in right row
                            else if (grid[c.location].X == 400)
                            {
                                //if in allowed squares
                                if (grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location - 10].Contains(Cxpos, Cypos) || grid[c.location].Contains(Cxpos, Cypos))
                                {
                                    //draw moving candy
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                    //set valid cursor position
                                    lastValidCxpos = lastCxpos;
                                    lastValidCypos = lastCypos;
                                    //if in allowed squares
                                    if (grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location - 10].Contains(Cxpos, Cypos))
                                    {
                                        //if not in original square
                                        if (!grid[c.location].Contains(Cxpos, Cypos))
                                        {
                                            swap = true;
                                        }
                                    }

                                }
                                else
                                {
                                    //set valid positoins 
                                    Cursor.Position = new Point(lastValidCxpos, lastValidCypos);
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                }
                            }
                            //if in middle of row
                            else if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location - 10].Contains(Cxpos, Cypos) || grid[c.location].Contains(Cxpos, Cypos))
                            {
                                //draw moivng candy
                                e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                //set valid cursor positions 
                                lastValidCxpos = lastCxpos;
                                lastValidCypos = lastCypos;
                                //if in valid positions
                                if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location - 10].Contains(Cxpos, Cypos))
                                {
                                    //if not in original square
                                    if (!grid[c.location].Contains(Cxpos, Cypos))
                                    {
                                        swap = true;
                                    }
                                }

                            }
                            else
                            {
                                //set back to valid posisiton 
                                Cursor.Position = new Point(lastValidCxpos, lastValidCypos);
                                e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                            }
                        }
                        //if in middle of the grid area
                        else
                        {
                            //if in left row
                            if (grid[c.location].X == 40)
                            {
                                //if in allowed squares
                                if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location - 10].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos) || grid[c.location].Contains(Cxpos, Cypos))
                                {
                                    //draw moving candy
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                    //set valid cursor postions
                                    lastValidCxpos = lastCxpos;
                                    lastValidCypos = lastCypos;
                                    //if in allowewd squares
                                    if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos))
                                    {
                                        //if not in original square
                                        if (!grid[c.location].Contains(Cxpos, Cypos))
                                        {
                                            swap = true;
                                        }
                                    }

                                }
                                else
                                {//set to valid position
                                    Cursor.Position = new Point(lastValidCxpos, lastValidCypos);
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                }
                            }
                            //if in right row
                            else if (grid[c.location].X == 400)
                            {
                                //if in valid positions
                                if (grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos) || grid[c.location].Contains(Cxpos, Cypos))
                                {
                                    //draw moving candy
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                    //set valid cursor postion
                                    lastValidCxpos = lastCxpos;
                                    lastValidCypos = lastCypos;
                                    //if in allowed squares
                                    if (grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos))
                                    {
                                        //if not in orignial square
                                        if (!grid[c.location].Contains(Cxpos, Cypos))
                                        {
                                            swap = true;
                                        }
                                    }

                                }
                                else
                                {
                                    //set back to valid cursor positsiton
                                    Cursor.Position = new Point(lastValidCxpos, lastValidCypos);
                                    e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                }
                            }
                            //if in middle of grid
                            if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos) || grid[c.location - 10].Contains(Cxpos, Cypos) || grid[c.location].Contains(Cxpos, Cypos))
                            {
                                //draw movign candy
                                e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                                //set valid cursor postion
                                lastValidCxpos = lastCxpos;
                                lastValidCypos = lastCypos;
                                //if in allowed squares
                                if (grid[c.location + 1].Contains(Cxpos, Cypos) || grid[c.location - 1].Contains(Cxpos, Cypos) || grid[c.location + 10].Contains(Cxpos, Cypos) || grid[c.location - 10].Contains(Cxpos, Cypos))
                                {
                                    //if not in original square
                                    if (!grid[c.location].Contains(Cxpos, Cypos))
                                    {
                                        swap = true;
                                    }
                                }

                            }
                            else
                            {
                                //set to valid cursor position
                                Cursor.Position = new Point(lastValidCxpos, lastValidCypos);
                                e.Graphics.FillEllipse(c.typeBrush, new Rectangle((Cxpos - 20), (Cypos - 20), 40, 40));
                            }
                        }
                        //if candy should be moved
                        if (swap)
                        {
                            foreach (Rectangle rect in grid)
                            {
                                //if cursor is in a rectangle other than original
                                if (rect.Contains(lastValidCxpos, lastValidCypos) & !grid[c.location].Contains(lastValidCxpos, lastValidCypos))
                                {
                                    //draw swaped candies
                                    e.Graphics.FillEllipse(candies[counter3].typeBrush, grid[c.location]);
                                    candies[counter3].candyVisible = false;
                                }
                                counter3++;
                                //draw other candy
                                if (grid[c.location].Contains(Cxpos, Cypos))
                                {
                                    candies[counter3 - 1].candyVisible = true;
                                }

                            }
                            counter3 = 0;
                        }
                    }
                }

            }
            if (mouseUp)
            {
                //stuff
            }
        }

        private void GameScreen_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseUp = false;
            counter2 = 0;
            //set grid square clicked
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
            mouseUp = true;
            candiesBackup.Clear();
            candies3.Clear();
            //set copies of candy list
            for (int m = 0; m < 100; m++)
            {
                candiesBackup.Add(candies[m]);
                candies3.Add(candies[m]);
            }
 
            //check grid
            foreach (Rectangle r in grid)
            {
                
                int gridlocationNew = gridLocation - 1;
                //is cursor release in a grid square, not orignial
                if (r.Contains(lastValidCxpos, lastValidCypos) && !grid[gridlocationNew].Contains(lastValidCxpos, lastValidCypos))
                {
                    //check thru candies
                    for (int i = 0; i < 100; i++)
                    {
                        //if candy is in correct square
                        if (candies[i].location == counter4)
                        {
                            //switch candy location in cursor square to original square
                            candies[i].location = gridlocationNew;// - (gridlocationNew - counter4);
                            //make visible
                            candies[i].candyVisible = true;
                            //send new locatoin to copy list one
                            candiesBackup[i] = candies[i];
                            //switch candy location in origianl square to cursor square location
                            candies[gridlocationNew].location = i; //gridlocationNew - (gridlocationNew - counter4);
                            //set visible
                            candies[gridlocationNew].candyVisible = true;
                            //send new location to copy list two
                            candies3[gridlocationNew] = candies[gridlocationNew];
                            //combine the lists
                            candiesBackup[gridlocationNew] = candies3[gridlocationNew];
                            //new draw type
                            addCandies = false;
                            //clear candies 
                            candies.Clear();
                            //re add new list to candy
                            for (int k = 0; k < 100; k++)
                            {
                                candies.Add(new Candy(candiesBackup[k].type, k, true));
                                //candies.Add(candiesBackup[k]);
                                
                            }
                            Refresh();
                            break;
                        }
                    }
                }
                //keep track of square in grid
                counter4++;
            }
            counter4 = 0;
        }

        private void GameScreen_MouseMove(object sender, MouseEventArgs e)
        {
            //cursor position
            Cxpos = Cursor.Position.X;
            Cypos = Cursor.Position.Y;
            //check if mouse moving
            if (mouseDown && counter2 - 1 > -1)
            {
                circleMoving = true;
            }

            //PointF mousePosition = this.PointToClient(Cursor.Position);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //cursor check
            lastCxpos = Cxpos;
            lastCypos = Cypos;

            //exit code
            if (Form1.escDown)
            {
                Application.Exit();
            }
            Refresh();
        }
    }
}
