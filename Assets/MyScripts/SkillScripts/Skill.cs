using System;
using UnityEngine;

[System.Serializable]
public class Skill
{
    public int skillID;
    public string skillName;
    public string description;
    public int coolTime;
    public int coolRemain;
    public int costSP;
    public int attackDistance;
    public float attackAngle;
    public string[] attackTargetTags;
    public Transform[] attackTarges;
    public string[] impactType;
    public int nextBatterID;
    public float atkRation;
    public float durationTime;
    public float atkInterval;
    public GameObject owner;
    public GameObject skillPrefab;
    public string animationName;
    public string hitFxName;
    public string hitFxPrefab;
    public int leveal;
    public SkillAttackType attackType;
    public SelectorType selectorType;

}
[Serializable]
public enum SkillAttackType
{
    SingleAttack,
    SultiAttack,
}
[Serializable]
public enum SelectorType
{
    SectorSelector,
    SquareSelector
}