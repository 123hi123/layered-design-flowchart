using System.Windows.Forms;

namespace 視窗流程圖.States
{
    public interface IState
    {
        void MouseDown(MouseEventArgs e);
        void MouseMove(MouseEventArgs e);
        void MouseUp(MouseEventArgs e);
    }
}