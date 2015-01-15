using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DigiSim
{
    [Serializable]
    class GateObject
    {
        //Attribute
        protected double xPosition;
        protected double yPosition;
        protected double height;
        protected double width;
        protected int inputs;
        protected int outputs;
        protected Pin[] allPins;
        public GateObject()
        {
        }
        //Konstruktor für die Initialiserung und Zeichnung des Obejktes
        public GateObject(double xPosition, double yPosition)
        {
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }
        //Methode um die aktuelle Position zu ändern
        public void ChangePosition(double xPosition, double yPosition)
        {
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }
        public void deleteMe()
        {
          for(int i = 0;i<allPins.Length;i++)
          {
            allPins[i].setOccupied(false);
          }
        }
        public int[] getPosition()
        {
            int[] Rückgabe = new int[4];
            //1. Place = x-Position
            Rückgabe[0] = Convert.ToInt32(xPosition);
            //2. Place = y-Position
            Rückgabe[1] = Convert.ToInt32(yPosition);
            //3. Place = width
            Rückgabe[2] = Convert.ToInt32(width);
            //4. Place = height
            Rückgabe[3] = Convert.ToInt32(height);
            return Rückgabe;

        }
        public bool search(Point p)
        {
            //look if the point is on the switch. If yes , change the state
            for (int y = Convert.ToInt32(yPosition); y <= yPosition + height +60; y++)
            {
                for (int x = Convert.ToInt32(xPosition); x <= xPosition + width +15; x++)
                {
                    if (p.X == x && p.Y == y)
                    {
                        return true;
                    }
                }

            }
            return false;
        }
        //Methode für die Änderung der Eingänge
        public void ChangeInput(int Anzahl)
        {
            inputs = Anzahl;
        }
        //Zurückgeben der eignen Pins
        public Pin[] getPins()
        {
            return allPins;
        }
        public void setPins(Pin[] Übergabe)
        {
            allPins = Übergabe;
        }

        public bool searchPin(Point search,ref Connection toEstablishConnection)
        {
            for (int i = 0; i < allPins.Length; i++)
            {
                int[] currentPosition = allPins[i].getPosition();
                Point PinPoint = new Point();
                PinPoint.X = currentPosition[0] +15;
                PinPoint.Y = currentPosition[1] +60;
                Point PinCopy = new Point();
                PinCopy.X = PinPoint.X;
                PinCopy.Y = PinPoint.Y;
                for (int y = PinPoint.Y; y <= currentPosition[3] + PinPoint.Y; y++)
                {
                    for (int x = PinPoint.X; x <= currentPosition[2] + PinPoint.X; x++)
                    {
                        if (PinCopy == search)
                        {
                          //look if the pin is a input or output and check if there is now other Pin selected for the connection
                          if(allPins[i].getSetting() &&toEstablishConnection.haveInput() == false)
                          {
                            //set the pin as occupied
                            allPins[i].setOccupied(true);
                            allPins[i].setSelected(true);
                            toEstablishConnection.setInputPin(ref allPins[i]);
                            return true;
                          }
                          if(allPins[i].getSetting() == false && toEstablishConnection.haveOutput() == false)
                          {
                            //set the pin as occupied and set him as outputpin for connection
                            allPins[i].setSelected(true);
                            allPins[i].setOccupied(true);
                            toEstablishConnection.setOutputPin(ref allPins[i]);
                            return true;
                          }
                          return true;
                        }
                        PinCopy.X += 1;
                    }
                    PinCopy.Y += 1;
                    PinCopy.X = PinPoint.X;
                }
            }
            return false;
        }
    }

}
