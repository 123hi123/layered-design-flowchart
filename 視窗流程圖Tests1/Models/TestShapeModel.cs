using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static 視窗流程圖.PresentationModels.ShapeSelectPreModel;
using 視窗流程圖.Models;

namespace 視窗流程圖Tests.Models
{
    public class TestShapeModel : ShapesModel
    {
        public new Dictionary<int, Shape> Shapes => base._shapes;

        // 覆蓋隨機文本生成方法，使其可預測
        protected new string GenerateRandomText()
        {
            return "TestShape";
        }

        // 添加一個方法來直接設置下一個 ID
        public void SetNextId(int id)
        {
            base._nextId = id;
        }

        // 添加一個方法來清除所有形狀
        public void ClearShapes()
        {
            Shapes.Clear();
            SetNextId(0);
        }

        // 覆蓋 AddShape 方法，使用可控的 Shape 創建
        public new int AddShape(ShapeData shapeData)
        {
            Shape shape = new TestShape(shapeData);
            int id = base._nextId++;
            Shapes.Add(id, shape);
            ReRenderSign?.Invoke();
            return id;
        }
    }

    
}
