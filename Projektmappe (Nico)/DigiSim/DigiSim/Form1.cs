using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DigiSim
{
    public partial class Form1 : Form
    {
        //Attributs: Arrays of all possible Gates and Connections
        Cswitch[] switches = new Cswitch[0];
        GND[] GNDS = new GND[0];
        OrGate[] Ors = new OrGate[0];
        Not[] Nots = new Not[0];
        LED[] LEDS = new LED[0];
        AndGate[] Ands = new AndGate[0];
        Connection[] Connections = new Connection[0];
        VCC[] VCCS = new VCC[0];
        Connection toEstablishConnection = new Connection();
        Point currentMousePosition;
        ChangeInput currentChangeInput;
        
        bool needraw = false;
        public Form1()
        {
            InitializeComponent();
        }
        public void refresh()
        {
            //look if theres a new Connection
            if (toEstablishConnection.haveInput() && toEstablishConnection.haveOutput())
            {
                //save the current Connection Array
                Connection[] savedConnections = Connections;
                //search for nulls and count them
                int nullCount = 0;
                for(int i = 0;i<savedConnections.Length;i++)
                {
                  if(savedConnections[i] == null)
                  {
                    nullCount ++;
                  }
                }
                Connections = new Connection[savedConnections.Length +1 - nullCount];
                int index  = 0;
                int indexNew = 0;
                while(index<savedConnections.Length)
                {
                  if(savedConnections[index] != null)
                  {
                    Connections[indexNew] = savedConnections[index];
                    indexNew ++;
                  }
                  index ++;
                }
                Connections[Connections.Length - 1] = toEstablishConnection;
                toEstablishConnection = new Connection();
                needraw = true;
            }
            //now deliver the signals (repeat this progress as long as all connections could deliver their signal)
            for (int i = 0; i < Connections.Length + 1; i++)
            {
                bool drawing = false;
                for(int k = 0;k<Connections.Length;k++)
                {
                    if(Connections[k] != null)
                  {
                    bool excistence = Connections[k].checkExistence();
                    if(excistence)
                    {
                    drawing = Connections[k].statedelivery();
                    }
                    else
                    {
                      Connections[k] = null;
                    }
                  }
                }
                if (needraw != true)
                {
                    needraw = drawing;
                }

                //refresh everything
                //CSwitch
                foreach (Cswitch s in switches)
                {
                  if(s != null)
                  {
                    drawing = s.refresh();
                    if (needraw != true)
                    {
                        needraw = drawing;
                    }
                  }
                }
                //GND
                foreach (GND s in GNDS)
                {
                  if(s != null)
                  {
                    s.outen();
                  }
                }
                //OR
                foreach (OrGate s in Ors)
                {
                  if(s != null)
                  {
                    drawing = s.refresh();
                    if (needraw != true)
                    {
                        needraw = drawing;
                    }
                  }
                }
                //Not
                foreach (Not s in Nots)
                {
                  if(s != null)
                  {
                    s.refresh();
                  }
                }
                //LED
                foreach (LED s in LEDS)
                {
                  if(s != null)
                  {
                    drawing = s.refresh();
                    if (needraw != true)
                    {
                        needraw = drawing;
                    }
                  }
                }
                //And
                foreach (AndGate s in Ands)
                {
                  if(s != null)
                  {
                    drawing = s.refresh();
                    if (needraw != true)
                    {
                        needraw = drawing;
                    }
                  }
                }
                //VCC
                foreach (VCC s in VCCS)
                {
                    if (s != null)
                    {
                        s.outen();
                    }
                }
            }
                //look if graphical things have changed
                if (needraw)
                {
                    //clear all current drawings and redraw them
                    Graphics g = this.CreateGraphics();
                    g.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), new Size(Form1.ActiveForm.ClientSize.Width, Form1.ActiveForm.ClientSize.Height)));
                    //switches
                    foreach (Cswitch s in switches)
                    {
                      if(s != null)
                      {
                        s.draw(ref g);
                      }
                    }
                    //GNDs
                    foreach (GND s in GNDS)
                    {
                      if(s != null)
                      {
                        s.draw(ref g);
                      }
                    }
                    //Ors
                    foreach (OrGate s in Ors)
                    {
                      if(s != null)
                      {
                        s.draw(ref g);
                      }
                    }
                    //Nots
                    foreach (Not s in Nots)
                    {
                      if(s != null)
                      {
                        s.draw(ref g);
                      }
                    }
                    //LEDs
                    foreach (LED s in LEDS)
                    {
                      if(s != null)
                      {
                        s.draw(ref g);
                      }
                    }
                    //ANDs
                    foreach (AndGate s in Ands)
                    {
                      if (s!= null)
                      {
                        s.draw(ref g);
                      }
                    }
                    //VCCs
                    foreach (VCC s in VCCS)
                    {
                        if (s != null)
                        {
                          s.draw(ref g);
                        }
                    }
                    //Connections
                    foreach (Connection s in Connections)
                    {
                        if (s != null)
                        {
                            s.draw(ref g);
                        }
                    }

            }


        }



        private void Form1_Load(object sender, EventArgs e)
        {
            //Event-Handler for click
            this.Click += new EventHandler(Form1_Click);
            
          
        }


       

      

        void Form1_Click(object sender, EventArgs e)
        {
            //get MousePosition with  calculating
            Point ClientPosition = Form1.ActiveForm.Location;
            Point Mouse = MousePosition;
            Mouse.X = Mouse.X - ClientPosition.X;
            Mouse.Y = Mouse.Y - ClientPosition.Y;
            bool found = false;
            //GND
            for (int i = 0; i < GNDS.Length; i++)
            {
                //look for the ground Pins
              if(GNDS[i] != null)
              {
                found = GNDS[i].searchPin(Mouse,ref toEstablishConnection);
              }
            }
            //Or-Gate
            if (found != true)
            {
                for (int i = 0; i < Ors.Length; i++)
                {
                  if(Ors[i] != null)
                  {
                    found = Ors[i].searchPin(Mouse,ref toEstablishConnection);
                  }
                }
            }
            //Nots
            if (found != true)
            {
                for (int i = 0; i < Nots.Length; i++)
                {
                  if(Nots[i] != null)
                  {
                    found = Nots[i].searchPin(Mouse,ref toEstablishConnection);
                  }
                }
            }
            //LEDS
            if (found != true)
            {
                for (int i = 0; i < LEDS.Length; i++)
                {
                  if(LEDS[i] != null)
                  {
                    found = LEDS[i].searchPin(Mouse, ref toEstablishConnection);
                  }
                }
            }
            //And
            if (found != true)
            {
                for (int i = 0; i < Ands.Length; i++)
                {
                  if(Ands[i] != null)
                  {
                    found = Ands[i].searchPin(Mouse,ref  toEstablishConnection);
                  }
                }
            }
            //VCC
            if (found != true)
            {
                for (int i = 0; i < VCCS.Length; i++)
                {
                    if (VCCS[i] != null)
                    {
                        found = VCCS[i].searchPin(Mouse, ref toEstablishConnection);
                    }
                }
            }
            //switches PIN
            if (found != true)
            {
                for (int i = 0; i < switches.Length; i++)
                {
                  if(switches[i] != null)
                  {
                    found = switches[i].searchPin(Mouse,ref toEstablishConnection);
                  }
                }
            }
            //switches
            if (found != true)
            {
                for (int i = 0; i < switches.Length; i++)
                {
                  if(switches[i] != null)
                  {
                    found = switches[i].searchSwitch(Mouse);
                  }
                }
            }
            //now check if something had found and redraw
            if (found == true)
            {
                needraw = true;
            }
            refresh();



        }

        private void bewegenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //search for the right Object and delete it
            for (int i = 0; i < VCCS.Length; i++)
            {
                if (VCCS[i] != null)
                {
                    bool delete = VCCS[i].search(currentMousePosition);
                    if (delete == true)
                    {
                        VCCS[i].deleteMe();
                        VCCS[i] = null;
                        needraw = true;
                        refresh();
                    }
                }
            }
            //GND
            for(int i = 0; i< GNDS.Length;i++)
            {
              if(GNDS[i] != null)
              {
                bool delete = GNDS[i].search(currentMousePosition);
                if(delete == true)
                {
                  GNDS[i].deleteMe();
                  GNDS[i] = null;
                  needraw = true;
                  refresh();
                }
              }
            }
            //switches
            for(int i = 0;i<switches.Length;i++)
            {
              if(switches[i] != null)
              {
                bool delete = switches[i].search(currentMousePosition);
                if(delete == true)
                {
                  switches[i].deleteMe();
                  switches[i] = null;
                  needraw = true;
                  refresh();
                }
              }
            }
            //Ors
            for(int i = 0;i<Ors.Length;i++)
            {
              if(Ors[i] != null)
              {
                bool delete = Ors[i].search(currentMousePosition);
                if(delete == true)
                {
                  Ors[i].deleteMe();
                  Ors[i] = null;
                  needraw = true;
                  refresh();
                }
              }
            }
            //Nots
            for(int i = 0;i<Nots.Length;i++)
            {
              if(Nots[i] != null)
              {
                bool delete = Nots[i].search(currentMousePosition);
                if(delete == true)
                {
                  Nots[i].deleteMe();
                  Nots[i] = null;
                  needraw = true;
                  refresh();
                }
              }
            }
            //LEDS
            for(int i = 0;i<LEDS.Length;i++)
            {
              if(LEDS[i] != null)
              {
                bool delete = LEDS[i].search(currentMousePosition);
                if(delete == true)
                {
                  LEDS[i].deleteMe();
                  LEDS[i] = null;
                  needraw = true;
                  refresh();
                }
              }
            }
            //Ands
            for(int i = 0;i<Ands.Length;i++)
            {
              if(Ands[i] != null)
              {
                bool delete = Ands[i].search(currentMousePosition);
                if(delete == true)
                {
                  Ands[i].deleteMe();
                  Ands[i] = null;
                  needraw = true;
                  refresh();
                }
              }
            }

        }

        private void andGateToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //save the old Array and create a new one
          AndGate[] saved = Ands;
          int nullcount = 0;
          for(int i = 0;i<Ands.Length;i++)
          {
            if(Ands[i] == null)
            {
              nullcount ++;
            }
          }
          Ands = new AndGate[saved.Length +1 - nullcount];
          int indexSaved = 0;
          int indexVCCS = 0;
          while(indexSaved<saved.Length)
          {
            if(saved[indexSaved] != null)
            {
              Ands[indexVCCS] = saved[indexSaved];
              indexVCCS ++;
            }
            indexSaved ++;
          }
          Ands[Ands.Length - 1] = new AndGate(currentMousePosition.X, currentMousePosition.Y);
          needraw = true;
          refresh();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            //get MousePosition with  calculating
            Point ClientPosition = Form1.ActiveForm.Location;
            Point Mouse = MousePosition;
            Mouse.X = Mouse.X - ClientPosition.X;
            Mouse.Y = Mouse.Y - ClientPosition.Y;
            currentMousePosition = Mouse;
        }

        private void orGateToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //save the old Array and create a new one
          OrGate[] saved = Ors;
          int nullcount = 0;
          for(int i = 0;i<Ors.Length;i++)
          {
            if(Ors[i] == null)
            {
              nullcount ++;
            }
          }
          Ors = new OrGate[saved.Length +1 - nullcount];
          int indexSaved = 0;
          int indexVCCS = 0;
          while(indexSaved<saved.Length)
          {
            if(saved[indexSaved] != null)
            {
              Ors[indexVCCS] = saved[indexSaved];
              indexVCCS ++;
            }
            indexSaved ++;
          }
          Ors[Ors.Length - 1] = new OrGate(currentMousePosition.X, currentMousePosition.Y);
          needraw = true;
          refresh();
        }

        private void notToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //save the old Array and create a new one
          Not[] saved = Nots;
          int nullcount = 0;
          for(int i = 0;i<Nots.Length;i++)
          {
            if(Nots[i] == null)
            {
              nullcount ++;
            }
          }
          Nots = new Not[saved.Length +1 - nullcount];
          int indexSaved = 0;
          int indexVCCS = 0;
          while(indexSaved<saved.Length)
          {
            if(saved[indexSaved] != null)
            {
              Nots[indexVCCS] = saved[indexSaved];
              indexVCCS ++;
            }
            indexSaved ++;
          }
          Nots[Nots.Length - 1] = new Not(currentMousePosition.X, currentMousePosition.Y);
          needraw = true;
          refresh();
        }

        private void vCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //save the old Array and create a new one
            VCC[] saved = VCCS;
            int nullcount = 0;
            for(int i = 0;i<VCCS.Length;i++)
            {
              if(VCCS[i] == null)
              {
                nullcount ++;
              }
            }
            VCCS = new VCC[saved.Length +1 - nullcount];
            int indexSaved = 0;
            int indexVCCS = 0;
            while(indexSaved<saved.Length)
            {
              if(saved[indexSaved] != null)
              {
                VCCS[indexVCCS] = saved[indexSaved];
                indexVCCS ++;
              }
              indexSaved ++;
            }
            VCCS[VCCS.Length - 1] = new VCC(currentMousePosition.X, currentMousePosition.Y);
            needraw = true;
            refresh();
        }

        private void gNDToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //save the old Array and create a new one
          GND[] saved = GNDS;
          int nullcount = 0;
          for(int i = 0;i<GNDS.Length;i++)
          {
            if(GNDS[i] == null)
            {
              nullcount ++;
            }
          }
          GNDS = new GND[saved.Length +1 - nullcount];
          int indexSaved = 0;
          int indexVCCS = 0;
          while(indexSaved<saved.Length)
          {
            if(saved[indexSaved] != null)
            {
              GNDS[indexVCCS] = saved[indexSaved];
              indexVCCS ++;
            }
            indexSaved ++;
          }
          GNDS[GNDS.Length - 1] = new GND(currentMousePosition.X, currentMousePosition.Y);
          needraw = true;
          refresh();
        }

        private void switchToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //save the old Array and create a new one
          Cswitch[] saved = switches;
          int nullcount = 0;
          for(int i = 0;i<switches.Length;i++)
          {
            if(switches[i] == null)
            {
              nullcount ++;
            }
          }
          switches = new Cswitch[saved.Length +1 - nullcount];
          int indexSaved = 0;
          int indexVCCS = 0;
          while(indexSaved<saved.Length)
          {
            if(saved[indexSaved] != null)
            {
              switches[indexVCCS] = saved[indexSaved];
              indexVCCS ++;
            }
            indexSaved ++;
          }
          switches[switches.Length - 1] = new Cswitch(currentMousePosition.X, currentMousePosition.Y);
          needraw = true;
          refresh();
        }

        private void lEDToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //save the old Array and create a new one
          LED[] saved = LEDS;
          int nullcount = 0;
          for(int i = 0;i<LEDS.Length;i++)
          {
            if(LEDS[i] == null)
            {
              nullcount ++;
            }
          }
          LEDS = new LED[saved.Length +1 - nullcount];
          int indexSaved = 0;
          int indexVCCS = 0;
          while(indexSaved<saved.Length)
          {
            if(saved[indexSaved] != null)
            {
              LEDS[indexVCCS] = saved[indexSaved];
              indexVCCS ++;
            }
            indexSaved ++;
          }
          LEDS[LEDS.Length - 1] = new LED(currentMousePosition.X, currentMousePosition.Y);
          needraw = true;
          refresh();
        }

        private void inputAnzhalÄndernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentChangeInput != null)
            {
                currentChangeInput.Close();
            }
            //check if at the Position is a and or or-Gate
            bool search = false;
            for (int i = 0; i < Ands.Length; i++)
            {
                if (Ands[i] != null)
                {
                    search = Ands[i].search(currentMousePosition);
                    if (search)
                    {
                        break;
                    }
                }
            }
            if (search != true)
            {
                for (int i = 0; i < Ors.Length; i++)
                {
                    if (Ors[i] != null)
                    {
                        search = Ors[i].search(currentMousePosition);
                        if (search)
                        {
                            break;
                        }
                    }
                }
            }
            if (search)
            {
                currentChangeInput = new ChangeInput();
                currentChangeInput.Show();
                //now create the thread
                Thread waitforInput = new Thread(waitInput);
                waitforInput.Start();
            }
            
        }
        public void waitInput()
        {
            
            Point current = currentMousePosition;
            bool complete = false;
            while (complete != true)
            {
                complete = currentChangeInput.getComplete();
            }
            //now set the input to the Object
            for (int i = 0; i < Ands.Length; i++)
            {
                if (Ands[i] != null)
                {
                    bool search = Ands[i].search(current);
                    if (search)
                    {
                        Ands[i].ChangeInput(currentChangeInput.getValue());
                        break;
                    }
                }
            }
            for (int i = 0; i < Ors.Length; i++)
            {
                if (Ors[i] != null)
                {
                    bool search = Ors[i].search(current);
                    if (search)
                    {
                        Ors[i].ChangeInput(currentChangeInput.getValue());
                        break;
                    }
                }
            }
            //now refresh
            needraw = true;
            refresh();

        }

        private void löschenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



    }
}
