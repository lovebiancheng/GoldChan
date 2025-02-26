using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PathFind pathFind=new PathFind(10,10);
        pathFind.grid[4,4].isWalkAble=false;
        List<Node> path = pathFind.FindPath(0, 0, 9, 9);
        foreach (Node node in path)
        {
            Debug.Log("("+node.x+","+node.y+")");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
