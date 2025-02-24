using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

[LuaCallCSharp]
public class Data:Single<Data>,IInitialize
{
    
    private string AccountDataPath
    {
        get
        {
            //Debug.Log(Application.persistentDataPath);
            return Application.persistentDataPath + "/accountDatas.json";
        }
    }
    public Dictionary<string,string> accountDic;
    public DictionaryWrapper tempWrapper;
    public void Initialize()
    {
        accountDic = new Dictionary<string, string>();
        tempWrapper= new DictionaryWrapper();
        ReadAccountData();
        
    }


    public void ReadAccountData()
    {
        if (File.Exists(AccountDataPath)) 
        { 
            string accountDataString=File.ReadAllText(AccountDataPath);
            //Dictionary<string, string> accountData =JsonUtility.FromJson<Dictionary<string, string>>(accountDataString);
            tempWrapper=JsonUtility.FromJson<DictionaryWrapper>(accountDataString);
            accountDic=tempWrapper.ToDictionary();
            Debug.Log("存储的账号密码数据数量"+accountDic.Count);
        }
        else
        {
            return;
        }
    }
    public void WriteAccountData() 
    {
        if (accountDic == null) 
        { 
            return; 
        }
        tempWrapper.Clear();
        foreach (KeyValuePair<string, string> pair in accountDic) 
        {
            tempWrapper.AddContent(pair.Key, pair.Value);
        }
        string temp=JsonUtility.ToJson(tempWrapper);
        File.WriteAllText(AccountDataPath,temp);
    }
    public string FindContentInDic(string key)
    {
        string temp= accountDic[key];
        return temp;
    }
}
