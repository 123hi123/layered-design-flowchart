using System;
using System.Data.OleDb;
using 視窗流程圖.Models;

namespace 視窗流程圖.Commands
{
    public class TextCommand : ICommand
    {
        private readonly ShapesModel _model;
        private readonly Shape _shape;
        private readonly string _old;
        private readonly string _new;

        public TextCommand(ShapesModel model, Shape shape,string oldText, string newText)
        {
            _model = model;
            _shape = shape;
            _old = oldText;
            _new = newText;
        }

        public void Execute()
        {
            _shape.ShapeName = _new;
            _model.ReRender();
        }

        public void Undo()
        {
            _shape.ShapeName = _old;
            _model.ReRender();
        }
    }
}
