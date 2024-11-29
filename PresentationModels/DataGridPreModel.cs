using System;

namespace 視窗流程圖.PresentationModels
{
    public class DataGridPreModel
    {
        // 定義一個刪除事件
        public event EventHandler<int> DeleteRequested;

        // 檢查並處理刪除操作的方法
        public void HandleDeleteRequest(int columnIndex, int rowIndex, int deleteButtonColumnIndex)
        {
            if (IsDeleteButtonClicked(columnIndex, rowIndex, deleteButtonColumnIndex))
            {
                // 如果條件滿足，觸發刪除事件
                OnDeleteRequested(rowIndex);
            }
        }

        // 檢查是否點擊了刪除按鈕
        private bool IsDeleteButtonClicked(int columnIndex, int rowIndex, int deleteButtonColumnIndex)
        {
            return columnIndex == deleteButtonColumnIndex && rowIndex >= 0;
        }

        // 觸發刪除事件的方法
        protected virtual void OnDeleteRequested(int rowIndex)
        {
            DeleteRequested?.Invoke(this, rowIndex);
        }

        public int GetIdFromCellValue(object cellValue)
        {
            if (cellValue == null)
            {
                return -1; // 或者其他表示無效 ID 的值
            }

            string cellValueString = cellValue.ToString();
            if (int.TryParse(cellValueString, out int id))
            {
                return id;
            }

            return -1; // 解析失敗時返回無效 ID
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