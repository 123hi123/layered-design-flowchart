using System;

namespace 視窗流程圖.Commands
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
