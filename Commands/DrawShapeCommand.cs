using 視窗流程圖.Models;

namespace 視窗流程圖.Commands
{
    public class DrawShapeCommand : ICommand
    {
        private ShapesModel _model;
        private Shape _shape;

        public DrawShapeCommand(ShapesModel model, Shape shape)
        {
            _model = model;
            _shape = shape;
        }

        public void Execute()
        {
            _model.AddShape(_shape);
        }

        public void Undo()
        {
            _model.RemoveShape(_shape);
        }
    }
}
