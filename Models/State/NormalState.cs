﻿using System;
using 視窗流程圖.Adapter;
using 視窗流程圖.Models;

namespace 視窗流程圖.States
{
    public class NormalState : IState
    {
        private Point2D? _startPoint;
        private Point2D? _currentPoint;
        public Point2D? TempStart { get; private set; } = null;
        public Point2D? TempEnd { get; private set; } = null;
        public string DrawingFrameType{ get; private set; } = null;

        public Point2D? CurrentPoint => _currentPoint;
        public Point2D? StartPoint => _startPoint;
        public Shape SelectedShape { get; private set; } = null;
        public int OriTextX, OriTextY;
        public int OriX, OriY;

        private DateTime _lastClickTime;
        private int _clickCount;
        private const int DoubleClickThreshold = 500; // milliseconds
        public Point2D? TouchedPoint { get; private set; } = null;


        public int SelectedIndex { get; private set; } = -1;

        protected ShapesModel _model;

        public void SetModel(ShapesModel model)
        {
            _model = model;
            DrawingFrameType = "Normal"; 
        }
        public void MouseDown(int x, int y, bool isDrawingMode)
        {
            var result = _model.FindShapeAtPosition(x, y);
            SelectedIndex = result.Item1;
            SelectedShape = result.Item2;
            if (SelectedShape != null)
            {
                // 記錄開始點
                _startPoint = new Point2D(x, y);
                OriTextX = SelectedShape.TextX;
                OriTextY = SelectedShape.TextY;
                OriX = SelectedShape.X;
                OriY = SelectedShape.Y;
                DateTime now = DateTime.Now;
                if ((now - _lastClickTime).TotalMilliseconds <= DoubleClickThreshold && SelectedShape.IsWithinOrangeDotRange(x, y))
                {
                    _clickCount++;
                    if (_clickCount == 2)
                    {
                        _model.DoubleClickOnText(SelectedIndex, SelectedShape);
                        _startPoint = null;
                        _clickCount = 0;
                    }
                }
                else
                {
                    _clickCount = 1;
                }
                _lastClickTime = now;
            }
            
        }

        public void MouseMove(int x, int y)
        {
            if (SelectedShape != null && StartPoint.HasValue)
            {
                // 計算移動距離
                int deltaX = (int)(x - StartPoint.Value.X);
                int deltaY = (int)(y - StartPoint.Value.Y);
                
                // Check if the text will stay within the shape's boundaries
                int newTextX = SelectedShape.TextX + deltaX;
                int newTextY = SelectedShape.TextY + deltaY;
                SelectedShape.TextX = newTextX;
                SelectedShape.TextY = newTextY;

                if (!SelectedShape.IsWithinOrangeDotRange(x, y))
                {
                    // 更新選中形狀的位置
                    SelectedShape.X += deltaX;
                    SelectedShape.Y += deltaY;
                }
                // 更新起始點
                _startPoint = new Point2D(x, y);
            }
        }

        public void MouseUp(int x, int y)
        {

            // 先保存起始點，再清空 for command
            _startPoint = null;
            if (SelectedShape != null && !SelectedShape.ContainsPoint(SelectedShape.TextX + (int)Math.Round(SelectedShape.TextWidth / 2), SelectedShape.TextY))
            {
                SelectedShape.TextX = OriTextX;
                SelectedShape.TextY = OriTextY;
            }
        }

    }
}
