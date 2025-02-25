using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPiece:MonoBehaviour
{
    private bool isDrag=false;
    private Vector3 offSetDistance;
    private float yPoint;
    private void OnMouseDown()
    {
        
        isDrag = true;
        yPoint=transform.position.y;

        //偏移量
        //由于鼠标点击位置不一定是物体中心，所以需要记下当鼠标按下时和物体中心之间的距离
        //保持物体与鼠标之间的相对距离
        /*Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.WorldToScreenPoint(transform.position).z));
         * 将屏幕坐标点转换为世界坐标点
         * ----------------------------------------------------------
         * Camera.main.WorldToScreenPoint(transform.position).z)
         * 将世界坐标转换为屏幕坐标，x，y都由鼠标位置决定，z位置需要用来确定鼠标在世界坐标系中的深度
         */
        offSetDistance = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.WorldToScreenPoint(transform.position).z));
    }
    private void OnMouseDrag()
    {
        if (isDrag) 
        { 
            Vector3 newPosition= Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z));
            Vector3 temp = newPosition+offSetDistance;
            temp.y = yPoint;
            transform.position = temp;
        }
    }
    
    private void OnMouseUp()
    {
        isDrag=false;
        CheckPosition();
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
}
