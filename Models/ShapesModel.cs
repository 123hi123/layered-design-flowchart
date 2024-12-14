﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 視窗流程圖.Adapter;
using 視窗流程圖.Commands;

namespace 視窗流程圖.Models
{
    public class ShapesModel
    {
        private Dictionary<int, Shape> _shapes = new Dictionary<int, Shape>();
        private Dictionary<int, Line> _lines = new Dictionary<int, Line>();
        private CommandManager _commandManager; // 用于管理命令


        private int _nextId = 0; // 用于生成唯一的 ID
        public event Action ReRenderSign;
        public event Action IntoSelectionSign;
        public event Action<int> DataGridRemoveById;
        public event Action<int, Shape> DoubleClickOnTextEvent;
        public event Action<bool, bool> UndoRedoEvent;
        // New event for adding a line to the DataGridView

        public int NextId => _nextId;

        public ShapesModel()
        {
            _commandManager = new CommandManager(this);
        }
        public virtual void ChangeOfCommandHistory()
        {
            UndoRedoEvent?.Invoke(_commandManager.UndoState(), _commandManager.RedoState());
        }
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

        public virtual ShapeData CalculateShapeData(Point2D startPoint, Point2D endPoint, string shapeType)
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
        public virtual void TextChangeCommand(Shape shape, string ori, string text)
        {
            _commandManager.ExecuteCommand(new TextCommand(this, shape, ori, text));
        }

        public virtual void AddShapeByShapeData(ShapeData shapeData)
        {
            Shape shape = Factories.ShapeFactory.CreateShape(shapeData);
            AddShapeCommand(shape);
        }
        public virtual void AddLineCommand(Line line)//nothis
        {
            int id = _nextId++;
            _commandManager.ExecuteCommand(new AddLineCommand(this, line, id));

        }
        public virtual void InsertLine(int id, Line line)
        {
            _lines[id] = line;
            ReRenderSign?.Invoke();
        }
        public virtual void RemoveLineCommand(int id)//nothis
        {
            _commandManager.ExecuteCommand(new RemoveLineCommand(this, GetLine(id), id));

        }
        public virtual void MoveCommand(Shape shape, Point2D ori, Point2D oriText, Point2D newPos, Point2D newText)
        {
            _commandManager.ExecuteCommand(new MoveTextShapeCommand(this, shape, ori, oriText, newPos, newText));
        }
        public virtual void ReRender()
        {
            ReRenderSign?.Invoke();
        }
        public virtual void RemoveLine(int id)
        {
            _lines.Remove(id);
            DataGridRemoveById?.Invoke(id);
            ReRenderSign?.Invoke();
        }

        public virtual void AddShapeCommand(Shape shape)
        {
            int id = _nextId++;
            _commandManager.ExecuteCommand(new AddShapeCommand(this, shape, id));
        }
        public virtual void InsertShape(int id, Shape shape)
        {
            _shapes[id] = shape;
            ReRenderSign?.Invoke();
        }
        public virtual void RemoveShapeCommand(int id)
        {
            _commandManager.ExecuteCommand(new RemoveShapeCommand(this, GetShape(id), id));

        }
        public virtual void RemoveShape(int id)
        {
            _shapes.Remove(id);
            DataGridRemoveById?.Invoke(id);
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

        public virtual List<Shape> GetShapes()
        {
            return _shapes.Values.ToList();
        }
        public virtual List<Line> GetLines()
        {
            return _lines.Values.ToList();
        }
        public virtual IEnumerable<KeyValuePair<int, Shape>> GetShapesWithIds()
        {
            return _shapes;
        }
        public virtual IEnumerable<KeyValuePair<int, Line>> GetLinesWithIds()
        {
            return _lines;
        }

        public virtual Shape GetShape(int id)
        {
            if (_shapes.TryGetValue(id, out Shape shape))
            {
                return shape;
            }
            return null;
        }
        public virtual Line GetLine(int id)
        {
            if (_lines.TryGetValue(id, out Line line))
            {
                return line;
            }
            return null;
        }

        public virtual void DoubleClickOnText(int id, Shape shape)
        {
            DoubleClickOnTextEvent?.Invoke(id, shape);
        }
        public virtual void IntoSelection()
        {
            IntoSelectionSign?.Invoke();
        }
        public virtual void Undo()
        {
            _commandManager.Undo();
        }

        public virtual void Redo()
        {
            _commandManager.Redo();
        }

        //public virtual void ClearAllShapes()
        //{
        //    // Create a copy of the keys. If we delete while iterating over the keyset directly, it could cause exception.
        //    List<int> shapeIds = _shapes.Keys.ToList();

        //    foreach (int id in shapeIds)
        //    {
        //        RemoveShape(id); // Use the existing remove method to remove each shape by its id
        //    }
        //}
    }
}