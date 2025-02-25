using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBegain : MonoBehaviour
{
    // Start is called before the first frame update
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
