using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleController : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    public Animator animator;

    private string idle= "Idle";
    private string walk = "Walk";
    private string normalAttack = "NormalAttack";
    private string skillAttack = "SkillAttack";
    private string dance = "Dance";
    private string death="Death";

    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
        HierarchicalStateMachine statemachine=new HierarchicalStateMachine(animator);
        StateRegistry registry = new StateRegistry();
        registry.RegHieraState(idle, new Idle());
        registry.RegHieraState(walk,new Walk());
        registry.RegHieraState(normalAttack, new NormalAttack());
        registry.RegHieraState(skillAttack, new SkillAttack());
        registry.RegHieraState(dance, new Dance());
        registry.RegHieraState(death, new Death());

        registry.RegAnimaState(idle, "Idle");
        registry.RegAnimaState(walk, "Walk");
        registry.RegAnimaState(normalAttack, "NormalAttack");
        registry.RegAnimaState(skillAttack, "SkillAttack");
        registry.RegAnimaState(dance, "Dance");
        registry.RegAnimaState(death, "Death");
        statemachine.ChangeAnimatorState(registry.AnimatorRegDic[idle]);
        statemachine.SwitchHireachicalState(registry.HieraRegDic[idle]);
        
    }

    // Update is called once per frame
    void Update()
    {
        
      
    }
}
