using System.Windows.Forms;

namespace 視窗流程圖.States
{
    public class NormalState : IState
    {

        public void MouseDown(MouseEventArgs e)
        {
            // 一般狀態下不處理滑鼠事件
        }

        public void MouseMove(MouseEventArgs e)
        {
            // 一般狀態下不處理滑鼠事件
        }

        public void MouseUp(MouseEventArgs e)
        {
            // 一般狀態下不處理滑鼠事件
        }
    }
}