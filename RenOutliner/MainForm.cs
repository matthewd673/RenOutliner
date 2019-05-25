using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenOutliner
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        Bitmap workingBitmap;
        Graphics g;
        BufferedGraphics pG;
        BufferedPanel bufferedPanel;
        Point lastPoint = new Point(-1, -1);
        Point mousePoint = new Point(0, 0);
        Point startPoint = new Point(0, 0);
        int xOffset = 0;
        int yOffset = 0;
        Color lineColor = Color.Red;
        Pen linePen;
        List<HistoryPoint> bitmapHistory = new List<HistoryPoint>();

        private void MainForm_Load(object sender, EventArgs e)
        {
            linePen = new Pen(lineColor);

            bufferedPanel = new BufferedPanel();

            bufferedPanel.Size = new Size(0, 0);
            bufferedPanel.Location = new Point(0, 0);
            bufferedPanel.BorderStyle = BorderStyle.FixedSingle;

            bufferedPanel.Paint += BufferedPanel_Paint;
            bufferedPanel.Click += BufferedPanel_Click;
            bufferedPanel.MouseMove += BufferedPanel_MouseMove;
            bufferedPanel.Resize += BufferedPanel_Resize;

            Controls.Add(bufferedPanel);

            workingBitmap = new Bitmap(1, 1);
            ResetBitmapGraphics();
            
            AllocateBufferedGraphics();
        }
        
        private void BufferedPanel_Click(object sender, EventArgs e)
        {
            Point instantMousePoint = mousePoint;
            Point oldLastPoint = lastPoint;

            if (lastPoint == new Point(-1, -1) && safeMousePos(instantMousePoint))
            {
                lastPoint = instantMousePoint;
                startPoint = instantMousePoint;
            }

            if (safeMousePos(instantMousePoint))
            {
                bitmapHistory.Insert(0, new HistoryPoint(new Bitmap(workingBitmap), oldLastPoint));
                g.DrawLine(linePen, lastPoint, mousePoint);
                g.Flush();
                DrawToBuffer(workingBitmap);
            }

            UpdatePosLabel(instantMousePoint);

            if (safeMousePos(instantMousePoint))
                lastPoint = instantMousePoint;

            bufferedPanel.Invalidate();
        }

        void UpdatePosLabel(Point mousePoint)
        {
            posLabel.Text = "(" + lastPoint.X + ", " + lastPoint.Y + ") ➡ (" + mousePoint.X + ", " + mousePoint.Y + ")";
            if (safeMousePos(mousePoint))
                posLabel.Text += " ✔";
        }

        void ResetPosLabel()
        {
            posLabel.Text = "LP: () MP: ()";
        }

        private void BufferedPanel_Paint(object sender, PaintEventArgs e)
        {
            pG.Render(e.Graphics);
        }

        private void BufferedPanel_MouseMove(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void BufferedPanel_Resize(object sender, EventArgs e)
        {
            AllocateBufferedGraphics();
        }


        private void PasteButton_Click(object sender, EventArgs e)
        {
            Paste();
        }

        void Paste()
        {
            try
            {
                workingBitmap = new Bitmap(Clipboard.GetImage());
                g = Graphics.FromImage(workingBitmap);
                bufferedPanel.Size = workingBitmap.Size;
                bitmapHistory.Clear();
                BitmapReset();
                BreakLine();
            }
            catch
            {
                MessageBox.Show("Ensure that there is an image in your clipboard.", "Paste Error");
            }
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            Copy();
        }

        void Copy()
        {
            Clipboard.SetImage(workingBitmap);
        }

        bool safeMousePos(Point instantMousePoint)
        {
            return (instantMousePoint.X >= 0 && instantMousePoint.X < workingBitmap.Width && instantMousePoint.Y >= 0 && instantMousePoint.Y < workingBitmap.Height);
        }

        private void BreakButton_Click(object sender, EventArgs e)
        {
            BreakLine();
        }

        void BreakLine()
        {
            lastPoint = new Point(-1, -1);
            ResetPosLabel();
        }

        void AllocateBufferedGraphics()
        {
            pG = BufferedGraphicsManager.Current.Allocate(bufferedPanel.CreateGraphics(), new Rectangle(new Point(0, 0), bufferedPanel.Size));
        }

        void ResetBitmapGraphics()
        {
            g = Graphics.FromImage(workingBitmap);
        }

        void DrawToBuffer(Image image)
        {
            pG.Graphics.DrawImage(image, 0, 0);
        }

        void BitmapReset()
        {
            bufferedPanel.Invalidate();
            DrawToBuffer(workingBitmap);
            bufferedPanel.Invalidate();
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            Undo();
        }

        void Undo()
        {
            if (bitmapHistory.Count > 0)
            {
                workingBitmap = bitmapHistory[0].bitmap;
                ResetBitmapGraphics();
                lastPoint = bitmapHistory[0].lastPoint;
                UpdatePosLabel(mousePoint);
                BitmapReset();
                bitmapHistory.RemoveAt(0);
            }
        }

        void ToggleToolbar()
        {
            pasteButton.Visible = !pasteButton.Visible;
            copyButton.Visible = !copyButton.Visible;
            breakButton.Visible = !breakButton.Visible;
            colorButton.Visible = !colorButton.Visible;
            joinButton.Visible = !joinButton.Visible;
            undoButton.Visible = !undoButton.Visible;
            posLabel.Visible = !posLabel.Visible;
            spaceLabel.Visible = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Control | Keys.V))
            {
                Paste();
                return true;
            }

            if (keyData == (Keys.Control | Keys.C))
            {
                Copy();
                return true;
            }

            if (keyData == (Keys.Control | Keys.Z))
            {
                Undo();
                return true;
            }

            if (keyData == (Keys.Control | Keys.B))
            {
                BreakLine();
                return true;
            }

            if (keyData == (Keys.Control | Keys.P))
            {
                ChooseColor();
                return true;
            }

            if (keyData == (Keys.Control | Keys.J))
            {
                JoinPolygon();
                return true;
            }

            if (keyData == Keys.Space)
            {
                ToggleToolbar();
                return true;
            }

            if (keyData == Keys.Left)
            {
                xOffset -= 10;
                bufferedPanel.Location = new Point(xOffset, yOffset);
                return true;
            }

            if (keyData == Keys.Right)
            {
                xOffset += 10;
                bufferedPanel.Location = new Point(xOffset, yOffset);
                return true;
            }

            if (keyData == Keys.Up)
            {
                yOffset -= 10;
                bufferedPanel.Location = new Point(xOffset, yOffset);
                return true;
            }

            if (keyData == Keys.Down)
            {
                yOffset += 10;
                bufferedPanel.Location = new Point(xOffset, yOffset);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        struct HistoryPoint
        {
            public Bitmap bitmap;
            public Point lastPoint;

            public HistoryPoint(Bitmap bitmap, Point lastPoint)
            {
                this.bitmap = bitmap;
                this.lastPoint = lastPoint;
            }

        }

        private void SpaceLabel_Click(object sender, EventArgs e)
        {
            spaceLabel.Visible = false;
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            ChooseColor();
        }

        void ChooseColor()
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = lineColor;
            
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                lineColor = colorDialog.Color;
                linePen = new Pen(lineColor);
                colorButton.Text = "Color (" + colorDialog.Color.Name + ")";
            }

        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            JoinPolygon();
        }

        void JoinPolygon()
        {
            bitmapHistory.Insert(0, new HistoryPoint(new Bitmap(workingBitmap), lastPoint));
            g.DrawLine(linePen, lastPoint, startPoint);
            g.Flush();
            DrawToBuffer(workingBitmap);
            lastPoint = startPoint;
            BitmapReset();
        }

    }
}
