using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public bool isOccupied;
    public Vector3 position;
    public Cell(Vector3 cellPos)
    {
        isOccupied = false;
        position = cellPos;

    }
}
