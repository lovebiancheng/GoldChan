using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class DragPiece:MonoBehaviour
{
    public float height = 0.5f;
    private Vector3 offSetDistance;
    private float yOldPoint;
    private float yNewPoint;
    private Vector3 tempPosition;
    private Vector3 newPos;
    private GameObject selectedObject;

    private bool hasSelected=false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (hasSelected)
            {
                newPos.y = yOldPoint;
                selectedObject.transform.position = newPos;
                hasSelected = false;
                BoardManager.Instance.OnPieceDragEnd();
                return;
            }
            if (!hasSelected)
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.CompareTag("Piece"))
                    {
                        //if (hit.collider.gameObject == gameObject)
                        //{
                            //选中
                            selectedObject = hit.collider.gameObject;
                            yOldPoint = selectedObject.transform.position.y;
                            yNewPoint = yOldPoint + height;
                            selectedObject.transform.position = new Vector3(selectedObject.transform.position.x, yNewPoint, selectedObject.transform.position.z);
                            offSetDistance = selectedObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z));
                            hasSelected = true;
                            BoardManager.Instance.OnDragPieceDown(selectedObject);
                        //}
                    }
                    
                }
                
            }
            
        }
        if (hasSelected) 
        {
            tempPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z));
            newPos = tempPosition + offSetDistance;
            newPos.y = yNewPoint;
            selectedObject.transform.position = newPos;
        }
    }






    /*
    private void OnMouseDown()
    {
        
        isDrag = true;
        yOldPoint=transform.position.y;
        BoardManager.Instance.OnDragPieceDown(this.gameObject);
        //偏移量
        //由于鼠标点击位置不一定是物体中心，所以需要记下当鼠标按下时和物体中心之间的距离
        //保持物体与鼠标之间的相对距离
        /*Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.WorldToScreenPoint(transform.position).z));
         * 将屏幕坐标点转换为世界坐标点
         * ----------------------------------------------------------
         * Camera.main.WorldToScreenPoint(transform.position).z)
         * 将世界坐标转换为屏幕坐标，x，y都由鼠标位置决定，z位置需要用来确定鼠标在世界坐标系中的深度
         //
        offSetDistance = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.WorldToScreenPoint(transform.position).z));
    }
    private void OnMouseDrag()
    {
        if (isDrag) 
        { 
            Vector3 newPosition= Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z));
            Vector3 temp = newPosition+offSetDistance;
            temp.y = yOldPoint;
            transform.position = temp;
        }
        else
        {

        }
    }
    
    private void OnMouseUp()
    {
        isDrag=false;
        BoardManager.Instance.OnPieceDragEnd();
        //CheckPosition();
    }
    private void CheckPosition()
    {
        //检测0.1米以内的碰撞体
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f);

        foreach (Collider collider in colliders)
        {

            if (collider.CompareTag("DropZone"))
            {
                transform.position = collider.transform.position;
                break;
            }
        }
    }
*/
}
