using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GeneratePrefabMap:Editor
{
    [MenuItem("Tools/Resources/GeneratePrefab")]
   public static void Generate()
    {
        //1������Դ�����ļ�
        string[] res=AssetDatabase.FindAssets("t:prefab",new string[]{"Resources/"});
        for (int i = 0; i < res.Length; i++) 
        {
            res[i]=AssetDatabase.GUIDToAssetPath(res[i]);
        }
        //2���ɶ�Ӧ��ϵ
        //3д���ļ�
    }
}
