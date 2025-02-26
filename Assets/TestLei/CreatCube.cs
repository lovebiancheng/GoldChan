using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//格子起始位置和间距
//（-5.7，-12.72，-8.84） XDis +1.9 ; YDis +1.6
//备战席起始位置和间距
//(-6.8, -12.365, -10.63) XDis +1.7
//(6.8,-12.365,4.15)  XDis -1.7
public class CreatCube : MonoBehaviour
{
    public GameObject gridPrefab;
    public GameObject boxPrefab;
    public Vector3 gridStartVector=new Vector3(-5.7f,-12.72f,-8.84f);
    public Vector3 boxAStartVector=new Vector3(-6.8f, -12.365f, -10.63f);
    public Vector3 boxBStartVector = new Vector3(6.8f, -12.365f, 4.15f);
    public float xDis=1.9f;
    public float yDis=1.6f;

    public int xNum=7;
    public int yNum=8;

    public float boxDis=1.7f;

    public List<Vector3> gridListVector3=new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < yNum; i++)
        {
            for(int j = 0; j < xNum; j++)
            {
                Vector3 bornVec = new Vector3(gridStartVector.x+j*xDis,gridStartVector.y,gridStartVector.z+i*yDis);
                GameObject temp= Instantiate(gridPrefab,bornVec,Quaternion.identity);
                temp.name = string.Format("grid({0},{1})", i, j);
                gridListVector3.Add(temp.transform.position);
                BoardManager.Instance.boardCells.Add(new GridCell(temp.transform.position));
            }
        }
        for(int j = 0; j < 9; j++)
        {
            Vector3 bornVec = new Vector3(boxAStartVector.x + j * boxDis, boxAStartVector.y, boxAStartVector.z);
            GameObject temp = Instantiate(boxPrefab, bornVec, Quaternion.identity);
            temp.name = string.Format("boxA({0})", j);
            BoardManager.Instance.benchCells.Add(new GridCell(temp.transform.position));
        }
        for(int m=0; m < yNum; m++)
        {
            Vector3 bornVec = new Vector3(boxBStartVector.x - m * boxDis, boxBStartVector.y, boxBStartVector.z);
            GameObject temp = Instantiate(boxPrefab, bornVec, Quaternion.identity);
            temp.name = string.Format("boxA({0})", m);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
