using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DigiSim
{
  class Not:GateObject
  {
    public Not(double xPosition, double yPosition):base(xPosition,yPosition)
    {
      //set the counts
        inputs = 1;
      outputs = 1;
        //Set width and height
      width = 60;
      height = 100;
      //create the pins and fill the array
      Pin firstInput = new Pin(true);
      Pin firstOutput = new Pin(false);
      allPins = new Pin[2];
      allPins[0] = firstOutput;
      allPins[1] = firstInput;
    }
    public void refresh()
    {
      //look for input and set the output
      if(allPins[1].getState())
      {
        allPins[0].setState(false);
      }
      else
      {
        allPins[0].setState(true);
      }
    }
    public void draw(ref Graphics g)
    {
        //draw the rectangle
        Point p = new Point();
        p.X = Convert.ToInt32(xPosition);
        p.Y = Convert.ToInt32(yPosition);
        Size s = new Size();
        s.Height = Convert.ToInt32(height);
        s.Width = Convert.ToInt32(width);
        g.DrawRectangle(Pens.Black, new Rectangle(p, s));
        //draw the Font
        p.X = Convert.ToInt32(xPosition + (width / 2) - 10);
        p.Y = Convert.ToInt32(yPosition + (height / 2) -10);
        string Not = "1";
        g.DrawString(Not, new Font(SystemFonts.DefaultFont, FontStyle.Regular), Brushes.Black, p);
        //now draw the input and output Pin
        //draw the input 
        p.Y = Convert.ToInt32(yPosition + (height / 2) - 5);
        p.X = Convert.ToInt32(xPosition - 10);
        allPins[1].draw(Convert.ToDouble(p.X), Convert.ToDouble(p.Y), ref g);
        //draw the output
        p.X = Convert.ToInt32(p.X + width + 10);
        allPins[0].draw(Convert.ToDouble(p.X), Convert.ToDouble(p.Y), ref g);

    }
  }
}
