using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GeneratePrefabMap:Editor
{
    [MenuItem("Tools/Resources/GeneratePrefab")]
   public static void Generate()
    {
        //1生成资源配置文件
        string[] res=AssetDatabase.FindAssets("t:prefab",new string[]{"Resources/"});
        for (int i = 0; i < res.Length; i++) 
        {
            res[i]=AssetDatabase.GUIDToAssetPath(res[i]);
        }
        //2生成对应关系
        //3写入文件
    }
}
