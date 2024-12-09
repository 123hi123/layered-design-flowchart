﻿using System;
using System.Collections.Generic;
using 視窗流程圖.Models;

namespace 視窗流程圖.PresentationModels
{
    public class DataGridPreModel
    {
        // 定义一个删除事件
        public event EventHandler<int> DeleteRequested;

        // 检查并处理删除操作的方法
        public void HandleDeleteRequest(int columnIndex, int rowIndex, int deleteButtonColumnIndex)
        {
            if (IsDeleteButtonClicked(columnIndex, rowIndex, deleteButtonColumnIndex))
            {
                // 如果条件满足，触发删除事件
                OnDeleteRequested(rowIndex);
            }
        }

        // 检查是否点击了删除按钮
        private bool IsDeleteButtonClicked(int columnIndex, int rowIndex, int deleteButtonColumnIndex)
        {
            return columnIndex == deleteButtonColumnIndex && rowIndex >= 0;
        }

        // 触发删除事件的方法
        protected virtual void OnDeleteRequested(int rowIndex)
        {
            DeleteRequested?.Invoke(this, rowIndex);
        }

        public int GetIdFromCellValue(object cellValue)
        {
            if (cellValue == null)
            {
                return -1; // 或者其他表示无效 ID 的值
            }

            string cellValueString = cellValue.ToString();
            if (int.TryParse(cellValueString, out int id))
            {
                return id;
            }

            return -1; // 解析失败时返回无效 ID
        }

        public int FindRowIndexById(object[] idValues, int targetId)
        {
            for (int i = 0; i < idValues.Length; i++)
            {
                if (Convert.ToInt32(idValues[i]) == targetId)
                {
                    return i;
                }
            }
            return -1;
        }

        //// 新增方法：根据 rowIndex 和 shapesData 获取 ShapeData
        //public ShapeData GetShapeDataFromRow(int rowIndex, object[] row)
        //{
        //    // 使用 for 循环来找到对应的 ShapeData
        //    for (int i = 0; i < shapesData.Count; i++)
        //    {
        //        if (i == rowIndex)
        //        {
        //            return shapesData[i];
        //        }
        //    }

        //    return null; // 如果没有找到，返回 null
        //}
    }
}
