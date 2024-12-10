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
        private Dictionary<int, Line> _lines = new Dictionary<int, Line>();

        private int _nextId = 0; // 用于生成唯一的 ID
        public event Action ReRenderSign;
        public event Action IntoSelectionSign;

        public event Action<int, Shape> DoubleClickOnTextEvent;
        // New event for adding a line to the DataGridView
        public event Action<int, Line> LineAddedToGridView;

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

        public void AddShapeByShapeData(ShapeData shapeData)
        {
            Shape shape = Factories.ShapeFactory.CreateShape(shapeData);
            AddShape(shape);
        }
        public int AddLine(Line line)
        {
            int id = _nextId++;
            _lines.Add(id, line);
            ReRenderSign?.Invoke();
            // Trigger the new event for adding the line to the DataGridView
            return id;
        }
        public void InsertLine(int id, Line line)
        {
            _lines[id] = line;
            ReRenderSign?.Invoke();
        }  

        public void RemoveLine(int id)
        {
            _lines.Remove(id);
            ReRenderSign?.Invoke();
        }

        public int AddShape(Shape shape)
        {
            int id = _nextId++;
            _shapes.Add(id, shape);
            ReRenderSign?.Invoke();
            return id;
        }
        public void InsertShape(int id, Shape shape)
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
        public List<Line> GetLines()
        {
            return _lines.Values.ToList();
        }
        public IEnumerable<KeyValuePair<int, Shape>> GetShapesWithIds()
        {
            return _shapes;
        }
        public IEnumerable<KeyValuePair<int, Line>> GetLinesWithIds()
        {
            return _lines;
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
        public void IntoSelection()
        {
            IntoSelectionSign?.Invoke();
        }
    }
}
