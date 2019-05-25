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
        Graphics pG;
        Point lastPoint = new Point(-1, -1);
        Point mousePoint = new Point(0, 0);

        private void MainForm_Load(object sender, EventArgs e)
        {
            workingBitmap = new Bitmap(1, 1);
            g = Graphics.FromImage(workingBitmap);
            pG = renderPanel.CreateGraphics();
        }

        private void PasteButton_Click(object sender, EventArgs e)
        {
            try
            {
                workingBitmap = new Bitmap(Clipboard.GetImage());
                g = Graphics.FromImage(workingBitmap);
                renderPanel.Size = workingBitmap.Size;
            }
            catch
            {
                MessageBox.Show("Ensure that there is an image in your clipboard.", "Paste Error");
            }
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(workingBitmap);
        }

        private void RenderPanel_Paint(object sender, PaintEventArgs e)
        {
            pG.DrawImage(workingBitmap, 0, 0);
        }

        private void RenderPanel_Click(object sender, EventArgs e)
        {

            Point instantMousePoint = mousePoint;

            if(lastPoint == new Point(-1, -1) && safeMousePos(instantMousePoint))
                lastPoint = instantMousePoint;

            if (safeMousePos(instantMousePoint))
            {
                g.DrawLine(Pens.Red, lastPoint, mousePoint);
                g.Flush();
            }

            posLabel.Text = "(" + lastPoint.X + ", " + lastPoint.Y + ") ➡ (" + instantMousePoint.X + ", " + instantMousePoint.Y + ")";
            if (safeMousePos(instantMousePoint))
                posLabel.Text += " ✔";

            if(safeMousePos(instantMousePoint))
            lastPoint = instantMousePoint;

            renderPanel.Invalidate();
        }

        private void RenderPanel_MouseMove(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        bool safeMousePos(Point instantMousePoint)
        {
            return (instantMousePoint.X >= 0 && instantMousePoint.X < workingBitmap.Width && instantMousePoint.Y >= 0 && instantMousePoint.Y < workingBitmap.Height);
        }

        private void BreakButton_Click(object sender, EventArgs e)
        {
            lastPoint = new Point(-1, -1);
            posLabel.Text = "LP: () MP: ()";
        }

        private void RenderPanel_Resize(object sender, EventArgs e)
        {
            pG = renderPanel.CreateGraphics();
        }
    }
}
