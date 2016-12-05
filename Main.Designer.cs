namespace mlconverter2
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openRomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.midiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.midiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.addTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transposeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.romMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openSequencesListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertIntoRomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportAllMidiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.seqLoadedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.scheiding = new System.Windows.Forms.ToolStripStatusLabel();
            this.romLoadedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.trackslbl = new System.Windows.Forms.Label();
            this.trackListbox = new System.Windows.Forms.ListBox();
            this.trackgbx = new System.Windows.Forms.GroupBox();
            this.updateEventBtn = new System.Windows.Forms.Button();
            this.parametersgbx = new System.Windows.Forms.GroupBox();
            this.pr2lbl = new System.Windows.Forms.Label();
            this.parameter2num = new System.Windows.Forms.NumericUpDown();
            this.parameter1num = new System.Windows.Forms.NumericUpDown();
            this.pr1lbl = new System.Windows.Forms.Label();
            this.sortEventgbx = new System.Windows.Forms.GroupBox();
            this.valuenum = new System.Windows.Forms.NumericUpDown();
            this.Valuelbl = new System.Windows.Forms.Label();
            this.eventCmb = new System.Windows.Forms.ComboBox();
            this.removeEventBtn = new System.Windows.Forms.Button();
            this.addEventBtn = new System.Windows.Forms.Button();
            this.eventListbox = new System.Windows.Forms.ListBox();
            this.eventListlbl = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.status.SuspendLayout();
            this.trackgbx.SuspendLayout();
            this.parametersgbx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parameter2num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parameter1num)).BeginInit();
            this.sortEventgbx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valuenum)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.trackMenu,
            this.romMenu});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(581, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openRomToolStripMenuItem,
            this.openFileToolStripMenuItem,
            this.saveFileToolStripMenuItem,
            this.saveFileAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // openRomToolStripMenuItem
            // 
            this.openRomToolStripMenuItem.Name = "openRomToolStripMenuItem";
            this.openRomToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openRomToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.openRomToolStripMenuItem.Text = "Open ROM";
            this.openRomToolStripMenuItem.Click += new System.EventHandler(this.openRomToolStripMenuItem_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.openFileToolStripMenuItem.Text = "Open Music File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Enabled = false;
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveFileToolStripMenuItem.Text = "Save";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // saveFileAsToolStripMenuItem
            // 
            this.saveFileAsToolStripMenuItem.Enabled = false;
            this.saveFileAsToolStripMenuItem.Name = "saveFileAsToolStripMenuItem";
            this.saveFileAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveFileAsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveFileAsToolStripMenuItem.Text = "Save As...";
            this.saveFileAsToolStripMenuItem.Click += new System.EventHandler(this.saveFileAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.midiToolStripMenuItem1});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // midiToolStripMenuItem1
            // 
            this.midiToolStripMenuItem1.Name = "midiToolStripMenuItem1";
            this.midiToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
            this.midiToolStripMenuItem1.Text = "MIDI";
            this.midiToolStripMenuItem1.Click += new System.EventHandler(this.midiToolStripMenuItem1_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.midiToolStripMenuItem});
            this.exportToolStripMenuItem.Enabled = false;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // midiToolStripMenuItem
            // 
            this.midiToolStripMenuItem.Name = "midiToolStripMenuItem";
            this.midiToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.midiToolStripMenuItem.Text = "MIDI";
            this.midiToolStripMenuItem.Click += new System.EventHandler(this.midiToolStripMenuItem_Click);
            // 
            // trackMenu
            // 
            this.trackMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTrackToolStripMenuItem,
            this.deleteTrackToolStripMenuItem,
            this.toolStripSeparator3,
            this.searchToolStripMenuItem,
            this.transposeToolStripMenuItem});
            this.trackMenu.Enabled = false;
            this.trackMenu.Name = "trackMenu";
            this.trackMenu.Size = new System.Drawing.Size(47, 20);
            this.trackMenu.Text = "Track";
            // 
            // addTrackToolStripMenuItem
            // 
            this.addTrackToolStripMenuItem.Name = "addTrackToolStripMenuItem";
            this.addTrackToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addTrackToolStripMenuItem.Text = "Add Track";
            this.addTrackToolStripMenuItem.Click += new System.EventHandler(this.addTrackToolStripMenuItem_Click);
            // 
            // deleteTrackToolStripMenuItem
            // 
            this.deleteTrackToolStripMenuItem.Name = "deleteTrackToolStripMenuItem";
            this.deleteTrackToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteTrackToolStripMenuItem.Text = "Delete Track";
            this.deleteTrackToolStripMenuItem.Click += new System.EventHandler(this.deleteTrackToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.searchToolStripMenuItem.Text = "Search...";
            this.searchToolStripMenuItem.Visible = false;
            // 
            // transposeToolStripMenuItem
            // 
            this.transposeToolStripMenuItem.Name = "transposeToolStripMenuItem";
            this.transposeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.transposeToolStripMenuItem.Text = "Transpose";
            this.transposeToolStripMenuItem.Click += new System.EventHandler(this.transposeToolStripMenuItem_Click);
            // 
            // romMenu
            // 
            this.romMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSequencesListToolStripMenuItem,
            this.soundFontToolStripMenuItem,
            this.insertIntoRomToolStripMenuItem,
            this.toolStripSeparator2,
            this.exportAllMidiToolStripMenuItem});
            this.romMenu.Enabled = false;
            this.romMenu.Name = "romMenu";
            this.romMenu.Size = new System.Drawing.Size(46, 20);
            this.romMenu.Text = "ROM";
            // 
            // openSequencesListToolStripMenuItem
            // 
            this.openSequencesListToolStripMenuItem.Name = "openSequencesListToolStripMenuItem";
            this.openSequencesListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.openSequencesListToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openSequencesListToolStripMenuItem.Text = "Open Seq List";
            this.openSequencesListToolStripMenuItem.Click += new System.EventHandler(this.openSequencesListToolStripMenuItem_Click);
            // 
            // soundFontToolStripMenuItem
            // 
            this.soundFontToolStripMenuItem.Name = "soundFontToolStripMenuItem";
            this.soundFontToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.soundFontToolStripMenuItem.Text = "SoundFont";
            this.soundFontToolStripMenuItem.Click += new System.EventHandler(this.soundFontToolStripMenuItem_Click);
            // 
            // insertIntoRomToolStripMenuItem
            // 
            this.insertIntoRomToolStripMenuItem.Name = "insertIntoRomToolStripMenuItem";
            this.insertIntoRomToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.insertIntoRomToolStripMenuItem.Text = "Insert Into Rom";
            this.insertIntoRomToolStripMenuItem.Click += new System.EventHandler(this.insertIntoRomToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
            // 
            // exportAllMidiToolStripMenuItem
            // 
            this.exportAllMidiToolStripMenuItem.Name = "exportAllMidiToolStripMenuItem";
            this.exportAllMidiToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.exportAllMidiToolStripMenuItem.Text = "Export All To Midi";
            this.exportAllMidiToolStripMenuItem.Click += new System.EventHandler(this.exportAllMidiToolStripMenuItem_Click);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seqLoadedLabel,
            this.scheiding,
            this.romLoadedLabel});
            this.status.Location = new System.Drawing.Point(0, 327);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(581, 22);
            this.status.TabIndex = 1;
            this.status.Text = "statusStrip1";
            // 
            // seqLoadedLabel
            // 
            this.seqLoadedLabel.Name = "seqLoadedLabel";
            this.seqLoadedLabel.Size = new System.Drawing.Size(115, 17);
            this.seqLoadedLabel.Text = "No sequence loaded";
            // 
            // scheiding
            // 
            this.scheiding.Name = "scheiding";
            this.scheiding.Size = new System.Drawing.Size(10, 17);
            this.scheiding.Text = "|";
            // 
            // romLoadedLabel
            // 
            this.romLoadedLabel.Name = "romLoadedLabel";
            this.romLoadedLabel.Size = new System.Drawing.Size(92, 17);
            this.romLoadedLabel.Text = "No ROM loaded";
            // 
            // trackslbl
            // 
            this.trackslbl.AutoSize = true;
            this.trackslbl.Location = new System.Drawing.Point(12, 27);
            this.trackslbl.Name = "trackslbl";
            this.trackslbl.Size = new System.Drawing.Size(43, 13);
            this.trackslbl.TabIndex = 2;
            this.trackslbl.Text = "Tracks:";
            // 
            // trackListbox
            // 
            this.trackListbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trackListbox.FormattingEnabled = true;
            this.trackListbox.IntegralHeight = false;
            this.trackListbox.Location = new System.Drawing.Point(14, 44);
            this.trackListbox.Name = "trackListbox";
            this.trackListbox.Size = new System.Drawing.Size(120, 267);
            this.trackListbox.TabIndex = 3;
            this.trackListbox.SelectedIndexChanged += new System.EventHandler(this.trackListbox_SelectedIndexChanged);
            // 
            // trackgbx
            // 
            this.trackgbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackgbx.Controls.Add(this.updateEventBtn);
            this.trackgbx.Controls.Add(this.parametersgbx);
            this.trackgbx.Controls.Add(this.sortEventgbx);
            this.trackgbx.Controls.Add(this.removeEventBtn);
            this.trackgbx.Controls.Add(this.addEventBtn);
            this.trackgbx.Controls.Add(this.eventListbox);
            this.trackgbx.Controls.Add(this.eventListlbl);
            this.trackgbx.Location = new System.Drawing.Point(140, 27);
            this.trackgbx.Name = "trackgbx";
            this.trackgbx.Size = new System.Drawing.Size(429, 295);
            this.trackgbx.TabIndex = 4;
            this.trackgbx.TabStop = false;
            this.trackgbx.Text = "track";
            // 
            // updateEventBtn
            // 
            this.updateEventBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.updateEventBtn.Location = new System.Drawing.Point(267, 33);
            this.updateEventBtn.Name = "updateEventBtn";
            this.updateEventBtn.Size = new System.Drawing.Size(153, 23);
            this.updateEventBtn.TabIndex = 6;
            this.updateEventBtn.Text = "Update Event";
            this.updateEventBtn.UseVisualStyleBackColor = true;
            this.updateEventBtn.Click += new System.EventHandler(this.updateEventbtn_Click);
            // 
            // parametersgbx
            // 
            this.parametersgbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.parametersgbx.Controls.Add(this.pr2lbl);
            this.parametersgbx.Controls.Add(this.parameter2num);
            this.parametersgbx.Controls.Add(this.parameter1num);
            this.parametersgbx.Controls.Add(this.pr1lbl);
            this.parametersgbx.Location = new System.Drawing.Point(266, 205);
            this.parametersgbx.Name = "parametersgbx";
            this.parametersgbx.Size = new System.Drawing.Size(154, 80);
            this.parametersgbx.TabIndex = 5;
            this.parametersgbx.TabStop = false;
            this.parametersgbx.Text = "Parameters";
            // 
            // pr2lbl
            // 
            this.pr2lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pr2lbl.AutoSize = true;
            this.pr2lbl.Location = new System.Drawing.Point(6, 47);
            this.pr2lbl.Name = "pr2lbl";
            this.pr2lbl.Size = new System.Drawing.Size(46, 13);
            this.pr2lbl.TabIndex = 3;
            this.pr2lbl.Text = "Param 2";
            // 
            // parameter2num
            // 
            this.parameter2num.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.parameter2num.Hexadecimal = true;
            this.parameter2num.Location = new System.Drawing.Point(59, 45);
            this.parameter2num.Name = "parameter2num";
            this.parameter2num.Size = new System.Drawing.Size(89, 20);
            this.parameter2num.TabIndex = 2;
            // 
            // parameter1num
            // 
            this.parameter1num.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.parameter1num.Hexadecimal = true;
            this.parameter1num.Location = new System.Drawing.Point(59, 18);
            this.parameter1num.Name = "parameter1num";
            this.parameter1num.Size = new System.Drawing.Size(89, 20);
            this.parameter1num.TabIndex = 1;
            // 
            // pr1lbl
            // 
            this.pr1lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pr1lbl.AutoSize = true;
            this.pr1lbl.Location = new System.Drawing.Point(7, 20);
            this.pr1lbl.Name = "pr1lbl";
            this.pr1lbl.Size = new System.Drawing.Size(46, 13);
            this.pr1lbl.TabIndex = 0;
            this.pr1lbl.Text = "Param 1";
            // 
            // sortEventgbx
            // 
            this.sortEventgbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sortEventgbx.Controls.Add(this.valuenum);
            this.sortEventgbx.Controls.Add(this.Valuelbl);
            this.sortEventgbx.Controls.Add(this.eventCmb);
            this.sortEventgbx.Location = new System.Drawing.Point(266, 122);
            this.sortEventgbx.Name = "sortEventgbx";
            this.sortEventgbx.Size = new System.Drawing.Size(154, 76);
            this.sortEventgbx.TabIndex = 4;
            this.sortEventgbx.TabStop = false;
            this.sortEventgbx.Text = "Event";
            // 
            // valuenum
            // 
            this.valuenum.Hexadecimal = true;
            this.valuenum.Location = new System.Drawing.Point(59, 48);
            this.valuenum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.valuenum.Name = "valuenum";
            this.valuenum.Size = new System.Drawing.Size(89, 20);
            this.valuenum.TabIndex = 2;
            // 
            // Valuelbl
            // 
            this.Valuelbl.AutoSize = true;
            this.Valuelbl.Location = new System.Drawing.Point(7, 48);
            this.Valuelbl.Name = "Valuelbl";
            this.Valuelbl.Size = new System.Drawing.Size(34, 13);
            this.Valuelbl.TabIndex = 1;
            this.Valuelbl.Text = "Value";
            // 
            // eventCmb
            // 
            this.eventCmb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.eventCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventCmb.FormattingEnabled = true;
            this.eventCmb.Location = new System.Drawing.Point(7, 20);
            this.eventCmb.Name = "eventCmb";
            this.eventCmb.Size = new System.Drawing.Size(141, 21);
            this.eventCmb.TabIndex = 0;
            this.eventCmb.SelectedIndexChanged += new System.EventHandler(this.eventcmb_SelectedIndexChanged);
            // 
            // removeEventBtn
            // 
            this.removeEventBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeEventBtn.Location = new System.Drawing.Point(266, 92);
            this.removeEventBtn.Name = "removeEventBtn";
            this.removeEventBtn.Size = new System.Drawing.Size(154, 23);
            this.removeEventBtn.TabIndex = 3;
            this.removeEventBtn.Text = "Remove Event";
            this.removeEventBtn.UseVisualStyleBackColor = true;
            this.removeEventBtn.Click += new System.EventHandler(this.removeEventbtn_Click);
            // 
            // addEventBtn
            // 
            this.addEventBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addEventBtn.Location = new System.Drawing.Point(266, 62);
            this.addEventBtn.Name = "addEventBtn";
            this.addEventBtn.Size = new System.Drawing.Size(154, 23);
            this.addEventBtn.TabIndex = 2;
            this.addEventBtn.Text = "Add Event";
            this.addEventBtn.UseVisualStyleBackColor = true;
            this.addEventBtn.Click += new System.EventHandler(this.addEventbtn_Click);
            // 
            // eventListbox
            // 
            this.eventListbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventListbox.FormattingEnabled = true;
            this.eventListbox.Location = new System.Drawing.Point(9, 33);
            this.eventListbox.Name = "eventListbox";
            this.eventListbox.Size = new System.Drawing.Size(251, 251);
            this.eventListbox.TabIndex = 1;
            this.eventListbox.SelectedIndexChanged += new System.EventHandler(this.eventListbox_SelectedIndexChanged);
            // 
            // eventListlbl
            // 
            this.eventListlbl.AutoSize = true;
            this.eventListlbl.Location = new System.Drawing.Point(6, 16);
            this.eventListlbl.Name = "eventListlbl";
            this.eventListlbl.Size = new System.Drawing.Size(57, 13);
            this.eventListlbl.TabIndex = 0;
            this.eventListlbl.Text = "Event List:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 349);
            this.Controls.Add(this.trackgbx);
            this.Controls.Add(this.trackListbox);
            this.Controls.Add(this.trackslbl);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "MLConverter2";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.trackgbx.ResumeLayout(false);
            this.trackgbx.PerformLayout();
            this.parametersgbx.ResumeLayout(false);
            this.parametersgbx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parameter2num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parameter1num)).EndInit();
            this.sortEventgbx.ResumeLayout(false);
            this.sortEventgbx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valuenum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRomToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem midiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem midiToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel seqLoadedLabel;
        private System.Windows.Forms.ToolStripStatusLabel scheiding;
        private System.Windows.Forms.ToolStripStatusLabel romLoadedLabel;
        private System.Windows.Forms.Label trackslbl;
        private System.Windows.Forms.ListBox trackListbox;
        private System.Windows.Forms.GroupBox trackgbx;
        private System.Windows.Forms.ListBox eventListbox;
        private System.Windows.Forms.Label eventListlbl;
        private System.Windows.Forms.GroupBox parametersgbx;
        private System.Windows.Forms.Label pr2lbl;
        private System.Windows.Forms.NumericUpDown parameter2num;
        private System.Windows.Forms.NumericUpDown parameter1num;
        private System.Windows.Forms.Label pr1lbl;
        private System.Windows.Forms.GroupBox sortEventgbx;
        private System.Windows.Forms.ComboBox eventCmb;
        private System.Windows.Forms.Button removeEventBtn;
        private System.Windows.Forms.Button addEventBtn;
        private System.Windows.Forms.Button updateEventBtn;
        private System.Windows.Forms.NumericUpDown valuenum;
        private System.Windows.Forms.Label Valuelbl;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem romMenu;
        private System.Windows.Forms.ToolStripMenuItem openSequencesListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAllMidiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soundFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trackMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem addTrackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTrackToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transposeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertIntoRomToolStripMenuItem;
    }
}

