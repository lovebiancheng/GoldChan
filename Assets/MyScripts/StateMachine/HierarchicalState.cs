using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HierarchicalState
{
    // 当前状态的子状态（用于嵌套）
    protected HierarchicalState currentSubState;

    // 进入状态时调用
    public virtual void Enter() { }

    // 退出状态时调用
    public virtual void Exit() { }

    // 每帧更新
    public virtual void Update()
    {
        // 更新当前子状态（如果存在）
        currentSubState?.Update();
    }

    // 切换子状态
    public void SwitchSubState(HierarchicalState newSubState)
    {
        currentSubState?.Exit();
        currentSubState = newSubState;
        currentSubState?.Enter();
    }
}
