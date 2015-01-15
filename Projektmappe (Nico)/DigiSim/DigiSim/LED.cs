using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DigiSim
{
    [Serializable]
    class LED : GateObject
    {
        //attributs
        bool light = false;
        public LED(double xPosition, double yPosition)
            : base(xPosition, yPosition)
        {
            //set inputs and outputs count
            inputs = 1;
            outputs = 0;
            width = 50;
            height = 50;
            //create pin and fill the array with it
            Pin firstInput = new Pin(true);
            allPins = new Pin[1];
            allPins[0] = firstInput;
        }
        public bool refresh()
        {
            //look if input = 1 or input = 0 and turn off/turn on the light
            if(allPins[0].getState() != light)
            {
              light = allPins[0].getState();
              return true;
            }
            return false;
        }
        public void draw(ref Graphics g)
        {
            //look whether the lamp is on or off
            //make the varaibles for the drawing
            Point p = new Point();
            p.X = Convert.ToInt32(xPosition);
            p.Y = Convert.ToInt32(yPosition);
            Size s = new Size();
            s.Width = Convert.ToInt32(width);
            s.Height = Convert.ToInt32(height);
            if (light)
            {
                g.FillEllipse(Brushes.OrangeRed,new Rectangle(p,s));
                //first line
                Point Start = new Point();
                Start.X = Convert.ToInt32(xPosition + (width / 6));
                Start.Y = Convert.ToInt32(yPosition + (height / 6));
                Point Ende = new Point();
                Ende.X = Convert.ToInt32(xPosition + width - (width / 6));
                Ende.Y = Convert.ToInt32(yPosition + height - (height / 6));
                g.DrawLine(Pens.Black, Start, Ende);
                //Second line
                Start.X = Convert.ToInt32(xPosition + (width / 6));
                Start.Y = Convert.ToInt32(yPosition + height - (height / 6));
                Ende.X = Convert.ToInt32(xPosition + width - (width / 6));
                Ende.Y = Convert.ToInt32(yPosition + (height / 6));
                g.DrawLine(Pens.Black, Start, Ende);

            }
            else
            {
                g.FillEllipse(Brushes.Gray, new Rectangle(p, s));
                Point Start = new Point();
                //first line
                Start.X = Convert.ToInt32(xPosition + (width/6));
                Start.Y = Convert.ToInt32(yPosition + (height/6));
                Point Ende = new Point();
                Ende.X = Convert.ToInt32(xPosition +width - (width/6));
                Ende.Y = Convert.ToInt32(yPosition +height - (height/6));
                g.DrawLine(Pens.Black, Start, Ende);
                //Second line
                Start.X = Convert.ToInt32(xPosition + (width/6));
                Start.Y = Convert.ToInt32(yPosition + height - (height/6));
                Ende.X = Convert.ToInt32(xPosition + width - (width/6) );
                Ende.Y = Convert.ToInt32(yPosition +(height/6));
                g.DrawLine(Pens.Black, Start, Ende);

            }
            //now draw the input-Pin
            int xPinKordinate = Convert.ToInt32(xPosition - 10);
            int yPinKordinate = Convert.ToInt32(yPosition + (height/2) - (10/2));
            allPins[0].draw(xPinKordinate, yPinKordinate, ref g);
        }
    }
}
