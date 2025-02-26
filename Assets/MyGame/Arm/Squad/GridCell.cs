using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell 
{
    public Vector3 position;
    public GameObject piece;
    public bool hasPiece;
    public GridCell(Vector3 vector)
    {
        position = vector;
        piece = null;
        hasPiece = false;
    }
}
