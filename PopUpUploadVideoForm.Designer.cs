namespace DataViewerFront
{
    partial class PopUpUploadVideoForm
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
            UploadButton = new Button();
            progressBar1 = new ProgressBar();
            comboGp = new ComboBox();
            comboSessionType = new ComboBox();
            SuspendLayout();
            // 
            // UploadButton
            // 
            UploadButton.Location = new Point(373, 131);
            UploadButton.Name = "UploadButton";
            UploadButton.Size = new Size(75, 23);
            UploadButton.TabIndex = 0;
            UploadButton.Text = "File";
            UploadButton.UseVisualStyleBackColor = true;
            UploadButton.Click += UploadButton_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(303, 175);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(226, 23);
            progressBar1.TabIndex = 1;
            // 
            // comboGp
            // 
            comboGp.FormattingEnabled = true;
            comboGp.Location = new Point(349, 23);
            comboGp.Name = "comboGp";
            comboGp.Size = new Size(121, 23);
            comboGp.TabIndex = 2;
            comboGp.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboSessionType
            // 
            comboSessionType.FormattingEnabled = true;
            comboSessionType.Location = new Point(349, 68);
            comboSessionType.Name = "comboSessionType";
            comboSessionType.Size = new Size(121, 23);
            comboSessionType.TabIndex = 3;
            // 
            // PopUpUploadVideoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboSessionType);
            Controls.Add(comboGp);
            Controls.Add(progressBar1);
            Controls.Add(UploadButton);
            Name = "PopUpUploadVideoForm";
            Text = "PopUpUploadVideoForm";
            Load += PopUpUploadVideoForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button UploadButton;
        private ProgressBar progressBar1;
        private ComboBox comboGp;
        private ComboBox comboSessionType;
    }
}