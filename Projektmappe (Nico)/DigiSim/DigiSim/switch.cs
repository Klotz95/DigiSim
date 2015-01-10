using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DigiSim
{
    class Cswitch:GateObject
    {
        //Attribute
        bool state;
        //Konstruktor
        public Cswitch(double xPosition, double yPosition):base(xPosition,yPosition)
        {
          //set the correct input/outputs
          outputs = 1;
          inputs = 0;
            //set height and width
          height = 50;
          width = 50;
          //Create the output Pin
          Pin first = new Pin(false);
          allPins = new Pin[1];
          allPins[0] = first;
          //turn the switch off
          state = false;

        }
        public void ChangeState()
        {
            state = !state;
        }
        public bool refresh()
        {
          //set the outputpin to the state of the button
            if (allPins[0].getState() != state)
            {
                allPins[0].setState(state);
                return true;
            }
            allPins[0].setState(state);
            return false;

        }
        public bool searchSwitch(Point p)
        {
            //look if the point is on the switch. If yes , change the state
            for (int y = Convert.ToInt32(yPosition); y <= yPosition + height; y++)
            {
                for (int x = Convert.ToInt32(xPosition); x <= xPosition + width; x++)
                {
                    if (p.X == x && p.Y == y)
                    {
                        this.ChangeState();
                        return true;
                    }
                }
 
            }
            return false;
        }
        public void draw(ref Graphics g)
        {
            Point Start = new Point();
            Start.X = Convert.ToInt32(xPosition);
            Start.Y = Convert.ToInt32(yPosition);
            Size firstPin = new Size();
            firstPin.Width = 5;
            firstPin.Height = 5;
            //check the state
            if (state)
            {
                //now the switch is closed
                g.FillEllipse(Brushes.Black, new Rectangle(Start, firstPin));
                Start.X = Start.X + 5;
                Start.Y = Start.Y + 2;
                Point Ende = new Point();
                Ende.X = Start.X + 50;
                Ende.Y = Start.Y;
                g.DrawLine(Pens.Black, Start, Ende);
                
                
            }
            else
            {
                //now the switch is open
                g.FillEllipse(Brushes.Black, new Rectangle(Start, firstPin));
                Start.X = Start.X + 5;
                Start.Y = Start.Y + 2;
                Point Ende = new Point();
                Ende.X = Start.X + 50;
                Ende.Y = Start.Y - 30;
                g.DrawLine(Pens.Black, Start, Ende);

            }
            //draw the pin
            Start.X = Start.X + 50;
            Start.Y = Start.Y - 5;
            allPins[0].draw(Convert.ToDouble(Start.X), Convert.ToDouble(Start.Y), ref g);
        }

    }
}
