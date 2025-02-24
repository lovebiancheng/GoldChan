using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

public class LuaManger : Single<LuaManger>
{
    private LuaEnv luaEnv;
    public LuaTable MyLuaTable
    {
        get
        {
            return luaEnv.Global;
        }
    }
    public void Initialize()
    {
        if (luaEnv == null) 
        { 
            luaEnv = new LuaEnv();
            luaEnv.AddLoader(Loader);
            //luaEnv.AddLoader(LoaderAB);
        }
    }
    /// <summary>
    /// �ض���
    /// </summary>
    /// <param name="filePath">�ļ�����</param>
    /// <returns></returns>
    public byte[] Loader(ref string filePath)
    {
        //string path=Path.Combine(Application.dataPath, "MyLuaScripts", filePath,".lua");
        string path = Application.dataPath+ "/MyLuaScripts/" + filePath+".lua";
        Debug.Log("�ļ���"+path);
        if (File.Exists(path)) 
        { 
            return File.ReadAllBytes(path);
        }
        else
        {
            Debug.Log("�ض���ʧ��");
            return null;
        }
    }
    /// <summary>
    /// AB���ض���
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public byte[] LoaderAB(ref string filePath) 
    {
        Debug.Log("AB���ض���");
        string path = Path.Combine(Application.dataPath, "MyLuaScripts");
        AssetBundle ab=AssetBundle.LoadFromFile(path);
        TextAsset tAsset=ab.LoadAsset<TextAsset>(filePath+".lua");
        return tAsset.bytes;

    }
    /// <summary>
    /// ִ��lua����
    /// </summary>
    /// <param name="luaLanguage"></param>
    public void DoString(string luaLanguage)
    {
        if (luaEnv != null)
        {
            luaEnv.DoString(luaLanguage);
        }
        else 
        {
            Debug.Log("������δ��ʼ��");
        
        }
    }
    /// <summary>
    /// require lua�ű�
    /// </summary>
    /// <param name="luaScript"></param>
    public void DoStringLuaScript(string luaScript)
    {
        if (luaEnv != null)
        {
            string temp=String.Format("require('{0}')",luaScript);
            luaEnv.DoString(temp);
        }
        else
        {
            Debug.Log("������δ��ʼ��");

        }
    }

    public void OnTick()
    {
        luaEnv.Tick();
    }
    public void OnDestroy() 
    { 
        luaEnv.Dispose();
    }
}
