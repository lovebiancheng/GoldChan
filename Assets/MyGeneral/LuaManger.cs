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
    /// 重定向
    /// </summary>
    /// <param name="filePath">文件名称</param>
    /// <returns></returns>
    public byte[] Loader(ref string filePath)
    {
        //string path=Path.Combine(Application.dataPath, "MyLuaScripts", filePath,".lua");
        string path = Application.dataPath+ "/MyLuaScripts/" + filePath+".lua";
        Debug.Log("文件名"+path);
        if (File.Exists(path)) 
        { 
            return File.ReadAllBytes(path);
        }
        else
        {
            Debug.Log("重定向失败");
            return null;
        }
    }
    /// <summary>
    /// AB包重定向
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public byte[] LoaderAB(ref string filePath) 
    {
        Debug.Log("AB包重定向");
        string path = Path.Combine(Application.dataPath, "MyLuaScripts");
        AssetBundle ab=AssetBundle.LoadFromFile(path);
        TextAsset tAsset=ab.LoadAsset<TextAsset>(filePath+".lua");
        return tAsset.bytes;

    }
    /// <summary>
    /// 执行lua语言
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
            Debug.Log("解析器未初始化");
        
        }
    }
    /// <summary>
    /// require lua脚本
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
            Debug.Log("解析器未初始化");

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
