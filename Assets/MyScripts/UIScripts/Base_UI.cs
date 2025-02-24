using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_UI : MonoBehaviour
{
    public virtual void Enter()
    {
        Debug.Log(this.GetType().Name);
    }

    public virtual void Exit()
    {
        this.gameObject.SetActive(false);
    }
    public virtual void Initialize()
    {

    }
    public virtual void LuaInitialize()
    {

    }
}
