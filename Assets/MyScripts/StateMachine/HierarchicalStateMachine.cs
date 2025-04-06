using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HierarchicalStateMachine
{
    


    private Animator animator;

    //当前正在
    private string currentAnimatorState;
    private HierarchicalState currentHireachicalState;
    

    public HierarchicalStateMachine(Animator animator)
    {
        this.animator = animator;
    }
    public void ChangeAnimatorState(string state)
    {
        if (currentAnimatorState == state) { return; }
        animator.Play(state);
        currentAnimatorState = state;
    }

    public void SwitchHireachicalState(HierarchicalState newState)
    {
        // 退出旧状态及其所有子状态
        currentHireachicalState?.Exit();
        currentHireachicalState = newState;
        currentHireachicalState?.Enter();
    }

    public void Update()
    {
        currentHireachicalState?.Update();
    }
}
