using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Drag : MonoBehaviour
{

    private bool isSelected;

    private GameObject selectedObject;
    private GameObject secondObject;
    private Cell firstCell;
    private Cell secondCell;

    private bool isAttack;

    //private Vector2Int startIndex;
    //private Vector3 startVector;

    //private Vector2Int endIndex;
    //private Vector3 endVector;

    private float yOld = 9f;
    private float yNew = 9.5f;


    private Vector3 offSetDistance;//偏移量
    private Vector3 tempPosition;

    private float fixedY;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isSelected)
            {
                isSelected=false;
                secondCell = CheckGrid();
                if (secondCell == null)
                {
                    selectedObject.transform.position = firstCell.position;
                    AddList(firstCell.isAttack,firstCell.vector,selectedObject);
                    selectedObject = null;
                    Debug.Log("空的，我滚回去了");
                    return;
                }
                else
                {
                    
                    if (secondCell.isOccupied)//第二格中有物体，交换
                    {
                        RemoveList(firstCell.isAttack,secondCell.vector,secondCell.piece);

                        secondCell.piece.transform.position = firstCell.position;
                        AddList(firstCell.isAttack,firstCell.vector,secondCell.piece);

                        selectedObject.gameObject.transform.position = secondCell.position;
                        AddList(secondCell.isAttack,secondCell.vector,selectedObject);

                        selectedObject = null;
                        return;
                    }
                    else
                    {
                        Debug.Log("这是空的，我就待在这了");
                        firstCell.isOccupied = false;
                        selectedObject.transform.position = secondCell.position;
                        AddList(secondCell.isAttack, secondCell.vector, selectedObject);

                        selectedObject = null;
                        return;
                    }
                    
                }

            }
            if (!isSelected) 
            { 
                selectedObject=CheckPiece();
                if (selectedObject != null) 
                {
                    isSelected = true;
                    firstCell=CheckGrid();
                    

                    RemoveList(firstCell.isAttack,firstCell.vector,selectedObject);

                    selectedObject.gameObject.transform.position=new Vector3(selectedObject.gameObject.transform.position.x, selectedObject.gameObject.transform.position.y+0.5f, selectedObject.gameObject.transform.position.z);
                    //fixedDeepth = Camera.main.WorldToScreenPoint(selectedObject.transform.position).z;
                    fixedY = selectedObject.gameObject.transform.position.y;
                    offSetDistance =selectedObject.transform.position- Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z));
                }
                else
                {
                    Debug.Log("选中的棋子为空");
                    return;
                }

                
            }
        }
        if (isSelected&&selectedObject!=null) 
        {
            
            tempPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z));
            tempPosition=tempPosition+offSetDistance;
            tempPosition.y=fixedY;
            selectedObject.transform.position=tempPosition;
        }
    }
    
    public void RemoveList(bool isAttack,Vector2Int index,GameObject piece)
    {
        if (isAttack)
        {
            //移除战斗列表中！！！
        }
        else
        {
            //移除到备战列表中！！！
        }
    }
    public void AddList(bool isAttack, Vector2Int index, GameObject piece)
    {
        if (isAttack)
        {
            //添加到战斗列表中！！！
        }
        else
        {
            //添加到备战列表中！！！
        }
    }

    public Cell CheckGrid()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // 发射射线并获取所有碰撞信息
        RaycastHit[] hits = Physics.RaycastAll(ray);
        Cell cell;
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.CompareTag("Grid"))
            {
                cell = hits[i].collider.gameObject.GetComponent<Cell>();
                Debug.Log("格子"+cell.vector);
                return cell;
            }
        }
        return null;
    }

    public GameObject CheckPiece()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Piece"))
            {
                GameObject temp=hit.collider.gameObject;
                return temp;
            }
        }
        return null;
    }
}
