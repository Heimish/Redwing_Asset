using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchSkillA : WitchSkillBase
{
    private WitchSkillAObject m_obj;

    public WitchSkillA(WitchBoss witch, float distance) : base(witch)
    {
        m_distance = distance;
        m_obj = GameObject.FindObjectOfType<WitchSkillAObject>();
        m_obj.gameObject.SetActive(false);
        m_obj.Init(witch);
    }

    public override void OnSkill(Transform target)
    {
        m_obj.gameObject.SetActive(true);
        m_obj.OnSkill(target);
    }
}
