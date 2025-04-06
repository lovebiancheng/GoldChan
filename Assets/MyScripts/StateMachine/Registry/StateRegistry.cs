using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StateRegistry
{
    private Dictionary<string, string> TempAnimaRegDic;
    private Dictionary<string, HierarchicalState> TempHieraRegDic;

    public IReadOnlyDictionary<string, string> AnimatorRegDic => TempAnimaRegDic;
    public IReadOnlyDictionary<string, HierarchicalState> HieraRegDic => TempHieraRegDic;
    
    public StateRegistry() 
    {
        TempAnimaRegDic = new Dictionary<string, string>();
        TempHieraRegDic=new Dictionary<string, HierarchicalState>();
    }
    public void RegHieraState(string name,HierarchicalState state)
    {
        if (TempHieraRegDic.ContainsKey(name)) 
        {
            return;
        }
        else
        {
            TempHieraRegDic.Add(name, state);
        }
    }
    public void RegAnimaState(string name,string animationName)
    {
        if (TempAnimaRegDic.ContainsKey(name))
        {
            return;
        }
        else
        {
            TempAnimaRegDic.Add(name, animationName);
        }
    }

    public void ClearAll()
    {
        TempAnimaRegDic.Clear();
        TempHieraRegDic.Clear();
    }
}
