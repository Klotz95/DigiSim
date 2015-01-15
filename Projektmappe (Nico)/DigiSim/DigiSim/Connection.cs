using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DigiSim
{
    [Serializable]
    class Connection
    {
      //Attribute
      Pin Inputpin;
      Pin Outputpin;
      bool state;
      //Konstruktor
      public Connection()
      {
        state = false;
      }
      public void draw(ref Graphics g)
      {
          //create the two points
          Point p1 = new Point();
          Point p2 = new Point();
          p1.X = Outputpin.getPosition()[0];
          p1.Y = Outputpin.getPosition()[1];
          p2.X = Inputpin.getPosition()[0];
          p2.Y = Inputpin.getPosition()[1];
          //prepare the points for calculating
          p1.X += 10;
          p1.Y += 5;
          p2.Y += 5;
          //calculate the x and y movings for the line
          int x = p2.X - p1.X;
          x = x/2;
          int y = p1.Y - p2.Y;
          //now draw the lines
          if (state)
          {
              g.DrawLine(Pens.Red, p1, new Point(p1.X + x, p1.Y));
              g.DrawLine(Pens.Red, new Point(p1.X + x, p1.Y), new Point(p1.X + x, p1.Y - y));
              g.DrawLine(Pens.Red, new Point(p1.X + x, p1.Y - y), p2);
          }
          else
          {
              g.DrawLine(Pens.Black, p1, new Point(p1.X + x, p1.Y));
              g.DrawLine(Pens.Black, new Point(p1.X + x, p1.Y), new Point(p1.X + x, p1.Y - y));
              g.DrawLine(Pens.Black, new Point(p1.X + x, p1.Y - y), p2);
          }
      }
      public void deleteSelection()
      {
          Inputpin.setSelected(false);
          Outputpin.setSelected(false);
      }
      public bool statedelivery()
      {
          //set the state of the inputpin
          if (Outputpin.getState())
          {
              //Input = 1
              Inputpin.setState(true);
              if (state != true)
              {
                  state = true;
                  return true;
              }
              return false;
          }
          else
          {
              //Input = 0
              Inputpin.setState(false);
              if (state != false)
              {
                  state = false;
                  return true;
              }
              return false;
          }
      }
      public void setInputPin(ref Pin Input)
      {
          Inputpin = Input;
      }
      public void setOutputPin(ref Pin Output)
      {
          Outputpin = Output;
      }
      public bool haveInput()
      {
          if (Inputpin != null)
          {
              return true;
          }
          return false;
      }
      public bool haveOutput()
      {
          if (Outputpin != null)
          {
             return true;
          }
          return false;
      }
      public bool checkExistence()
      {
        if(Inputpin.getOccupied() && Outputpin.getOccupied())
        {
          return true;
        }
        else
        {
          return false;
        }
      }


    }
}
