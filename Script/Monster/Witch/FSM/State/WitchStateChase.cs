using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchStateChase : WitchFSMStateBase
{
    private float m_minDis;
    private WitchSkillBase m_useSkill;

    public override void BeginState()
    {
        m_minDis = Mathf.Infinity;
        m_useSkill = null;
        Witch.RotateToTarget(GameObject.Find("Player").transform.position);
    }

    void Update()
    {
        if ((m_useSkill = SelectSkill()) == null)
            Witch.SetState(WitchState.Idle);

        m_useSkill.OnSkill(GameObject.Find("Player").transform);
        Witch.SetState(WitchState.Run);
    }

    public override void EndState()
    {
    }

    private WitchSkillBase SelectSkill()
    {
        WitchSkillBase skill = null;

        foreach (WitchSkillBase s in Witch.SkillSys.Skills.Values)
        {
            if (s.Distance == 0.0f)
                continue;

            if (s.Distance >= m_minDis)
                continue;

            m_minDis = s.Distance;
            skill = s;
        }

        return skill;
    }
}
