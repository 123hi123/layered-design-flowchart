using System;

namespace 視窗流程圖.Adapter
{
    public struct Point2D : IEquatable<Point2D>
    {
        public float X { get; }
        public float Y { get; }

        public Point2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        // 重寫 Equals 方法
        public override bool Equals(object obj)
        {
            return obj is Point2D other && Equals(other);
        }

        // IEquatable<Point2D> 的實現
        public bool Equals(Point2D other)
        {
            return X == other.X || Y == other.Y;
        }



        // 定義 == 運算符
        public static bool operator ==(Point2D left, Point2D right)
        {
            return left.Equals(right);
        }

        // 定義 != 運算符
        public static bool operator !=(Point2D left, Point2D right)
        {
            return !(left == right);
        }
    }
}