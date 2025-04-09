using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 对象池类
/// </summary>
public class ObjectPool:MonoBehaviour 
{
    public static ObjectPool Instance;

    [System.Serializable]
    public class Pool
    {
        public string tag; //每个池的标签（Tag）
        public GameObject prefab;//预制体（Prefab）
        public int size;//初始大小（Size）
    }

    public List<Pool> pools;
    private Dictionary<string, Queue<GameObject>> poolDictionary;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab, transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);//池子标签，队列
        }
    }


    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning($"Pool with tag {tag} doesn't exist.");
            return null;
        }

        Queue<GameObject> poolQueue = poolDictionary[tag];
        if (poolQueue.Count == 0)
        {
            // 动态扩展池：实例化新对象
            GameObject newObj=Instantiate(pools.Find(p=>p.tag == tag).prefab, transform);
            newObj.SetActive(false);
            poolQueue.Enqueue(newObj);
        }

        GameObject obj = poolQueue.Dequeue();
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);

        // 调用对象的初始化方法
        IPooledObject pooledObj = obj.GetComponent<IPooledObject>();
        pooledObj?.OnObjectSpawn();

        return obj;
    }

    public void ReturnToPool(string tag, GameObject obj)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning($"Pool with tag {tag} doesn't exist.");
            return;
        }

        obj.SetActive(false);
        poolDictionary[tag].Enqueue(obj);
    }



    //private int capacity = 10;
    //private Dictionary<string, List<GameObject>> objectPoolDic;
    //public void InitializePool(string item)
    //{
    //    GameObject prefab=new GameObject();
    //    objectPoolDic=new Dictionary<string, List<GameObject>>();
    //    if (!objectPoolDic.ContainsKey(item))
    //    {
    //        objectPoolDic[item]=new List<GameObject>();
    //        for (int i = 0; i < capacity; i++) 
    //        {
    //            GameObject obj=GameObject.Instantiate(prefab);
    //            obj.SetActive(false);
    //            objectPoolDic[item].Add(obj);
    //        }
    //    }
    //}

    //public void ReturnToPool(GameObject temp)
    //{
    //    temp.SetActive(false);

}

    
   

