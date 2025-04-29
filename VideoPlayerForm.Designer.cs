namespace DataViewerFront
{
    partial class VideoPlayerForm
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
            treeView1 = new TreeView();
            videoView1 = new LibVLCSharp.WinForms.VideoView();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)videoView1).BeginInit();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(538, 12);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(250, 426);
            treeView1.TabIndex = 0;
            treeView1.NodeMouseClick += treeView1_NodeMouseClick;
            // 
            // videoView1
            // 
            videoView1.BackColor = Color.Black;
            videoView1.Location = new Point(12, 12);
            videoView1.MediaPlayer = null;
            videoView1.Name = "videoView1";
            videoView1.Size = new Size(506, 265);
            videoView1.TabIndex = 1;
            videoView1.Text = "videoView1";
            // 
            // button1
            // 
            button1.Location = new Point(96, 357);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(372, 357);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Stop";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // VideoPlayerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(videoView1);
            Controls.Add(treeView1);
            Name = "VideoPlayerForm";
            Text = "VideoPlayerForm";
            Load += VideoPlayerForm_Load;
            ((System.ComponentModel.ISupportInitialize)videoView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeView1;
        private LibVLCSharp.WinForms.VideoView videoView1;
        private Button button1;
        private Button button2;
    }
}