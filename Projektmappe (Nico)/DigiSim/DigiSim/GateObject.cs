using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigiSim
{
    class GateObject
    {
        //Attribute
        double xPosition;
        double yPosition;
        double lenght;
        double width;
        int inputs;
        int outputs;
        System.Collections.ArrayList allPins = new System.Collections.ArrayList();

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
        public System.Collections.ArrayList getPins()
        {
            return allPins;
        }
    }
}
