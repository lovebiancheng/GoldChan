using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool :Single<ObjectPool>
{
    private int capacity = 10;
    private Dictionary<string, List<GameObject>> objectPoolDic;
    public ObjectPool() 
    { 
        
    }
    public void InitializePool(string item)
    {
        GameObject prefab=new GameObject();
        objectPoolDic=new Dictionary<string, List<GameObject>>();
        if (!objectPoolDic.ContainsKey(item))
        {
            objectPoolDic[item]=new List<GameObject>();
            for (int i = 0; i < capacity; i++) 
            {
                GameObject obj=GameObject.Instantiate(prefab);
                obj.SetActive(false);
                objectPoolDic[item].Add(obj);
            }
        }
    }
   
}
