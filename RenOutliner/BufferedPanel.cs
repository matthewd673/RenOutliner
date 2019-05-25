using System.Windows.Forms;

namespace RenOutliner
{
    public class BufferedPanel : Panel
    {

        public BufferedPanel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }

    }
}
