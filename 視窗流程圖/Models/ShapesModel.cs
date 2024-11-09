using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 視窗流程圖.Adapter;

namespace 視窗流程圖.Models
{
    public class ShapesModel
    {
        private Dictionary<int, Shape> _shapes = new Dictionary<int, Shape>();
        private int _nextId = 0; // 用于生成唯一的 ID
        public event Action ReRenderSign;

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

        // 計算圖形的大小和位置
        public ShapeData CalculateShapeData(Point2D startPoint, Point2D endPoint, string shapeType)
        {
            float x = Math.Min(startPoint.X, endPoint.X);  // 計算左上角 X
            float y = Math.Min(startPoint.Y, endPoint.Y);  // 計算左上角 Y
            float width = Math.Abs(endPoint.X - startPoint.X);  // 計算寬度
            float height = Math.Abs(endPoint.Y - startPoint.Y); // 計算高度

            // 隨機生成文字
            string randomText = GenerateRandomText();

            return new ShapeData
            {
                ShapeType = shapeType,
                ShapeName = randomText,
                X = x.ToString(),
                Y = y.ToString(),
                Width = width.ToString(),
                Height = height.ToString()
            };
        }

        public int AddShape(ShapeData shapeData) // 觸發重新繪制
        {
            Shape shape = Factories.ShapeFactory.CreateShape(shapeData);
            int id = _nextId++;
            _shapes.Add(id, shape);
            ReRenderSign(); // 觸發事件，通知視圖更新
            return id;
        }

        public void RemoveShape(int id) // 觸發重新繪制
        {
            _shapes.Remove(id);
            ReRenderSign(); // 觸發事件，通知視圖更新
        }

        // 隨機生成文字
        private string GenerateRandomText()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            int length = random.Next(3, 11); // 生成3-10個字符的隨機字符串
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = chars[random.Next(chars.Length)];
            }
            return new string(result);
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