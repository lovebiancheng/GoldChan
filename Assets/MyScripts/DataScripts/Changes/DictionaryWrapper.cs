using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DictionaryWrapper 
{
    public List<string> keys;
    public List<string> values;

    public void AddContent(string key, string value)
    {
        keys.Add(key);
        values.Add(value);
    }
    public Dictionary<string, string> ToDictionary()
    {
        Dictionary<string,string> dict = new Dictionary<string,string>();
        for (int i = 0; i < keys.Count; i++)
        { 
            dict[keys[i]] = values[i];
        }
        
        return dict;
    }
    public void Clear()
    { 
        keys.Clear();
        values.Clear();
    }
}
