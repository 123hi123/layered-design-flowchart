using 視窗流程圖.Models;

namespace 視窗流程圖.Commands
{
    public class MoveTextCommand : ICommand
    {
        private Shape _shape;
        private int _oldTextX, _oldTextY;
        private int _newTextX, _newTextY;

        public MoveTextCommand(Shape shape, int newTextX, int newTextY)
        {
            _shape = shape;
            _oldTextX = shape.TextX;
            _oldTextY = shape.TextY;
            _newTextX = newTextX;
            _newTextY = newTextY;
        }

        public void Execute()
        {
            _shape.TextX = _newTextX;
            _shape.TextY = _newTextY;
        }

        public void Undo()
        {
            _shape.TextX = _oldTextX;
            _shape.TextY = _oldTextY;
        }
    }
}
