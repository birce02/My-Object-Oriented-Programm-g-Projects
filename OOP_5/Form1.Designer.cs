namespace PuzzleApp
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.cmbGridSize = new System.Windows.Forms.ComboBox();
            this.btnCreatePuzzle = new System.Windows.Forms.Button();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.pnlSource = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTarget = new System.Windows.Forms.TableLayoutPanel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // picPreview
            // 
            this.picPreview.Location = new System.Drawing.Point(29, 34);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(107, 116);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnSelectImage.Location = new System.Drawing.Point(175, 51);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(144, 31);
            this.btnSelectImage.TabIndex = 1;
            this.btnSelectImage.Text = "Resim seç";
            this.btnSelectImage.UseVisualStyleBackColor = false;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click_1);
            // 
            // cmbGridSize
            // 
            this.cmbGridSize.FormattingEnabled = true;
            this.cmbGridSize.Items.AddRange(new object[] {
            "2x2",
            "4x4"});
            this.cmbGridSize.Location = new System.Drawing.Point(175, 99);
            this.cmbGridSize.Name = "cmbGridSize";
            this.cmbGridSize.Size = new System.Drawing.Size(144, 24);
            this.cmbGridSize.TabIndex = 2;
            this.cmbGridSize.SelectedIndexChanged += new System.EventHandler(this.cmbGridSize_SelectedIndexChanged);
            // 
            // btnCreatePuzzle
            // 
            this.btnCreatePuzzle.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnCreatePuzzle.Location = new System.Drawing.Point(325, 51);
            this.btnCreatePuzzle.Name = "btnCreatePuzzle";
            this.btnCreatePuzzle.Size = new System.Drawing.Size(149, 31);
            this.btnCreatePuzzle.TabIndex = 3;
            this.btnCreatePuzzle.Text = "Puzzle oluştur";
            this.btnCreatePuzzle.UseVisualStyleBackColor = false;
            this.btnCreatePuzzle.Click += new System.EventHandler(this.btnCreatePuzzle_Click);
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Location = new System.Drawing.Point(542, 58);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(50, 16);
            this.lblDifficulty.TabIndex = 4;
            this.lblDifficulty.Text = "Zorluk: ";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(663, 58);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(41, 16);
            this.lblScore.TabIndex = 5;
            this.lblScore.Text = "Süre: ";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(781, 58);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(38, 16);
            this.lblTimer.TabIndex = 6;
            this.lblTimer.Text = "Skor:";
            // 
            // pnlSource
            // 
            this.pnlSource.AutoScroll = true;
            this.pnlSource.Location = new System.Drawing.Point(29, 170);
            this.pnlSource.Name = "pnlSource";
            this.pnlSource.Size = new System.Drawing.Size(476, 394);
            this.pnlSource.TabIndex = 7;
            // 
            // pnlTarget
            // 
            this.pnlTarget.ColumnCount = 2;
            this.pnlTarget.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.02041F));
            this.pnlTarget.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.97959F));
            this.pnlTarget.Location = new System.Drawing.Point(536, 170);
            this.pnlTarget.Name = "pnlTarget";
            this.pnlTarget.RowCount = 2;
            this.pnlTarget.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.15607F));
            this.pnlTarget.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.84393F));
            this.pnlTarget.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlTarget.Size = new System.Drawing.Size(462, 388);
            this.pnlTarget.TabIndex = 8;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(601, 506);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 16);
            this.lblStatus.TabIndex = 9;
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1000;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1028, 591);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pnlTarget);
            this.Controls.Add(this.pnlSource);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblDifficulty);
            this.Controls.Add(this.btnCreatePuzzle);
            this.Controls.Add(this.cmbGridSize);
            this.Controls.Add(this.btnSelectImage);
            this.Controls.Add(this.picPreview);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.ComboBox cmbGridSize;
        private System.Windows.Forms.Button btnCreatePuzzle;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.FlowLayoutPanel pnlSource;
        private System.Windows.Forms.TableLayoutPanel pnlTarget;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer gameTimer;
    }
}

