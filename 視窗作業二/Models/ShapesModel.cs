using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 視窗作業二.Models
{
    public class ShapesModel
    {
        private Dictionary<int, Shape> shapes = new Dictionary<int, Shape>();
        private int nextId = 0; // 用于生成唯一的 ID

        public bool Valid(List<string> shapeData)
        {
            // 確保列表至少有6個元素
            if (shapeData.Count < 6)
            {
                return false;
            }

            // 驗證形狀名稱和文本不為空
            if (string.IsNullOrEmpty(shapeData[0]) || string.IsNullOrEmpty(shapeData[1]))
            {
                return false;
            }

            // 驗證 X, Y, Width, Height 是否為有效的非負整數
            if (!int.TryParse(shapeData[2], out int x) ||
                !int.TryParse(shapeData[3], out int y) ||
                !int.TryParse(shapeData[4], out int width) || width <= 0 ||
                !int.TryParse(shapeData[5], out int height) || height <= 0)
            {
                return false;
            }

            return true;
        }

        public int AddShape(List<string> shapeData)
        {
            Shape shape = Factories.ShapeFactory.CreateShape(shapeData);
            int id = nextId++;
            shapes.Add(id, shape);
            return id; // 返回新添加形状的 ID
        }

        public void RemoveShape(int id)
        {
            shapes.Remove(id);
        }

        public List<Shape> GetShapes()
        {
            return shapes.Values.ToList();
        }

        public Shape GetShape(int id)
        {
            if (shapes.TryGetValue(id, out Shape shape))
            {
                return shape;
            }
            return null;
        }
    }
}