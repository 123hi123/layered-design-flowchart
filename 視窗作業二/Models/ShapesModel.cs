using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 視窗流程圖.Models
{
    public class ShapesModel
    {
        private Dictionary<int, Shape> _shapes = new Dictionary<int, Shape>();
        private int _nextId = 0; // 用于生成唯一的 ID

        public bool Valid(ShapeData shapeData)
        {
            // 驗證形狀類型和名稱不為空
            if (string.IsNullOrEmpty(shapeData.ShapeType) || string.IsNullOrEmpty(shapeData.ShapeName))
            {
                return false;
            }

            // 驗證 X, Y, Width, Height 是否為有效
            if (!int.TryParse(shapeData.X, out int x) ||
                !int.TryParse(shapeData.Y, out int y) ||
                !int.TryParse(shapeData.Width, out int width) || width <= 0 ||
                !int.TryParse(shapeData.Height, out int height) || height <= 0)
            {
                return false;
            }

            return true;
        }

        public int AddShape(ShapeData shapeData)
        {
            Shape shape = Factories.ShapeFactory.CreateShape(shapeData);
            int id = _nextId++;
            _shapes.Add(id, shape);
            return id; // 返回新添加形状的 ID
        }

        public void RemoveShape(int id)
        {
            _shapes.Remove(id);
        }

        public List<Shape> GetShapes()
        {
            return _shapes.Values.ToList();
        }

        public Shape GetShape(int id)
        {
            if (_shapes.TryGetValue(id, out Shape shape))
            {
                return shape;
            }
            return null;
        }
    }
}