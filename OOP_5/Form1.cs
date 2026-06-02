using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PuzzleApp
{
    public partial class Form1 : Form
    {
        private Image originalImage;
        private int gridSize = 3;
        private int score = 0;
        private int elapsedSeconds = 0;
        private int cellWidth, cellHeight;
        private int correctCount = 0;
        private List<PictureBox> sourcePieces = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();

           
            gameTimer.Interval = 1000;
            gameTimer.Tick -= gameTimer_Tick;
            gameTimer.Tick += gameTimer_Tick;

            
            cmbGridSize.Items.Clear();
            cmbGridSize.Items.AddRange(new string[] { "2x2", "3x3", "4x4" });
            cmbGridSize.SelectedIndex = 0;
        }

        // resmi istenilen satır ve sütun sayısına göre eşit parçalara böler
        public List<Bitmap> SplitImage(Image originalImage, int rows, int cols)
        {
            List<Bitmap> pieces = new List<Bitmap>();
            int width = originalImage.Width;
            int height = originalImage.Height;
            int pieceWidth = width / cols;
            int pieceHeight = height / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Rectangle cropRect = new Rectangle(j * pieceWidth, i * pieceHeight, pieceWidth, pieceHeight);
                    Bitmap piece = new Bitmap(pieceWidth, pieceHeight);
                    using (Graphics g = Graphics.FromImage(piece))
                    {
                        g.DrawImage(originalImage, new Rectangle(0, 0, pieceWidth, pieceHeight),
                                    cropRect, GraphicsUnit.Pixel);
                    }
                    pieces.Add(piece);
                }
            }
            return pieces;
        }

        private void btnSelectImage_Click_1(object sender, EventArgs e)
        {
            // resim dosyası seçmesini sağlar
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Bir Resim Seçin";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    originalImage = Image.FromFile(ofd.FileName);
                    picPreview.Image = originalImage;
                    lblStatus.Text = "Resim yüklendi.";
                }
            }
        }

        private void btnCreatePuzzle_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Lütfen önce bir resim seçin!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selected = cmbGridSize.SelectedItem.ToString();
            gridSize = int.Parse(selected.Split('x')[0]);

            // Yeni oyun için değerleri sıfırlar
            score = 0;
            correctCount = 0;
            elapsedSeconds = 0;
            lblScore.Text = "Skor: 0";
            lblTimer.Text = "Süre: 00:00";
            lblStatus.ForeColor = Color.Black;

            pnlSource.Controls.Clear();
            pnlTarget.Controls.Clear();
            sourcePieces.Clear();
            gameTimer.Stop();

            SetDifficulty();
            SetupTargetGrid();
            BuildPiecesAndDisplay();

            // Oyunu ve süreyi başlat
            gameTimer.Start();
            lblStatus.Text = "Puzzle başladı! Parçaları sürükleyip bırakın.";
        }

        
        private void SetupTargetGrid()
        {
            pnlTarget.RowCount = gridSize;
            pnlTarget.ColumnCount = gridSize;
            pnlTarget.RowStyles.Clear();
            pnlTarget.ColumnStyles.Clear();

            for (int i = 0; i < gridSize; i++)
            {
                pnlTarget.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / gridSize));
                pnlTarget.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / gridSize));
            }

            cellWidth = pnlTarget.Width / gridSize;
            cellHeight = pnlTarget.Height / gridSize;

            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    // Her bir hedef hücreyi oluşturup sürükle-bırak olaylarına bağlar
                    PictureBox cell = new PictureBox();
                    cell.Dock = DockStyle.Fill;
                    cell.BorderStyle = BorderStyle.FixedSingle;
                    cell.BackColor = Color.LightGray;
                    cell.SizeMode = PictureBoxSizeMode.StretchImage;
                    cell.AllowDrop = true; 
                    cell.Tag = $"{row},{col}"; // Doğrulama için hücrenin orijinal koordinatını tutar

                    int cellNumber = row * gridSize + col + 1;
                    cell.Paint += (s, pe) =>
                    {
                        if (((PictureBox)s).Image == null)
                        {
                            pe.Graphics.DrawString(
                                cellNumber.ToString(),
                                new Font("Arial", 18, FontStyle.Bold),
                                Brushes.Gray,
                                new PointF(cell.Width / 2 - 10, cell.Height / 2 - 12)
                            );
                        }
                    };

                    cell.DragEnter += Cell_DragEnter;
                    cell.DragLeave += Cell_DragLeave;
                    cell.DragDrop += Cell_DragDrop;

                    pnlTarget.Controls.Add(cell, col, row);
                }
            }
        }

        
        private void BuildPiecesAndDisplay()
        {
            Bitmap scaledImage = new Bitmap(originalImage, cellWidth * gridSize, cellHeight * gridSize);
            List<Bitmap> bitmaps = SplitImage(scaledImage, gridSize, gridSize);

            int srcPieceW = (pnlSource.ClientSize.Width / gridSize) - 8;
            int srcPieceH = (pnlSource.ClientSize.Height / gridSize) - 8;

            List<PictureBox> pieces = new List<PictureBox>();

            for (int i = 0; i < bitmaps.Count; i++)
            {
                int row = i / gridSize;
                int col = i % gridSize;
                int pieceNum = i + 1;

                PictureBox pb = new PictureBox();
                pb.Image = bitmaps[i];
                pb.Size = new Size(srcPieceW, srcPieceH);
                pb.Margin = new Padding(3);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.BorderStyle = BorderStyle.FixedSingle;
                pb.Cursor = Cursors.Hand;
                pb.Tag = $"{row},{col}"; // Hangi parçanın hangi hücreye ait olduğunu tutar

                pb.Paint += (s, pe) =>
                {
                    if (((PictureBox)s).Image != null)
                    {
                        pe.Graphics.DrawString(
                            $"",
                            new Font("Arial", 10, FontStyle.Bold),
                            Brushes.White,
                            new PointF(3, 3)
                        );
                    }
                };

                pb.MouseDown += Piece_MouseDown;
                pieces.Add(pb);
                sourcePieces.Add(pb);
            }

            // Parçaları rastgele karıştırma (Shuffle) işlemidir
            Random rng = new Random();
            for (int i = pieces.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                PictureBox tmp = pieces[i];
                pieces[i] = pieces[j];
                pieces[j] = tmp;
            }

            pnlSource.Controls.Clear();
            pnlSource.AutoScroll = true;

            for (int i = 0; i < pieces.Count; i++)
            {
                pnlSource.Controls.Add(pieces[i]);
            }
        }

        // Parçaya fare ile tıklandığında sürükleme işlemini başlatır
        private void Piece_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox piece = (PictureBox)sender;
                DataObject data = new DataObject();
                data.SetData("PuzzlePiece", piece);
                piece.DoDragDrop(data, DragDropEffects.Move);
            }
        }

        // Sürüklenen parça hedef hücrenin üzerine geldiğinde fare imlecini günceller
        private void Cell_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("PuzzlePiece"))
            {
                e.Effect = DragDropEffects.Move;
                ((PictureBox)sender).BackColor = Color.LightBlue;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Cell_DragLeave(object sender, EventArgs e)
        {
            PictureBox cell = (PictureBox)sender;
            if (cell.Image == null)
                cell.BackColor = Color.LightGray;
        }

        // Sürüklenen parça hedef hücreye bırakıldığında doğrulama yapar
        private void Cell_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox targetCell = (PictureBox)sender;
            if (targetCell.Image != null) return; // Hücre doluysa işlem yapma

            PictureBox piece = (PictureBox)e.Data.GetData("PuzzlePiece");
            string pieceTag = piece.Tag.ToString();
            string cellTag = targetCell.Tag.ToString();

            // Parçanın ve hedefin Tag özellikleri (koordinatları) eşleşiyorsa
            if (pieceTag == cellTag)
            {
                targetCell.Image = piece.Image;
                targetCell.BackColor = Color.White;

                // Parçayı kaynak panelden silmek yerine içini boşaltıyoruz ki diğer resimler kaymasın
                piece.Image = null;
                piece.Enabled = false;
                piece.BorderStyle = BorderStyle.None;
                piece.Cursor = Cursors.Default;

                sourcePieces.Remove(piece);

                score += 10;
                correctCount++;

                int cellNum = int.Parse(cellTag.Split(',')[0]) * gridSize +
                              int.Parse(cellTag.Split(',')[1]) + 1;
                lblStatus.Text = $"P{cellNum} doğru yere koyuldu! (+10 Puan)";
                lblStatus.ForeColor = Color.Green;

                CheckWin(); // Oyunun bitip bitmediğini kontrol eten metod
            }
            else
            {
                // Yanlış hücreye bırakılırsa puan düşme 
                score -= 5;
                if (score < 0) score = 0;
                targetCell.BackColor = Color.LightGray;
                lblStatus.Text = "Yanlış pozisyon! (-5 Puan)";
                lblStatus.ForeColor = Color.Red;
            }

            lblScore.Text = $"Skor: {score}";
        }

        // Bütün parçalar doğru yerleştirildiyse oyunu bitirir ve sonuçları gösterir
        private void CheckWin()
        {
            if (correctCount == gridSize * gridSize)
            {
                gameTimer.Stop();
                int timeBonus = Math.Max(0, 300 - elapsedSeconds) / 10;
                score += timeBonus;
                lblScore.Text = $"Skor: {score}";

                MessageBox.Show(
                    $"Tebrikler! Puzzle tamamlandı!\n\nSüre: {elapsedSeconds} saniye\nSüre Bonusu: +{timeBonus} puan\nToplam Skor: {score}",
                    "Oyun Bitti!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            elapsedSeconds++;
            int minutes = elapsedSeconds / 60;
            int seconds = elapsedSeconds % 60;
            lblTimer.Text = $"Süre: {minutes:00}:{seconds:00}";

            if (elapsedSeconds % 30 == 0 && score > 0)
            {
                score = Math.Max(0, score - 2);
                lblScore.Text = $"Skor: {score}";
            }
        }

        private void SetDifficulty()
        {
            if (gridSize == 2)
                lblDifficulty.Text = "Zorluk: Kolay";
            else if (gridSize == 3)
                lblDifficulty.Text = "Zorluk: Orta";
            else if (gridSize == 4)
                lblDifficulty.Text = "Zorluk: Zor";
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
                btnCreatePuzzle_Click(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmbGridSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}