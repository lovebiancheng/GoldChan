using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBegain : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Data.Instance.Initialize();
        UIStatemachine.Instance.Init();
        if (UIStatemachine.Instance.isLogin)
        {
            UIStatemachine.Instance.ChangeState(UIState.MainState);
        }
        else
        {
            UIStatemachine.Instance.ChangeState(UIState.LoginState);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
