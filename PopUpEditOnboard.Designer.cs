namespace DataViewerFront
{
    partial class PopUpEditOnboard
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
            comboDrivers = new ComboBox();
            driverLabel = new Label();
            saveButton = new Button();
            deleteButton = new Button();
            comboLaps = new ComboBox();
            lapLabel = new Label();
            textBoxTo = new TextBox();
            textBoxFrom = new TextBox();
            SuspendLayout();
            // 
            // comboDrivers
            // 
            comboDrivers.FormattingEnabled = true;
            comboDrivers.Location = new Point(25, 56);
            comboDrivers.Name = "comboDrivers";
            comboDrivers.Size = new Size(203, 23);
            comboDrivers.TabIndex = 0;
            // 
            // driverLabel
            // 
            driverLabel.AutoSize = true;
            driverLabel.Location = new Point(107, 38);
            driverLabel.Name = "driverLabel";
            driverLabel.Size = new Size(41, 15);
            driverLabel.TabIndex = 1;
            driverLabel.Text = "Driver:";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(25, 241);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 4;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(153, 241);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(75, 23);
            deleteButton.TabIndex = 5;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            // 
            // comboLaps
            // 
            comboLaps.FormattingEnabled = true;
            comboLaps.Location = new Point(79, 130);
            comboLaps.Name = "comboLaps";
            comboLaps.Size = new Size(80, 23);
            comboLaps.TabIndex = 6;
            // 
            // lapLabel
            // 
            lapLabel.AutoSize = true;
            lapLabel.Location = new Point(107, 112);
            lapLabel.Name = "lapLabel";
            lapLabel.Size = new Size(29, 15);
            lapLabel.TabIndex = 7;
            lapLabel.Text = "Lap:";
            // 
            // textBoxTo
            // 
            textBoxTo.Location = new Point(128, 199);
            textBoxTo.Name = "textBoxTo";
            textBoxTo.ReadOnly = true;
            textBoxTo.Size = new Size(100, 23);
            textBoxTo.TabIndex = 8;
            // 
            // textBoxFrom
            // 
            textBoxFrom.Location = new Point(25, 199);
            textBoxFrom.Name = "textBoxFrom";
            textBoxFrom.ReadOnly = true;
            textBoxFrom.Size = new Size(100, 23);
            textBoxFrom.TabIndex = 9;
            // 
            // PopUpEditOnboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(250, 359);
            Controls.Add(textBoxFrom);
            Controls.Add(textBoxTo);
            Controls.Add(lapLabel);
            Controls.Add(comboLaps);
            Controls.Add(deleteButton);
            Controls.Add(saveButton);
            Controls.Add(driverLabel);
            Controls.Add(comboDrivers);
            Name = "PopUpEditOnboard";
            Text = "PopUpEditOnboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboDrivers;
        private Label driverLabel;
        private Button saveButton;
        private Button deleteButton;
        private ComboBox comboLaps;
        private Label lapLabel;
        private TextBox textBoxTo;
        private TextBox textBoxFrom;
    }
}