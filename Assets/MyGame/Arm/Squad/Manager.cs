using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements;

public class Manager : MonoBehaviour
{
    


    public Dictionary<Vector2Int,GameObject> prepareDic;
    public Dictionary<Vector2Int, GameObject> attackDic;

    public Cell[,] benchGridCells;
    public Cell[,] attackGridCells;
    public Cell[,] eggGridCells;

    public Vector3 startVector=new Vector3(-6.65f,-12.72f,-9.64f);//
    public float xDis = 1.9f;
    public float yDis = 1.6f;

    public EnvironmentStart environment;

    private GameObject operand;//接下来要操作的对象

    // Start is called before the first frame update
    void Start()
    {
        prepareDic = new Dictionary<Vector2Int, GameObject>();
        attackDic= new Dictionary<Vector2Int, GameObject>();
        if (environment != null) 
        {
            this.benchGridCells=environment.benchGridCells;
            this.attackGridCells=environment.attackGridCells;
            this.eggGridCells=environment.eggGridCells;
        }
    }

    public void MoveToBlank()
    {
        
    }
    public void Exchange()
    {

    }

    public void WorldPointToIndex(Vector3 worldPoint)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
