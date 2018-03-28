using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WitchSkill
{
    A = 0,
    B,
    C,
}
public class WitchSkillSystem : MonoBehaviour
{
    private WitchBoss m_witch;
    private Dictionary<WitchSkill, WitchSkillBase> m_skills = new Dictionary<WitchSkill, WitchSkillBase>();

    // properties
    public WitchBoss Witch { get { return m_witch; } set { m_witch = value; } }
    public Dictionary<WitchSkill, WitchSkillBase> Skills { get { return m_skills; } }

    private void Awake()
    {
        m_skills.Add(WitchSkill.A, new WitchSkillA(m_witch, 10.0f));
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}
