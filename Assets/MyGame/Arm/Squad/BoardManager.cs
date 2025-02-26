using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : Single<BoardManager>
{
    public List<GridCell> boardCells=new List<GridCell>();//棋盘上的棋子
    public List<GridCell> benchCells=new List<GridCell>();//备战席上的棋子
    public GameObject draggedPiece;
    private Vector3 originalPosition;


    public void OnDragPieceDown(GameObject piece)
    {
        // 记录当前被拖拽的棋子对象
        draggedPiece = piece;
        // 记录棋子的原始位置
        originalPosition = piece.transform.position;

        // 遍历备战席的格子，查找被拖拽棋子所在的格子
        foreach (var cell in benchCells)
        {
            if (cell.piece == piece)
            {
                // 标记该格子为空，即没有棋子
                cell.hasPiece = false;
                cell.piece = null;
                break;
            }
        }
        // 遍历棋盘的格子，查找被拖拽棋子所在的格子
        foreach (var cell in boardCells)
        {
            if (cell.piece == piece)
            {
                // 标记该格子为空，即没有棋子
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
            // 找到离被拖拽棋子当前位置最近的格子
            GridCell targetCell = FindNearestCell(draggedPiece.transform.position);
            if (targetCell != null)
            {
                if (!targetCell.hasPiece)
                {
                    // 如果目标格子没有棋子，将被拖拽的棋子直接放置到该格子的位置
                    draggedPiece.transform.position = targetCell.position;
                    targetCell.hasPiece = true;
                    targetCell.piece = draggedPiece;
                }
                else
                {
                    // 如果目标格子有棋子，获取该格子上的棋子对象
                    GameObject otherPiece = targetCell.piece;
                    // 将该棋子移动到被拖拽棋子的原始位置
                    otherPiece.transform.position = originalPosition;

                    // 遍历备战席的格子，查找另一个棋子原来所在的格子并标记为空
                    foreach (var cell in benchCells)
                    {
                        if (cell.piece == otherPiece)
                        {
                            cell.hasPiece = false;
                            cell.piece = null;
                            break;
                        }
                    }
                    // 遍历棋盘的格子，查找另一个棋子原来所在的格子并标记为空
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

                    // 把另一个棋子放回原来的位置，更新相应格子的信息
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
                // 如果没有找到合适的格子，将被拖拽的棋子放回原来的位置
                draggedPiece.transform.position = originalPosition;
                // 找到原来的格子并更新信息，标记该格子有棋子
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
            // 拖拽结束，清空当前被拖拽的棋子对象
            draggedPiece = null;
        }
    }

    // 找到离指定位置最近的格子的方法
    private GridCell FindNearestCell(Vector3 position)
    {
        GridCell nearestCell = null;
        float minDistance = float.MaxValue;

        // 遍历棋盘的格子
        foreach (var cell in boardCells)
        {
            float distance = Vector3.Distance(position, cell.position);
            if (distance < minDistance)
            {
                // 更新最小距离和最近格子信息
                minDistance = distance;
                nearestCell = cell;
            }
        }
        // 遍历备战席的格子
        foreach (var cell in benchCells)
        {
            float distance = Vector3.Distance(position, cell.position);
            if (distance < minDistance)
            {
                // 如果当前格子距离更近，更新最小距离和最近格子信息
                minDistance = distance;
                nearestCell = cell;
            }
        }
        return nearestCell;
    }
}


