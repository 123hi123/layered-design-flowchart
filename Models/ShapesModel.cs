﻿using System;
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
        public event Action<int, Shape> DoubleClickOnTextEvent;

        public virtual (int id, Shape shape) FindShapeAtPosition(int x, int y)
        {
            foreach (var kvp in _shapes)
            {
                if (kvp.Value.ContainsPoint(x, y))
                {
                    return (kvp.Key, kvp.Value);
                }
            }
            return (-1, null);
        }

        public ShapeData CalculateShapeData(Point2D startPoint, Point2D endPoint, string shapeType)
        {
            float x = Math.Min(startPoint.X, endPoint.X);
            float y = Math.Min(startPoint.Y, endPoint.Y);
            float width = Math.Abs(endPoint.X - startPoint.X);
            float height = Math.Abs(endPoint.Y - startPoint.Y);

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

        public int AddShape(ShapeData shapeData)
        {
            Shape shape = Factories.ShapeFactory.CreateShape(shapeData);
            int id = _nextId++;
            _shapes.Add(id, shape);
            ReRenderSign?.Invoke();
            return id;
        }

        public void AddShape(int id, Shape shape)
        {
            _shapes[id] = shape;
            ReRenderSign?.Invoke();
        }

        public void RemoveShape(int id)
        {
            _shapes.Remove(id);
            ReRenderSign?.Invoke();
        }

        private string GenerateRandomText()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            int length = random.Next(3, 11);
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

        public void DoubleClickOnText(int id, Shape shape)
        {
            DoubleClickOnTextEvent?.Invoke(id, shape);
        }
    }
}
