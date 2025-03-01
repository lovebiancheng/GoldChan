using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 技能管理器
/// 技能列表
/// 生成技能，生成预制件，预制件身上带着技能释放器
/// </summary>
public class SkilManager : MonoBehaviour
{
    public Skill[] skills;//最后一般读取本地数据或者联网

    private void Start()
    {
        for(int i = 0; i < skills.Length; i++)
        {
            Init(skills[i]);
        }
    }
    public void Init(Skill tempSkill)
    {
        //tempSkill.skillName  通过名称找到预制体
        GameObject prefab = Resources.Load<GameObject>("prefab/"+tempSkill.skillName);
        tempSkill.skillPrefab = prefab;
        tempSkill.owner=gameObject;
    }
    public Skill PrepareSkill(int id)
    {
        Skill skill=new Skill();//注这里查找可以用二分查找
        for (int i = 0; i < skills.Length; i++) 
        {
            if (skills[i].skillID == id)
            {
                skill = skills[i];
                break;
            }
        }

        if (skill != null&&skill.coolRemain<=0&&skill.costSP>10) //这里是大于角色身上的剩余法力值
        {
            return skill;
        }
        else
        {
            return null;
        }
    }

    public void GenerateSkill(Skill skill)
    {
        Instantiate(skill.skillPrefab, transform.position, Quaternion.identity);

        //销毁技能 Destroy(skill.skillPrefab);
        

        StartCoroutine(CoolTimeDown(skill));
    }

    public IEnumerator CoolTimeDown(Skill skill)
    {
        skill.coolRemain = skill.coolTime;
        while (skill.coolRemain > 0) 
        {
            yield return new WaitForSeconds(1);
            skill.coolRemain--;

        }
    }
}
