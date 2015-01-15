namespace DigiSim
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rückgängiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.überToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funktionsumfangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gatterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.andGateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orGateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schalterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vCCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gNDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lEDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputAnzhalÄndernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.löschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bewegenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.bearbeitenToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1902, 43);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.speichernToolStripMenuItem,
            this.ladenToolStripMenuItem,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(85, 39);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(199, 40);
            this.speichernToolStripMenuItem.Text = "Speichern";
            this.speichernToolStripMenuItem.Click += new System.EventHandler(this.speichernToolStripMenuItem_Click);
            // 
            // ladenToolStripMenuItem
            // 
            this.ladenToolStripMenuItem.Name = "ladenToolStripMenuItem";
            this.ladenToolStripMenuItem.Size = new System.Drawing.Size(199, 40);
            this.ladenToolStripMenuItem.Text = "Laden";
            this.ladenToolStripMenuItem.Click += new System.EventHandler(this.ladenToolStripMenuItem_Click);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(199, 40);
            this.beendenToolStripMenuItem.Text = "Beenden";
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rückgängiToolStripMenuItem});
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(145, 39);
            this.bearbeitenToolStripMenuItem.Text = "Bearbeiten";
            // 
            // rückgängiToolStripMenuItem
            // 
            this.rückgängiToolStripMenuItem.Name = "rückgängiToolStripMenuItem";
            this.rückgängiToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.rückgängiToolStripMenuItem.Size = new System.Drawing.Size(312, 40);
            this.rückgängiToolStripMenuItem.Text = "Rückgängig";
            this.rückgängiToolStripMenuItem.Click += new System.EventHandler(this.rückgängiToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.überToolStripMenuItem,
            this.funktionsumfangToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(78, 39);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            // 
            // überToolStripMenuItem
            // 
            this.überToolStripMenuItem.Name = "überToolStripMenuItem";
            this.überToolStripMenuItem.Size = new System.Drawing.Size(282, 40);
            this.überToolStripMenuItem.Text = "Über";
            // 
            // funktionsumfangToolStripMenuItem
            // 
            this.funktionsumfangToolStripMenuItem.Name = "funktionsumfangToolStripMenuItem";
            this.funktionsumfangToolStripMenuItem.Size = new System.Drawing.Size(282, 40);
            this.funktionsumfangToolStripMenuItem.Text = "Funktionsumfang";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gatterToolStripMenuItem,
            this.schalterToolStripMenuItem,
            this.inputAnzhalÄndernToolStripMenuItem,
            this.löschenToolStripMenuItem,
            this.bewegenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(318, 204);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // gatterToolStripMenuItem
            // 
            this.gatterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.andGateToolStripMenuItem,
            this.orGateToolStripMenuItem,
            this.notToolStripMenuItem});
            this.gatterToolStripMenuItem.Name = "gatterToolStripMenuItem";
            this.gatterToolStripMenuItem.Size = new System.Drawing.Size(317, 40);
            this.gatterToolStripMenuItem.Text = "Gatter";
            // 
            // andGateToolStripMenuItem
            // 
            this.andGateToolStripMenuItem.Name = "andGateToolStripMenuItem";
            this.andGateToolStripMenuItem.Size = new System.Drawing.Size(186, 40);
            this.andGateToolStripMenuItem.Text = "AndGate";
            this.andGateToolStripMenuItem.Click += new System.EventHandler(this.andGateToolStripMenuItem_Click);
            // 
            // orGateToolStripMenuItem
            // 
            this.orGateToolStripMenuItem.Name = "orGateToolStripMenuItem";
            this.orGateToolStripMenuItem.Size = new System.Drawing.Size(186, 40);
            this.orGateToolStripMenuItem.Text = "OrGate";
            this.orGateToolStripMenuItem.Click += new System.EventHandler(this.orGateToolStripMenuItem_Click);
            // 
            // notToolStripMenuItem
            // 
            this.notToolStripMenuItem.Name = "notToolStripMenuItem";
            this.notToolStripMenuItem.Size = new System.Drawing.Size(186, 40);
            this.notToolStripMenuItem.Text = "Not";
            this.notToolStripMenuItem.Click += new System.EventHandler(this.notToolStripMenuItem_Click);
            // 
            // schalterToolStripMenuItem
            // 
            this.schalterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vCCToolStripMenuItem,
            this.gNDToolStripMenuItem,
            this.switchToolStripMenuItem,
            this.lEDToolStripMenuItem});
            this.schalterToolStripMenuItem.Name = "schalterToolStripMenuItem";
            this.schalterToolStripMenuItem.Size = new System.Drawing.Size(317, 40);
            this.schalterToolStripMenuItem.Text = "IO";
            // 
            // vCCToolStripMenuItem
            // 
            this.vCCToolStripMenuItem.Name = "vCCToolStripMenuItem";
            this.vCCToolStripMenuItem.Size = new System.Drawing.Size(161, 40);
            this.vCCToolStripMenuItem.Text = "VCC";
            this.vCCToolStripMenuItem.Click += new System.EventHandler(this.vCCToolStripMenuItem_Click);
            // 
            // gNDToolStripMenuItem
            // 
            this.gNDToolStripMenuItem.Name = "gNDToolStripMenuItem";
            this.gNDToolStripMenuItem.Size = new System.Drawing.Size(161, 40);
            this.gNDToolStripMenuItem.Text = "GND";
            this.gNDToolStripMenuItem.Click += new System.EventHandler(this.gNDToolStripMenuItem_Click);
            // 
            // switchToolStripMenuItem
            // 
            this.switchToolStripMenuItem.Name = "switchToolStripMenuItem";
            this.switchToolStripMenuItem.Size = new System.Drawing.Size(161, 40);
            this.switchToolStripMenuItem.Text = "Switch";
            this.switchToolStripMenuItem.Click += new System.EventHandler(this.switchToolStripMenuItem_Click);
            // 
            // lEDToolStripMenuItem
            // 
            this.lEDToolStripMenuItem.Name = "lEDToolStripMenuItem";
            this.lEDToolStripMenuItem.Size = new System.Drawing.Size(161, 40);
            this.lEDToolStripMenuItem.Text = "LED";
            this.lEDToolStripMenuItem.Click += new System.EventHandler(this.lEDToolStripMenuItem_Click);
            // 
            // inputAnzhalÄndernToolStripMenuItem
            // 
            this.inputAnzhalÄndernToolStripMenuItem.Name = "inputAnzhalÄndernToolStripMenuItem";
            this.inputAnzhalÄndernToolStripMenuItem.Size = new System.Drawing.Size(317, 40);
            this.inputAnzhalÄndernToolStripMenuItem.Text = "Input-Anzahl ändern";
            this.inputAnzhalÄndernToolStripMenuItem.Click += new System.EventHandler(this.inputAnzhalÄndernToolStripMenuItem_Click);
            // 
            // löschenToolStripMenuItem
            // 
            this.löschenToolStripMenuItem.Name = "löschenToolStripMenuItem";
            this.löschenToolStripMenuItem.Size = new System.Drawing.Size(317, 40);
            this.löschenToolStripMenuItem.Text = "Bewegen";
            this.löschenToolStripMenuItem.Click += new System.EventHandler(this.löschenToolStripMenuItem_Click);
            // 
            // bewegenToolStripMenuItem
            // 
            this.bewegenToolStripMenuItem.Name = "bewegenToolStripMenuItem";
            this.bewegenToolStripMenuItem.Size = new System.Drawing.Size(317, 40);
            this.bewegenToolStripMenuItem.Text = "Löschen";
            this.bewegenToolStripMenuItem.Click += new System.EventHandler(this.bewegenToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1902, 667);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "DigiSim";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ladenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rückgängiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem überToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funktionsumfangToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gatterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schalterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem löschenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bewegenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem andGateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orGateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vCCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gNDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lEDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputAnzhalÄndernToolStripMenuItem;
    }
}

