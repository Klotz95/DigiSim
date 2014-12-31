using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigiSim
{
    class GateObject
    {
        //Attribute
        public double xPosition;
        public double yPosition;
        public double height;
        public double width;
        public int inputs;
        public int outputs;
        public Pin[] allPins;

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
    }
}
