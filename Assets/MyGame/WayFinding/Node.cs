using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    public int x;
    public int y;
    public bool isWalkAble;
    public Node parent;//ָ�򸸽ڵ㣬���ڻ���·��

    public int gCost;//ʵ�ʴ���
    public int hCost;//Ԥ������
    public int fCost//���������ڵ�����ȼ�

    { 
        get 
        { 
            return gCost + hCost; 
        } 
    }
    public Node(int x,int y,bool isWalkAble)
    {
        this.x = x;
        this.y = y;
        this.isWalkAble = isWalkAble;
    }


}
