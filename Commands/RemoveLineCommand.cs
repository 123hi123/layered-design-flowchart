using System;
using 視窗流程圖.Models;

namespace 視窗流程圖.Commands
{
    public class RemoveLineCommand : ICommand
    {
        private readonly ShapesModel _model;
        private readonly int _id;
        private Line _line;

        public RemoveLineCommand(ShapesModel model, Line line, int id)
        {
            _model = model;
            _line = line;
            _id = id;
        }

        public void Execute()
        {
            _model.RemoveLine(_id);
        }

        public void Undo()
        {
            _model.InsertLine(_id, _line);
        }
    }
}
