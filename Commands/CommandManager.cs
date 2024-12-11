using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using 視窗流程圖.Commands;
using 視窗流程圖.Models;

namespace 視窗流程圖
{
    public class CommandManager
    {

        private Stack<ICommand> _undoStack = new Stack<ICommand>();
        private Stack<ICommand> _redoStack = new Stack<ICommand>();
        private ShapesModel _model; 
        public CommandManager(ShapesModel model)
        {
            _model = model;
        }
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _undoStack.Push(command);
            _redoStack.Clear(); // 清除重做栈，因为执行了新的命令
            _model.ChangeOfCommandHistory();
        }
        public bool UndoState()
        {
            return _undoStack.Count > 0;
        }
        public bool RedoState()
        {
            return _redoStack.Count > 0;
        }

        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                ICommand command = _undoStack.Pop();
                command.Undo();
                _redoStack.Push(command);
                _model.ChangeOfCommandHistory();
            }
        }

        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                ICommand command = _redoStack.Pop();
                command.Execute();
                _undoStack.Push(command);
                _model.ChangeOfCommandHistory();
            }
        }
    }
}
