using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���ܹ�����
/// �����б�
/// ���ɼ��ܣ�����Ԥ�Ƽ���Ԥ�Ƽ����ϴ��ż����ͷ���
/// </summary>
public class SkilManager : MonoBehaviour
{
    public Skill[] skills;//���һ���ȡ�������ݻ�������

    private void Start()
    {
        for(int i = 0; i < skills.Length; i++)
        {
            Init(skills[i]);
        }
    }
    public void Init(Skill tempSkill)
    {
        //tempSkill.skillName  ͨ�������ҵ�Ԥ����
        GameObject prefab = Resources.Load<GameObject>("prefab/"+tempSkill.skillName);
        tempSkill.skillPrefab = prefab;
        tempSkill.owner=gameObject;
    }
    public Skill PrepareSkill(int id)
    {
        Skill skill=new Skill();//ע������ҿ����ö��ֲ���
        for (int i = 0; i < skills.Length; i++) 
        {
            if (skills[i].skillID == id)
            {
                skill = skills[i];
                break;
            }
        }

        if (skill != null&&skill.coolRemain<=0&&skill.costSP>10) //�����Ǵ��ڽ�ɫ���ϵ�ʣ�෨��ֵ
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

        //���ټ��� Destroy(skill.skillPrefab);
        

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
