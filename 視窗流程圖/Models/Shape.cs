using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 視窗流程圖.Models
{
    public abstract class Shape
    {
        public string ShapeName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        // 抽象繪製方法，具體的子類會實現這個方法
        public abstract void Draw(Graphics g);
    }
}
