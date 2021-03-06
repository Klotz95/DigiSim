﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

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
        UndoStorage[] Undos = new UndoStorage[0];
        Connection toEstablishConnection = new Connection();
        Point currentMousePosition;
        ChangeInput currentChangeInput;
        bool onMove = false;
        bool needraw = false;
        bool undo = false;
        public Form1()
        {
            InitializeComponent();
        }
        public void refresh()
        {
            //look if theres a new Connection
            if (toEstablishConnection.haveInput() && toEstablishConnection.haveOutput())
            {
                toEstablishConnection.deleteSelection();
                //save the current Connection Array
                Connection[] savedConnections = Connections;
                //search for nulls and count them
                int nullCount = 0;
                for (int i = 0; i < savedConnections.Length; i++)
                {
                    if (savedConnections[i] == null)
                    {
                        nullCount++;
                    }
                }
                Connections = new Connection[savedConnections.Length + 1 - nullCount];
                int index = 0;
                int indexNew = 0;
                while (index < savedConnections.Length)
                {
                    if (savedConnections[index] != null)
                    {
                        Connections[indexNew] = savedConnections[index];
                        indexNew++;
                    }
                    index++;
                }
                Connections[Connections.Length - 1] = toEstablishConnection;
                toEstablishConnection = new Connection();
                needraw = true;
            }
            //now deliver the signals (repeat this progress as long as all connections could deliver their signal)
            for (int i = 0; i < Connections.Length + 1; i++)
            {
                bool drawing = false;
                for (int k = 0; k < Connections.Length; k++)
                {
                    if (Connections[k] != null)
                    {
                        bool excistence = Connections[k].checkExistence();
                        if (excistence)
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
                    if (s != null)
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
                    if (s != null)
                    {
                        s.outen();
                    }
                }
                //OR
                foreach (OrGate s in Ors)
                {
                    if (s != null)
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
                    if (s != null)
                    {
                        s.refresh();
                    }
                }
                //LED
                foreach (LED s in LEDS)
                {
                    if (s != null)
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
                    if (s != null)
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
                    if (s != null)
                    {
                        s.draw(ref g);
                    }
                }
                //GNDs
                foreach (GND s in GNDS)
                {
                    if (s != null)
                    {
                        s.draw(ref g);
                    }
                }
                //Ors
                foreach (OrGate s in Ors)
                {
                    if (s != null)
                    {
                        s.draw(ref g);
                    }
                }
                //Nots
                foreach (Not s in Nots)
                {
                    if (s != null)
                    {
                        s.draw(ref g);
                    }
                }
                //LEDs
                foreach (LED s in LEDS)
                {
                    if (s != null)
                    {
                        s.draw(ref g);
                    }
                }
                //ANDs
                foreach (AndGate s in Ands)
                {
                    if (s != null)
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
            //now save the current state for undo
            if(undo != true)
            {
               //save the current undo-Storage
                UndoStorage[] saved = Undos;
                Undos = new UndoStorage[saved.Length + 1];
                //transfer the old array to the new one
                for (int i = 0; i < saved.Length; i++)
                {
                    Undos[i] = saved[i];
                }
                //now save the new state
                Undos[Undos.Length - 1] = new UndoStorage(Ands, Connections, GNDS, VCCS, LEDS, Nots, Ors, switches);
            }
            undo = false;


        }



        private void Form1_Load(object sender, EventArgs e)
        {
            //Event-Handler for click
            this.Click += new EventHandler(Form1_Click);
            //event Handler for resizing
            this.Resize += new EventHandler(Form1_ResizeEnd);
            //save the first state
            Undos = new UndoStorage[1];
            Undos[0] = new UndoStorage(Ands, Connections, GNDS, VCCS, LEDS, Nots, Ors, switches);


        }

        void Form1_ResizeEnd(object sender, EventArgs e)
        {
            //draw everything new
            if (onMove)
            {
                //clear all current drawings and redraw them
                Graphics g = this.CreateGraphics();
                g.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), new Size(Form1.ActiveForm.ClientSize.Width, Form1.ActiveForm.ClientSize.Height)));
                //switches
                foreach (Cswitch s in switches)
                {
                    if (s != null)
                    {
                        s.draw(ref g);
                    }
                }
                //GNDs
                foreach (GND s in GNDS)
                {
                    if (s != null)
                    {
                        s.draw(ref g);
                    }
                }
                //Ors
                foreach (OrGate s in Ors)
                {
                    if (s != null)
                    {
                        s.draw(ref g);
                    }
                }
                //Nots
                foreach (Not s in Nots)
                {
                    if (s != null)
                    {
                        s.draw(ref g);
                    }
                }
                //LEDs
                foreach (LED s in LEDS)
                {
                    if (s != null)
                    {
                        s.draw(ref g);
                    }
                }
                //ANDs
                foreach (AndGate s in Ands)
                {
                    if (s != null)
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
                //now draw the explaination
                Point P = new Point();
                P.X = 0;
                P.Y = this.Height - 100;
                Size f = new Size();
                f.Height = Convert.ToInt32(50);
                f.Width = Convert.ToInt32(this.Size.Width);
                g.FillRectangle(Brushes.Black, new Rectangle(P, f));
                //now make the label
                P.X = Convert.ToInt32(0.5 * this.Size.Width - 250);
                P.Y = Convert.ToInt32(this.Height - 100);
                g.DrawString("Zum verschieben auf eine Stelle klicken", new Font(SystemFonts.DefaultFont, FontStyle.Regular), Brushes.White, P);
            }
        }






        void Form1_Click(object sender, EventArgs e)
        {
            //get MousePosition with  calculating
            Point ClientPosition = Form1.ActiveForm.Location;
            Point Mouse = MousePosition;
            Mouse.X = Mouse.X - ClientPosition.X;
            Mouse.Y = Mouse.Y - ClientPosition.Y;
            if (onMove)
            {
                currentMousePosition = Mouse;
                onMove = false;
            }
            else
            {
                bool found = false;
                //GND
                for (int i = 0; i < GNDS.Length; i++)
                {
                    //look for the ground Pins
                    if (GNDS[i] != null)
                    {
                        found = GNDS[i].searchPin(Mouse, ref toEstablishConnection);
                    }
                }
                //Or-Gate
                if (found != true)
                {
                    for (int i = 0; i < Ors.Length; i++)
                    {
                        if (Ors[i] != null)
                        {
                            found = Ors[i].searchPin(Mouse, ref toEstablishConnection);
                        }
                    }
                }
                //Nots
                if (found != true)
                {
                    for (int i = 0; i < Nots.Length; i++)
                    {
                        if (Nots[i] != null)
                        {
                            found = Nots[i].searchPin(Mouse, ref toEstablishConnection);
                        }
                    }
                }
                //LEDS
                if (found != true)
                {
                    for (int i = 0; i < LEDS.Length; i++)
                    {
                        if (LEDS[i] != null)
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
                        if (Ands[i] != null)
                        {
                            found = Ands[i].searchPin(Mouse, ref  toEstablishConnection);
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
                        if (switches[i] != null)
                        {
                            found = switches[i].searchPin(Mouse, ref toEstablishConnection);
                        }
                    }
                }
                //switches
                if (found != true)
                {
                    for (int i = 0; i < switches.Length; i++)
                    {
                        if (switches[i] != null)
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
            for (int i = 0; i < GNDS.Length; i++)
            {
                if (GNDS[i] != null)
                {
                    bool delete = GNDS[i].search(currentMousePosition);
                    if (delete == true)
                    {
                        GNDS[i].deleteMe();
                        GNDS[i] = null;
                        needraw = true;
                        refresh();
                    }
                }
            }
            //switches
            for (int i = 0; i < switches.Length; i++)
            {
                if (switches[i] != null)
                {
                    bool delete = switches[i].search(currentMousePosition);
                    if (delete == true)
                    {
                        switches[i].deleteMe();
                        switches[i] = null;
                        needraw = true;
                        refresh();
                    }
                }
            }
            //Ors
            for (int i = 0; i < Ors.Length; i++)
            {
                if (Ors[i] != null)
                {
                    bool delete = Ors[i].search(currentMousePosition);
                    if (delete == true)
                    {
                        Ors[i].deleteMe();
                        Ors[i] = null;
                        needraw = true;
                        refresh();
                    }
                }
            }
            //Nots
            for (int i = 0; i < Nots.Length; i++)
            {
                if (Nots[i] != null)
                {
                    bool delete = Nots[i].search(currentMousePosition);
                    if (delete == true)
                    {
                        Nots[i].deleteMe();
                        Nots[i] = null;
                        needraw = true;
                        refresh();
                    }
                }
            }
            //LEDS
            for (int i = 0; i < LEDS.Length; i++)
            {
                if (LEDS[i] != null)
                {
                    bool delete = LEDS[i].search(currentMousePosition);
                    if (delete == true)
                    {
                        LEDS[i].deleteMe();
                        LEDS[i] = null;
                        needraw = true;
                        refresh();
                    }
                }
            }
            //Ands
            for (int i = 0; i < Ands.Length; i++)
            {
                if (Ands[i] != null)
                {
                    bool delete = Ands[i].search(currentMousePosition);
                    if (delete == true)
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
            for (int i = 0; i < Ands.Length; i++)
            {
                if (Ands[i] == null)
                {
                    nullcount++;
                }
            }
            Ands = new AndGate[saved.Length + 1 - nullcount];
            int indexSaved = 0;
            int indexVCCS = 0;
            while (indexSaved < saved.Length)
            {
                if (saved[indexSaved] != null)
                {
                    Ands[indexVCCS] = saved[indexSaved];
                    indexVCCS++;
                }
                indexSaved++;
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
            for (int i = 0; i < Ors.Length; i++)
            {
                if (Ors[i] == null)
                {
                    nullcount++;
                }
            }
            Ors = new OrGate[saved.Length + 1 - nullcount];
            int indexSaved = 0;
            int indexVCCS = 0;
            while (indexSaved < saved.Length)
            {
                if (saved[indexSaved] != null)
                {
                    Ors[indexVCCS] = saved[indexSaved];
                    indexVCCS++;
                }
                indexSaved++;
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
            for (int i = 0; i < Nots.Length; i++)
            {
                if (Nots[i] == null)
                {
                    nullcount++;
                }
            }
            Nots = new Not[saved.Length + 1 - nullcount];
            int indexSaved = 0;
            int indexVCCS = 0;
            while (indexSaved < saved.Length)
            {
                if (saved[indexSaved] != null)
                {
                    Nots[indexVCCS] = saved[indexSaved];
                    indexVCCS++;
                }
                indexSaved++;
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
            for (int i = 0; i < VCCS.Length; i++)
            {
                if (VCCS[i] == null)
                {
                    nullcount++;
                }
            }
            VCCS = new VCC[saved.Length + 1 - nullcount];
            int indexSaved = 0;
            int indexVCCS = 0;
            while (indexSaved < saved.Length)
            {
                if (saved[indexSaved] != null)
                {
                    VCCS[indexVCCS] = saved[indexSaved];
                    indexVCCS++;
                }
                indexSaved++;
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
            for (int i = 0; i < GNDS.Length; i++)
            {
                if (GNDS[i] == null)
                {
                    nullcount++;
                }
            }
            GNDS = new GND[saved.Length + 1 - nullcount];
            int indexSaved = 0;
            int indexVCCS = 0;
            while (indexSaved < saved.Length)
            {
                if (saved[indexSaved] != null)
                {
                    GNDS[indexVCCS] = saved[indexSaved];
                    indexVCCS++;
                }
                indexSaved++;
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
            for (int i = 0; i < switches.Length; i++)
            {
                if (switches[i] == null)
                {
                    nullcount++;
                }
            }
            switches = new Cswitch[saved.Length + 1 - nullcount];
            int indexSaved = 0;
            int indexVCCS = 0;
            while (indexSaved < saved.Length)
            {
                if (saved[indexSaved] != null)
                {
                    switches[indexVCCS] = saved[indexSaved];
                    indexVCCS++;
                }
                indexSaved++;
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
            for (int i = 0; i < LEDS.Length; i++)
            {
                if (LEDS[i] == null)
                {
                    nullcount++;
                }
            }
            LEDS = new LED[saved.Length + 1 - nullcount];
            int indexSaved = 0;
            int indexVCCS = 0;
            while (indexSaved < saved.Length)
            {
                if (saved[indexSaved] != null)
                {
                    LEDS[indexVCCS] = saved[indexSaved];
                    indexVCCS++;
                }
                indexSaved++;
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
            //create the thread,which wait for the second point
            Thread MovingThread = new Thread(waitForMove);
            MovingThread.Start();
        }
        private void waitForMove()
        {
            Point previous = currentMousePosition;
            bool found = false;
            //switches
            for (int i = 0; i < switches.Length; i++)
            {
                if (switches[i] != null)
                {
                    found = switches[i].search(previous);
                    if (found)
                    {
                        break;
                    }
                }
            }
            if (found != true)
            {
                //GNDS
                for (int i = 0; i < GNDS.Length; i++)
                {
                    if (GNDS[i] != null)
                    {
                        found = GNDS[i].search(previous);
                        if (found)
                        {
                            break;
                        }
                    }
                }
            }
            if (found != true)
            {
                //ORs
                for (int i = 0; i < Ors.Length; i++)
                {
                    if (Ors[i] != null)
                    {
                        found = Ors[i].search(previous);
                        if (found)
                        {
                            break;
                        }
                    }
                }
            }
            if (found != true)
            {
                //Nots
                for (int i = 0; i < Nots.Length; i++)
                {
                    if (Nots[i] != null)
                    {
                        found = Nots[i].search(previous);
                        if (found)
                        {
                            break;
                        }
                    }
                }
            }
            if (found != true)
            {
                //LEDS
                for (int i = 0; i < LEDS.Length; i++)
                {
                    if (LEDS[i] != null)
                    {
                        found = LEDS[i].search(previous);
                        if (found)
                        {
                            break;
                        }
                    }
                }
            }
            if (found != true)
            {
                //Ands
                for (int i = 0; i < Ands.Length; i++)
                {
                    if (Ands[i] != null)
                    {
                        found = Ands[i].search(previous);
                        if (found)
                        {
                            break;
                        }
                    }
                }
            }
            if (found != true)
            {
                //VCCS
                for (int i = 0; i < VCCS.Length; i++)
                {
                    if (VCCS[i] != null)
                    {
                        found = VCCS[i].search(previous);
                        if (found)
                        {
                            break;
                        }
                    }
                }
            }
                //now check if something has been found
                if (found)
                {
                    onMove = true;
                    //draw the explaination
                    Graphics g = this.CreateGraphics();
                    Point P = new Point();
                    P.X = 0;
                    P.Y = this.Height - 100;
                    Size s = new Size();
                    s.Height = Convert.ToInt32(50);
                    s.Width = Convert.ToInt32(this.Size.Width);
                    g.FillRectangle(Brushes.Black, new Rectangle(P, s));
                    //now make the label
                    P.X = Convert.ToInt32(0.5 * this.Size.Width -250);
                    P.Y = Convert.ToInt32(this.Height - 100);
                    g.DrawString("Zum verschieben auf eine Stelle klicken",new Font(SystemFonts.DefaultFont, FontStyle.Regular), Brushes.White, P);
                    //wait for the point
                    while (onMove == true)
                    {

                    }

                    //now search the gate again and set the point
                    Point next = currentMousePosition;
                    found = false;
                    for (int i = 0; i < switches.Length; i++)
                    {
                        if (switches[i] != null)
                        {
                            found = switches[i].search(previous);
                            if (found)
                            {
                                switches[i].ChangePosition(next.X, next.Y -60);
                                break;
                            }
                        }
                    }
                    if (found != true)
                    {
                        //GNDS
                        for (int i = 0; i < GNDS.Length; i++)
                        {
                            if (GNDS[i] != null)
                            {
                                found = GNDS[i].search(previous);
                                if (found)
                                {
                                    GNDS[i].ChangePosition(next.X, next.Y -60);
                                    break;
                                }
                            }
                        }
                    }
                    if (found != true)
                    {
                        //ORs
                        for (int i = 0; i < Ors.Length; i++)
                        {
                            if (Ors[i] != null)
                            {
                                found = Ors[i].search(previous);
                                if (found)
                                {
                                    Ors[i].ChangePosition(next.X, next.Y -60);
                                    break;
                                }
                            }
                        }
                    }
                    if (found != true)
                    {
                        //Nots
                        for (int i = 0; i < Nots.Length; i++)
                        {
                            if (Nots[i] != null)
                            {
                                found = Nots[i].search(previous);
                                if (found)
                                {
                                    Nots[i].ChangePosition(next.X, next.Y -60);
                                    break;
                                }
                            }
                        }
                    }
                    if (found != true)
                    {
                        //LEDS
                        for (int i = 0; i < LEDS.Length; i++)
                        {
                            if (LEDS[i] != null)
                            {
                                found = LEDS[i].search(previous);
                                if (found)
                                {
                                    LEDS[i].ChangePosition(next.X, next.Y -60);
                                    break;
                                }
                            }
                        }
                    }
                    if (found != true)
                    {
                        //Ands
                        for (int i = 0; i < Ands.Length; i++)
                        {
                            if (Ands[i] != null)
                            {
                                found = Ands[i].search(previous);
                                if (found)
                                {
                                    Ands[i].ChangePosition(next.X, next.Y-60);
                                    break;
                                }
                            }
                        }
                    }
                    if (found != true)
                    {
                        //VCCS
                        for (int i = 0; i < VCCS.Length; i++)
                        {
                            if (VCCS[i] != null)
                            {
                                found = VCCS[i].search(previous);
                                if (found)
                                {
                                    VCCS[i].ChangePosition(next.X, next.Y-60);
                                    break;
                                }
                            }
                        }
                    }
                    //now redraw and refresh
                    needraw = true;
                    refresh();

                }



            }

        private void rückgängiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //save the old undo-storage
            UndoStorage[] saved = Undos;
            if (Undos.Length> 1)
            {
                Undos[Undos.Length - 2].getCurrentState(ref Ands, ref Connections, ref GNDS, ref VCCS, ref LEDS, ref Nots, ref Ors, ref switches);
                //now crate the new Undostorage
                Undos = new UndoStorage[Undos.Length - 1];
                for (int i = 0; i < Undos.Length; i++)
                {
                    Undos[i] = saved[i];
                }
                undo = true;
                needraw = true;
                refresh();
            }
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.ShowDialog();
            string Pfad = sv.FileName;
            if (!Pfad.Contains(".dat"))
            {
                Pfad += ".dat";
            }
            //create a hashtable
            Hashtable saving = new Hashtable();
            saving.Add("VCC", VCCS);
            saving.Add("GND", GNDS);
            saving.Add("Connection", Connections);
            saving.Add("LED", LEDS);
            saving.Add("Ors", Ors);
            saving.Add("Ands", Ands);
            saving.Add("Not", Nots);
            saving.Add("Switch", switches);

            //create a Filestream
            FileStream fs = new FileStream(Pfad, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, saving);
            fs.Close();
            this.Text ="DigiSim " + Pfad;
        }

        private void ladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //create a empty hashtable
            Hashtable saved = null;
            OpenFileDialog os = new OpenFileDialog();
            os.ShowDialog();
            string Pfad = os.FileName;
            try
            {
                FileStream Fs = new FileStream(Pfad, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                saved = (Hashtable)bf.Deserialize(Fs);
                VCCS = (VCC[])saved["VCC"];
                GNDS = (GND[])saved["GND"];
                Connections = (Connection[])saved["Connection"];
                LEDS = (LED[])saved["LED"];
                Ors = (OrGate[])saved["Ors"];
                Ands = (AndGate[])saved["Ands"];
                Nots = (Not[])saved["Not"];
                switches = (Cswitch[])saved["Switch"];
                //check for null and initialize them
               
                this.Text = "DigiSim " + Pfad;
                needraw = true;
                refresh();
            }
            catch
            {
                MessageBox.Show("Die Datei konnte nicht geladen werden.", "Fehler");
            }

        }
        }
    }
