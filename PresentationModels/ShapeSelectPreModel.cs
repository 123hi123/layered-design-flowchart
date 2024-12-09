using System;
using System.Collections.Generic;
using System.Linq;

namespace 視窗流程圖.PresentationModels
{
    public class ShapeSelectPreModel
    {
        public enum ShapeType
        {
            Start,
            Terminator,
            Process,
            Decision,
            Select,
            DrawLine
        }

        public ShapeType SelectedShapeType { get; private set; } = ShapeType.Select;
        public bool IsCursor { get; private set; } = false;

        // 新增：用於存儲按鈕狀態的字典
        public Dictionary<ShapeType, bool> ButtonStates { get; } = new Dictionary<ShapeType, bool>();

        public event EventHandler ShapeTypeChanged;
        public event EventHandler NormalStateIn;
        public event EventHandler DrawStateIn;
        public event EventHandler DrawLineStateIn;
        public event EventHandler EnterDrawingMode;
        public event EventHandler ExitDrawingMode;

        public ShapeSelectPreModel()
        {
            // 初始化按鈕狀態
            foreach (ShapeType type in Enum.GetValues(typeof(ShapeType)))
            {
                ButtonStates[type] = false;
            }
            ButtonStates[ShapeType.Select] = true; // 初始選中 Select
        }

        public void UpdateCursorState(bool state)
        {
            IsCursor = state && SelectedShapeType != ShapeType.Select;
            if (IsCursor)
            {
                EnterDrawingMode?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                ExitDrawingMode?.Invoke(this, EventArgs.Empty);
            }
        }

        public void SelectShape(ShapeType shapeType)
        {
            SelectedShapeType = shapeType;

            var keys = ButtonStates.Keys.ToList();
            foreach (var key in keys)
            {
                ButtonStates[key] = (key == shapeType);
            }

            OnShapeTypeChanged();

            if (shapeType == ShapeType.Select)
            {
                OnNormalStateIn();
            }
            else if (shapeType == ShapeType.DrawLine)
            {
                OnDrawLineStateIn();
            }
            else
            {
                OnDrawStateIn();
            }
        }

        protected virtual void OnShapeTypeChanged()
        {
            ShapeTypeChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnNormalStateIn()
        {
            NormalStateIn?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnDrawStateIn()
        {
            DrawStateIn?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnDrawLineStateIn()
        {
            DrawLineStateIn?.Invoke(this, EventArgs.Empty);
        }
    }
}