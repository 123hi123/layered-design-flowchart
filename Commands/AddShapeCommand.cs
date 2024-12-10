using System;
using 視窗流程圖.Models;

namespace 視窗流程圖.Commands
{
    public class AddShapeCommand : ICommand
    {
        private readonly ShapesModel _model;
        private readonly Shape _shape;
        private readonly int _id;

        public AddShapeCommand(ShapesModel model, Shape shape, int id)
        {
            _model = model;
            _shape = shape;
            _id = id;
        }

        public void Execute()
        {
            _model.InsertShape(_id, _shape);
        }

        public void Undo()
        {
            _model.RemoveShape(_id);
        }
    }
}
