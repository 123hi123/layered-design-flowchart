using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using �����y�{��.Models;

namespace �����y�{��.PresentationModels
{
    public class DataGridPreModel
    {
        // �w?�@??���ƥ�
        public event EventHandler<int> DeleteShapeRequested;
        public event EventHandler<int> DeleteLineRequested;

        // ?�d�}?�z?���ާ@����k
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
                // �p�G?��?���A�D??���ƥ�

            }
        }

        // ?�d�O�_??�F?����?
        private bool IsDeleteButtonClicked(int columnIndex, int rowIndex, int deleteButtonColumnIndex)
        {
            return columnIndex == deleteButtonColumnIndex && rowIndex >= 0;
        }

        // �D??���ƥ󪺤�k
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
                return -1; // �Ϊ̨�L���?�� ID ����
            }

            string cellValueString = cellValue.ToString();
            if (int.TryParse(cellValueString, out int id))
            {
                return id;
            }

            return -1; // �ѪR��??��^?�� ID
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
