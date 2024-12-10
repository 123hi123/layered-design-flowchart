using 視窗流程圖.Adapter;
using 視窗流程圖.Models;

namespace 視窗流程圖.Commands
{
    public class MoveTextShapeCommand : ICommand
    {
        private readonly Shape _shape;
        private readonly Point2D _oriText;
        private readonly Point2D _ori;
        private readonly Point2D _newText;
        private readonly Point2D _new;
        private readonly ShapesModel _model;

        public MoveTextShapeCommand(ShapesModel model, Shape shape, Point2D ori, Point2D oriText, Point2D newPos, Point2D newText)
        {
            _model = model;
            _shape = shape;
            _ori = ori;
            _oriText = oriText;
            _new = newPos;
            _newText = newText;
        }

        public void Execute()
        {
            _shape.TextX = (int)_newText.X;
            _shape.TextY = (int)_newText.Y;
            _shape.X = (int)_new.X;
            _shape.Y = (int)_new.Y;
            _model.ReRender();
        }

        public void Undo()
        {
            _shape.TextX = (int)_oriText.X;
            _shape.TextY = (int)_oriText.Y;
            _shape.X = (int)_ori.X;
            _shape.Y = (int)_ori.Y;
            _model.ReRender();
        }
    }
}
