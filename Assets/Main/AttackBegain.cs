using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBegain : MonoBehaviour
{
    //ս��������ӵ�е�Ǯ��
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
