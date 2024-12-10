using System;
using 視窗流程圖.Models;

namespace 視窗流程圖.Commands
{
    public class InsertLineCommand : ICommand
    {
        private readonly ShapesModel _model;
        private readonly Line _line;
        private readonly int _id;

        public InsertLineCommand(ShapesModel model, Line line, int id)
        {
            _model = model;
            _line = line;
            _id = id;
        }

        public void Execute()
        {
            _model.InsertLine(_id, _line);
        }

        public void Undo()
        {
            _model.RemoveLine(_id);
        }
    }
}
