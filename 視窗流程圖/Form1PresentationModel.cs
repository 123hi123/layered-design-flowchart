using System;
using System.Drawing;
using System.Windows.Forms;
using 視窗流程圖.Controllers;
using 視窗流程圖.Models;
using 視窗流程圖.Adapter;

namespace 視窗流程圖
{
    public class Form1PresentationModel
    {
        private ShapesController _controller;
        private ShapesModel _model;
        private ShapeSelectViewModel _shapeSelectViewModel;
        private ShapeInputViewModel _shapeInputViewModel;

        public event EventHandler ReRenderSign;

        public Form1PresentationModel(ShapesController controller, ShapesModel model, ShapeSelectViewModel shapeSelectViewModel, ShapeInputViewModel shapeInputViewModel)
        {
            _controller = controller;
            _model = model;
            _shapeSelectViewModel = shapeSelectViewModel;
            _shapeInputViewModel = shapeInputViewModel;

            _shapeSelectViewModel.ShapeTypeChanged += OnShapeTypeChanged;
            _shapeSelectViewModel.DrawStateIn += OnDrawStateIn;
            _shapeSelectViewModel.NormalStateIn += OnNormalStateIn;

            _model.ReRenderSign += OnModelChanged;
        }

        public void OnMouseDown(Point location, bool isDrawingCursor)
        {
            _controller.HandleMouseDown(new MouseEventArgs(MouseButtons.Left, 1, location.X, location.Y, 0), isDrawingCursor);
        }

        public void OnMouseMove(Point location)
        {
            _controller.HandleMouseMove(new MouseEventArgs(MouseButtons.None, 0, location.X, location.Y, 0));
        }

        public void OnMouseUp(Point location)
        {
            _controller.HandleMouseUp(new MouseEventArgs(MouseButtons.Left, 1, location.X, location.Y, 0));
        }

        public void OnShapeTypeChanged(object sender, EventArgs e)
        {
            UpdateToolStrip();
        }

        public void OnDrawStateIn(object sender, EventArgs e)
        {
            _controller.SetDrawingState();
        }

        public void OnNormalStateIn(object sender, EventArgs e)
        {
            _controller.SetNormalState();
        }

        public void UpdateToolStrip()
        {
            // Update UI elements based on the selected shape type
        }

        public bool IsDrawingCursor()
        {
            return _shapeSelectViewModel.SelectedShapeType != ShapeSelectViewModel.ShapeType.Select;
        }

        public void OnModelChanged()
        {
            ReRenderSign?.Invoke(this, EventArgs.Empty);
        }

        public void Render(IGraphics g)
        {
            // Clear canvas (optional)
            g.Clear(Color.White);

            // Render all shapes
            var shapes = _model.GetShapes();
            if (shapes != null && shapes.Count > 0)
            {
                foreach (var shape in shapes)
                {
                    shape.Draw(g);
                }
            }

            // Render temporary shape
            _controller.RenderTempShape(g);
            _controller.RenderTempSlection(g);
        }
    }
}
