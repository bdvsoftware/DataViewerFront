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
            components = new System.ComponentModel.Container();
            videoView1 = new LibVLCSharp.WinForms.VideoView();
            button1 = new Button();
            button2 = new Button();
            comboBox1 = new ComboBox();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            labelCurrentTime = new Label();
            labelTotalTime = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            trackBar1 = new TrackBar();
            onboardsLabel = new Label();
            batteryLabel = new Label();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)videoView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // videoView1
            // 
            videoView1.BackColor = Color.Black;
            videoView1.Location = new Point(314, 57);
            videoView1.MediaPlayer = null;
            videoView1.Name = "videoView1";
            videoView1.Size = new Size(1218, 596);
            videoView1.TabIndex = 1;
            videoView1.Text = "videoView1";
            // 
            // button1
            // 
            button1.Location = new Point(493, 728);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1280, 728);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Stop";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(800, 28);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(150, 23);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 135);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(296, 198);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellClick += DataGridView1_CellClick;
            // 
            // dataGridView2
            // 
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(1538, 135);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(370, 185);
            dataGridView2.TabIndex = 6;
            dataGridView2.CellClick += DataGridView2_CellClick;
            // 
            // labelCurrentTime
            // 
            labelCurrentTime.AutoSize = true;
            labelCurrentTime.Location = new Point(314, 675);
            labelCurrentTime.Name = "labelCurrentTime";
            labelCurrentTime.Size = new Size(49, 15);
            labelCurrentTime.TabIndex = 8;
            labelCurrentTime.Text = "00:00:00";
            // 
            // labelTotalTime
            // 
            labelTotalTime.AutoSize = true;
            labelTotalTime.Location = new Point(1483, 675);
            labelTotalTime.Name = "labelTotalTime";
            labelTotalTime.Size = new Size(49, 15);
            labelTotalTime.TabIndex = 9;
            labelTotalTime.Text = "00:00:00";
            // 
            // timer1
            // 
            timer1.Tick += Timer_Tick;
            // 
            // trackBar1
            // 
            trackBar1.LargeChange = 1;
            trackBar1.Location = new Point(493, 675);
            trackBar1.Maximum = 100;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(862, 45);
            trackBar1.TabIndex = 10;
            trackBar1.MouseDown += trackBar1_MouseDown;
            trackBar1.MouseUp += trackBar1_MouseUp;
            // 
            // onboardsLabel
            // 
            onboardsLabel.AutoSize = true;
            onboardsLabel.Location = new Point(125, 117);
            onboardsLabel.Name = "onboardsLabel";
            onboardsLabel.Size = new Size(62, 15);
            onboardsLabel.TabIndex = 11;
            onboardsLabel.Text = "Onboards:";
            // 
            // batteryLabel
            // 
            batteryLabel.AutoSize = true;
            batteryLabel.Location = new Point(1688, 117);
            batteryLabel.Name = "batteryLabel";
            batteryLabel.Size = new Size(47, 15);
            batteryLabel.TabIndex = 12;
            batteryLabel.Text = "Battery:";
            // 
            // button3
            // 
            button3.Location = new Point(695, 728);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 13;
            button3.Text = "+5s";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(1057, 728);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 14;
            button4.Text = "-5s";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // VideoPlayerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1920, 1080);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(batteryLabel);
            Controls.Add(onboardsLabel);
            Controls.Add(trackBar1);
            Controls.Add(labelTotalTime);
            Controls.Add(labelCurrentTime);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(videoView1);
            Name = "VideoPlayerForm";
            Text = "VideoPlayerForm";
            Load += VideoPlayerForm_Load;
            ((System.ComponentModel.ISupportInitialize)videoView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();

            this.FormClosing += VideoPlayerForm_FormClosing;
        }

        #endregion
        private LibVLCSharp.WinForms.VideoView videoView1;
        private Button button1;
        private Button button2;
        private ComboBox comboBox1;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Label labelCurrentTime;
        private Label labelTotalTime;
        private System.Windows.Forms.Timer timer1;
        private TrackBar trackBar1;
        private Label onboardsLabel;
        private Label batteryLabel;
        private Button button3;
        private Button button4;
    }
}