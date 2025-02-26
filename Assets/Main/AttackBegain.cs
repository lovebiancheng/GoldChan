using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBegain : MonoBehaviour
{
    //战斗过程中拥有的钱数
    public int money;
    void Start()
    {
        UIStatemachine.Instance.Init();
        UIStatemachine.Instance.CurrentStateDefult();
        UIStatemachine.Instance.ChangeState(UIState.PlayState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
