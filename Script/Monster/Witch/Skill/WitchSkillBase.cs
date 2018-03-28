using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchSkillBase
{
    protected WitchBoss m_witch;
    protected GameObject m_skillResource;
    protected float m_distance;

    // properties
    public WitchBoss Witch { get { return m_witch; } }
    public float Distance { get { return m_distance; } }

    public WitchSkillBase() {   }
    public WitchSkillBase(WitchBoss witch)
    {
        m_witch = witch;
    }

    public virtual void OnSkill()
    {
    }

    public virtual void OnSkill(Transform target)
    {

    }

    public virtual void OnSkill(Vector3 target)
    {

    }
}
