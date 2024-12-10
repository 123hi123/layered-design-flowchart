using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using 視窗流程圖.Models;

namespace 視窗流程圖.PresentationModels
{
    public class DataGridPreModel
    {
        // 定?一??除事件
        public event EventHandler<int> DeleteShapeRequested;
        public event EventHandler<int> DeleteLineRequested;

        // ?查并?理?除操作的方法
        public void HandleDeleteRequest(int columnIndex, int rowIndex, int deleteButtonColumnIndex, string type)
        {
            if (IsDeleteButtonClicked(columnIndex, rowIndex, deleteButtonColumnIndex))
            {
                if (type != "Line")
                {
                    OnDeleteShapeRequested(rowIndex);
                }
                else
                {
                    OnDeleteLineRequested(rowIndex);
                }
                // 如果?件?足，触??除事件

            }
        }

        // ?查是否??了?除按?
        private bool IsDeleteButtonClicked(int columnIndex, int rowIndex, int deleteButtonColumnIndex)
        {
            return columnIndex == deleteButtonColumnIndex && rowIndex >= 0;
        }

        // 触??除事件的方法
        protected virtual void OnDeleteShapeRequested(int rowIndex)
        {
            DeleteShapeRequested?.Invoke(this, rowIndex);
        }
        protected virtual void OnDeleteLineRequested(int rowIndex)
        {
            DeleteLineRequested?.Invoke(this, rowIndex);
        }

        public int GetIdFromCellValue(object cellValue)
        {
            if (cellValue == null)
            {
                return -1; // 或者其他表示?效 ID 的值
            }

            string cellValueString = cellValue.ToString();
            if (int.TryParse(cellValueString, out int id))
            {
                return id;
            }

            return -1; // 解析失??返回?效 ID
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
    }
}
