namespace 視窗流程圖.Adapter
{
    // 定義一個二維點結構，用於模型層和 IGraphics 的內部使用
    public struct Point2D
    {
        public float X { get; }
        public float Y { get; }

        public Point2D(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}