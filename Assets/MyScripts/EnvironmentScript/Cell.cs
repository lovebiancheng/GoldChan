using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell:MonoBehaviour
{
    public bool isOccupied;
    public bool isAttack;
    public Vector3 position;
    public Vector2Int vector;
    public GameObject piece;
    public void Init (Vector3 cellPos,int x,int y,bool isattack)
    {
        isOccupied = false;
        isAttack =isattack;
        position = cellPos;
        vector.x = x; vector.y = y;
        
    }
}
