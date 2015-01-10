using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DigiSim
{
    class GND:GateObject
    {
      //Konstruktor
      public GND(double xPosition, double yPosition):base(xPosition,yPosition)
      {
        //Set pin and create one
        inputs = 0;
        outputs = 1;
        //set height and width
        width = 60;
        height = 30;
        Pin first = new Pin(false);
        allPins = new Pin[1];
        allPins[0] = first;
      }
      public void outen()
      {
          allPins[0].setState(false);
      }
      public void draw(ref Graphics g)
      {
          //draw the rectangle for the GND
        Point p = new Point();
        p.X = Convert.ToInt32(xPosition);
        p.Y = Convert.ToInt32(yPosition);
        Size s = new Size();
        s.Height = Convert.ToInt32(height);
        s.Width = Convert.ToInt32(width);
        g.DrawRectangle(Pens.Black, new Rectangle(p, s));
        //now make the font
        //draw the font
        p.X = Convert.ToInt32(xPosition + (width / 2) - 25);
        p.Y = Convert.ToInt32(yPosition + (height / 2) - 12);
        string VC = "GND";
        g.DrawString(VC, new Font(SystemFonts.DefaultFont, FontStyle.Regular), Brushes.Black, p);
        //Draw the output-Pin
        p.X = Convert.ToInt32(xPosition + width);
        p.Y = Convert.ToInt32(yPosition + (height / 2) - 5);
        allPins[0].draw(Convert.ToDouble(p.X), Convert.ToDouble(p.Y), ref g);
      }
    }

}
