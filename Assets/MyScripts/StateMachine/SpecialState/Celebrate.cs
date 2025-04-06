using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celebrate : HierarchicalState
{
    public override void Enter()
    {
        base.Enter();
        Debug.Log("ฝ๘ศ๋มห: " + GetType().Name);
    }
}
