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

        //ƫ����
        //���������λ�ò�һ�����������ģ�������Ҫ���µ���갴��ʱ����������֮��ľ���
        //�������������֮�����Ծ���
        /*Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.WorldToScreenPoint(transform.position).z));
         * ����Ļ�����ת��Ϊ���������
         * ----------------------------------------------------------
         * Camera.main.WorldToScreenPoint(transform.position).z)
         * ����������ת��Ϊ��Ļ���꣬x��y�������λ�þ�����zλ����Ҫ����ȷ���������������ϵ�е����
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
        //���0.1�����ڵ���ײ��
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
