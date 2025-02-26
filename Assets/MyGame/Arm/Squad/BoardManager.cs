using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : Single<BoardManager>
{
    public List<GridCell> boardCells=new List<GridCell>();//�����ϵ�����
    public List<GridCell> benchCells=new List<GridCell>();//��սϯ�ϵ�����
    public GameObject draggedPiece;
    private Vector3 originalPosition;


    public void OnDragPieceDown(GameObject piece)
    {
        // ��¼��ǰ����ק�����Ӷ���
        draggedPiece = piece;
        // ��¼���ӵ�ԭʼλ��
        originalPosition = piece.transform.position;

        // ������սϯ�ĸ��ӣ����ұ���ק�������ڵĸ���
        foreach (var cell in benchCells)
        {
            if (cell.piece == piece)
            {
                // ��Ǹø���Ϊ�գ���û������
                cell.hasPiece = false;
                cell.piece = null;
                break;
            }
        }
        // �������̵ĸ��ӣ����ұ���ק�������ڵĸ���
        foreach (var cell in boardCells)
        {
            if (cell.piece == piece)
            {
                // ��Ǹø���Ϊ�գ���û������
                cell.hasPiece = false;
                cell.piece = null;
                break;
            }
        }
    }
    public void OnPieceDragEnd()
    {
        if (draggedPiece != null)
        {
            // �ҵ��뱻��ק���ӵ�ǰλ������ĸ���
            GridCell targetCell = FindNearestCell(draggedPiece.transform.position);
            if (targetCell != null)
            {
                if (!targetCell.hasPiece)
                {
                    // ���Ŀ�����û�����ӣ�������ק������ֱ�ӷ��õ��ø��ӵ�λ��
                    draggedPiece.transform.position = targetCell.position;
                    targetCell.hasPiece = true;
                    targetCell.piece = draggedPiece;
                }
                else
                {
                    // ���Ŀ����������ӣ���ȡ�ø����ϵ����Ӷ���
                    GameObject otherPiece = targetCell.piece;
                    // ���������ƶ�������ק���ӵ�ԭʼλ��
                    otherPiece.transform.position = originalPosition;

                    // ������սϯ�ĸ��ӣ�������һ������ԭ�����ڵĸ��Ӳ����Ϊ��
                    foreach (var cell in benchCells)
                    {
                        if (cell.piece == otherPiece)
                        {
                            cell.hasPiece = false;
                            cell.piece = null;
                            break;
                        }
                    }
                    // �������̵ĸ��ӣ�������һ������ԭ�����ڵĸ��Ӳ����Ϊ��
                    foreach (var cell in boardCells)
                    {
                        if (cell.piece == otherPiece)
                        {
                            cell.hasPiece = false;
                            cell.piece = null;
                            break;
                        }
                    }
                    draggedPiece.transform.position = targetCell.position;
                    
                    targetCell.piece = draggedPiece;
                    targetCell.hasPiece = true;

                    // ����һ�����ӷŻ�ԭ����λ�ã�������Ӧ���ӵ���Ϣ
                    foreach (var cell in benchCells)
                    {
                        if (cell.position == originalPosition)
                        {
                            cell.hasPiece = true;
                            cell.piece = otherPiece;
                            break;
                        }
                    }
                    foreach (var cell in boardCells)
                    {
                        if (cell.position == originalPosition)
                        {
                            cell.hasPiece = true;
                            cell.piece = otherPiece;
                            break;
                        }
                    }
                }
            }
            else
            {
                // ���û���ҵ����ʵĸ��ӣ�������ק�����ӷŻ�ԭ����λ��
                draggedPiece.transform.position = originalPosition;
                // �ҵ�ԭ���ĸ��Ӳ�������Ϣ����Ǹø���������
                foreach (var cell in benchCells)
                {
                    if (cell.position == originalPosition)
                    {
                        cell.hasPiece = true;
                        cell.piece = draggedPiece;
                        break;
                    }
                }
                foreach (var cell in boardCells)
                {
                    if (cell.position == originalPosition)
                    {
                        cell.hasPiece = true;
                        cell.piece = draggedPiece;
                        break;
                    }
                }
            }
            // ��ק��������յ�ǰ����ק�����Ӷ���
            draggedPiece = null;
        }
    }

    // �ҵ���ָ��λ������ĸ��ӵķ���
    private GridCell FindNearestCell(Vector3 position)
    {
        GridCell nearestCell = null;
        float minDistance = float.MaxValue;

        // �������̵ĸ���
        foreach (var cell in boardCells)
        {
            float distance = Vector3.Distance(position, cell.position);
            if (distance < minDistance)
            {
                // ������С��������������Ϣ
                minDistance = distance;
                nearestCell = cell;
            }
        }
        // ������սϯ�ĸ���
        foreach (var cell in benchCells)
        {
            float distance = Vector3.Distance(position, cell.position);
            if (distance < minDistance)
            {
                // �����ǰ���Ӿ��������������С��������������Ϣ
                minDistance = distance;
                nearestCell = cell;
            }
        }
        return nearestCell;
    }
}


