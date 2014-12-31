using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DigiSim
{
    class Pin
    {
        //Attribute
        bool setting;
        bool state;
        bool occupied;
        double xPosition;
        double yPosition;
        double height = 10;
        double width =10;

        //Konstruktor welcher abfragt, ob es sich um einen Input oder Output handelt (true = Input)(false = Output)
        public Pin(bool setting)
        {
          this.setting = setting;
          occupied = false;
        }
        public bool getSetting()
        {
          return setting;
        }
        public bool getState()
        {
          return state;
        }
        public void setState(bool state)
        {
          this.state = state;
        }
        public bool getOccupied()
        {
          return occupied;
        }
        public void setOccupied(bool state)
        {
          occupied = state;
        }
        public double[] getPosition()
        {
            double[] Rückgabe = new double[4];
            Rückgabe[0] = xPosition;
            Rückgabe[1] = yPosition;
            Rückgabe[2] = height;
            Rückgabe[3] = width;
            return Rückgabe;
        }
        public  void  draw(double xPosition,double yPosition,ref Graphics g)
        {
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            Point p = new Point();
            p.X = Convert.ToInt32(xPosition);
            p.Y = Convert.ToInt32(yPosition);
            Size s = new Size();
            s.Height = Convert.ToInt32(height);
            s.Width = Convert.ToInt32(width);
            g.FillEllipse(Brushes.Black, new Rectangle(p, s));
        }

    }
}
