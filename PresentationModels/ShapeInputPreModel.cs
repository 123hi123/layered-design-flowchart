using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using 視窗流程圖.Models;

namespace 視窗流程圖.PresentationModels
{
    public class ShapeInputPreModel 
    {
        private ShapesModel _model;
        public ShapeInputPreModel()
        {
            _model = new ShapesModel(); // 直接在這裡創建 ShapesModel 實例
        }
        private bool _isValid = false;

        public bool IsValid
        {
            get => _isValid;
            set
            {
                if (_isValid != value)
                {
                    _isValid = value;
                }
            }
        }
        public string ShapeType { get; set; }
        public string ShapeName { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
     
        public ShapeData GetShapeData()
        {
            return new ShapeData
            {
                ShapeType = ShapeType,
                ShapeName = ShapeName,
                X = X,
                Y = Y,
                Width = Width,
                Height = Height
            };
        }
        
        
        public void UpdateProperty(string propertyName, string value)
        {
            switch (propertyName)
            {
                case nameof(ShapeType):
                    ShapeType = value;
                    break;
                case nameof(ShapeName):
                    ShapeName = value;
                    break;
                case nameof(X):
                    X = value;
                    break;
                case nameof(Y):
                    Y = value;
                    break;
                case nameof(Width):
                    Width = value;
                    break;
                case nameof(Height):
                    Height = value;
                    break;
            }
            IsValid = _model.Valid(GetShapeData());
            
        }
        
    }
}
