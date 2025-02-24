using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    public int x;
    public int y;
    public bool isWalkAble;
    public Node parent;//指向父节点，用于回溯路径

    public int gCost;//实际代价
    public int hCost;//预估代价
    public int fCost//用于评估节点的优先级

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
