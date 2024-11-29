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
    public class ShapeInputPreModel : INotifyPropertyChanged
    {
        private ShapesModel _model;

        public event PropertyChangedEventHandler PropertyChanged;

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
                    OnPropertyChanged();
                }
            }
        }

        private bool _typeValid = false;

        public bool TypeValid
        {
            get => _typeValid;
            set
            {
                if (_typeValid != value)
                {
                    _typeValid = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _nameValid = false;

        public bool NameValid
        {
            get => _nameValid;
            set
            {
                if (_nameValid != value)
                {
                    _nameValid = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _xValid = false;

        public bool XValid
        {
            get => _xValid;
            set
            {
                if (_xValid != value)
                {
                    _xValid = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _yValid = false;

        public bool YValid
        {
            get => _yValid;
            set
            {
                if (_yValid != value)
                {
                    _yValid = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _widthValid = false;

        public bool WidthValid
        {
            get => _widthValid;
            set
            {
                if (_widthValid != value)
                {
                    _widthValid = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _heightValid = false;

        public bool HeightValid
        {
            get => _heightValid;
            set
            {
                if (_heightValid != value)
                {
                    _heightValid = value;
                    OnPropertyChanged();
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
                    TypeValid = !string.IsNullOrEmpty(value);
                    break;
                case nameof(ShapeName):
                    ShapeName = value;
                    NameValid = !string.IsNullOrEmpty(value);
                    break;
                case nameof(X):
                    X = value;
                    XValid = int.TryParse(value, out int x) && x>0;
                    break;
                case nameof(Y):
                    Y = value;
                    YValid = int.TryParse(value, out int y) && y > 0;
                    break;
                case nameof(Width):
                    Width = value;
                    WidthValid = int.TryParse(value, out int width) && width > 0;
                    break;
                case nameof(Height):
                    Height = value;
                    HeightValid = int.TryParse(value, out int height) && height > 0;
                    break;
            }
            IsValid = TypeValid&&NameValid&&XValid&&YValid&&WidthValid&&HeightValid;
            OnPropertyChanged(propertyName);
        }
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
