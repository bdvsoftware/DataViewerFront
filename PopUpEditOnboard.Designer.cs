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
            saveButton.Location = new Point(25, 99);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 4;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(153, 99);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(75, 23);
            deleteButton.TabIndex = 5;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            // 
            // PopUpEditOnboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(250, 250);
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
    }
}