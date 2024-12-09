using 視窗流程圖.Models;

namespace 視窗流程圖.Commands
{
    public class MoveShapeCommand : ICommand
    {
        private Shape _shape;
        private int _oldX, _oldY;
        private int _newX, _newY;

        public MoveShapeCommand(Shape shape, int newX, int newY)
        {
            _shape = shape;
            _oldX = shape.X;
            _oldY = shape.Y;
            _newX = newX;
            _newY = newY;
        }

        public void Execute()
        {
            _shape.X = _newX;
            _shape.Y = _newY;
        }

        public void Undo()
        {
            _shape.X = _oldX;
            _shape.Y = _oldY;
        }
    }
}
