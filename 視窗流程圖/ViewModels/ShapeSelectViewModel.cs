using System;
using System.ComponentModel;

namespace 視窗流程圖
{
    public class ShapeSelectViewModel
    {
        public enum ShapeType
        {
            Start,
            Terminator,
            Process,
            Decision,
            Select
        }
        // 初始化
        public ShapeType SelectedShapeType { get; set; } = ShapeType.Select;

        public event EventHandler ShapeTypeChanged;
        public event EventHandler NormalStateIn;
        public event EventHandler DrawStateIn;

        public void SelectShape(ShapeType shapeType)
        {
            if (SelectedShapeType != shapeType)
            {
                SelectedShapeType = shapeType;
                OnShapeTypeChanged();
            }
            if (SelectedShapeType == ShapeType.Select)
            {
                OnNormalStateIn();
            }
            else
            {
                OnDrawStateIn();
            }

        }
        // observation pattern 
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
    }
}