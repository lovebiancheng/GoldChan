using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public GameObject attackGridCellPrefab;
    public GameObject benchGridCellPrefab;

    public GameObject bigPrefab;
    public GameObject smallPrefab;

    

    public Vector3 gridStartVector = new Vector3(-5.7f, -12.72f, -8.84f);
    public Vector3 boxAStartVector = new Vector3(-6.8f, -12.365f, -10.63f);
    public Vector3 boxBStartVector = new Vector3(6.8f, -12.365f, 4.15f);

    public float xDis = 1.9f;
    public float yDis = 1.6f;
    public float boxDis = 1.7f;


    public int xNum = 7;
    public int yNum = 8;
    public int boxXNum = 9;
    public int boxYNum = 2;
    public int eggXNum = 5;
    public int eggYNum = 2;

    public int bornNum = 5;
    public Vector3 bigStartVector1 = new Vector3(-8.52f, -11.90f, -8.17f);
    public Vector3 bigStartVector2 = new Vector3(8.63f, -11.90f, 1.51f);
    public Vector3 smallStartVector1 = new Vector3(0.54f, 0f, 0f);
    public Vector3 smallStartVector2 = new Vector3(15.36f, 0f, 5.06f);
    public float smallDis = 1.11f;


    private Vector3 bornVector;
    private GameObject bornGameobject;

    void Start()
    {

        
        CreatAttackGrid();
        CreatBenchGrid();
        CreatPedestal();
        CreatBornpoint();
    }

    void Update()
    {

    }

    public void CreatAttackGrid()
    {
        for (int i = 0; i < yNum; i++)
        {
            for (int j = 0; j < xNum; j++)
            {
                bornVector = new Vector3(gridStartVector.x + j * xDis, gridStartVector.y, gridStartVector.z + i * yDis);
                bornGameobject = Instantiate(attackGridCellPrefab, bornVector, Quaternion.identity);
                bornGameobject.AddComponent<Cell>();
                bornGameobject.GetComponent<Cell>().Init(bornVector,j, i,true);
                bornGameobject.name = string.Format("grid({0},{1})", i, j);
                //BoardManager.Instance.boardCells.Add(new GridCell(bornGameobject.transform.position));
            }
        }
    }
    public void CreatBenchGrid()
    {
        for (int i = 0; i < boxXNum; i++)
        {
            bornVector = new Vector3(boxAStartVector.x + i * boxDis, boxAStartVector.y, boxAStartVector.z);
            


            bornGameobject = Instantiate(benchGridCellPrefab, bornVector, Quaternion.identity);
            bornGameobject.AddComponent <Cell>();
            bornGameobject.GetComponent<Cell>().Init(bornVector,i, 0,false);
            bornGameobject.name = string.Format("boxA({0})", i);
        }
        for (int j = 0; j < boxXNum; j++)
        {
            bornVector = new Vector3(boxBStartVector.x - j * boxDis, boxBStartVector.y, boxBStartVector.z);
            bornGameobject = Instantiate(benchGridCellPrefab, bornVector, Quaternion.identity);
            bornGameobject.AddComponent<Cell>();
            bornGameobject.GetComponent<Cell>().Init(bornVector, j, 1,false);
            bornGameobject.name = string.Format("boxB({0})", j);
        }
    }
    public void CreatPedestal()
    {
        for (int i = 0; i < eggXNum; i++)
        {
            bornVector = new Vector3(smallStartVector1.x, smallStartVector1.y, smallStartVector1.z + i * smallDis);
            bornGameobject = Instantiate(smallPrefab, bornVector, Quaternion.identity);
            bornGameobject.AddComponent<Cell>();
            bornGameobject.GetComponent<Cell>().Init(bornVector, i, 0, false);
            bornGameobject.name = string.Format("pedestal({0})", i);
        }
        for (int j = 0; j < eggXNum; j++)
        {
            bornVector = new Vector3(smallStartVector2.x, smallStartVector2.y, smallStartVector2.z - j * smallDis);
            bornGameobject = Instantiate(smallPrefab, bornVector, Quaternion.identity);
            bornGameobject.AddComponent<Cell>();
            bornGameobject.GetComponent<Cell>().Init(bornVector, j, 1,false);
            bornGameobject.name = string.Format("pedestal({0})", j);
        }

    }
    public void CreatBornpoint()
    {
        Instantiate(bigPrefab, bigStartVector1, Quaternion.identity);
        Instantiate(bigPrefab, bigStartVector2, Quaternion.identity);
    }
}
