using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatCube : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 startVector;
    public float xDis;
    public float yDis;
    public int xNum;
    public int yNum;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < yNum; i++)
        {
            for(int j = 0; j < xNum; j++)
            {
                Vector3 bornVec = new Vector3(startVector.x+j*xDis,startVector.y,startVector.z+i*yDis);
                GameObject temp= Instantiate(prefab,bornVec,Quaternion.identity);
                temp.name = string.Format("grid({0},{1})", i, j);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
