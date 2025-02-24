using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLua;

[LuaCallCSharp]
public class Add_UI :Single<Add_UI>
{
    public void AddText(Transform parentTransform, string message)
    {
        GameObject temp = new GameObject();
        temp.transform.parent = parentTransform;
        Text messageText = temp.AddComponent<Text>();
        messageText.text = message;
    }
}
