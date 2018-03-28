using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WitchState
{
    Idle = 0,
    Run,
    Chase,
}

[RequireComponent(typeof(WitchStateSystem))]
public class WitchBoss : MonsterBase
{
    private WitchStateSystem m_stateSystem;
    private WitchSkillSystem m_skillSystem;
    private WitchState m_curState;
    private int m_phase;

    // properties
    public WitchState State { get { return m_curState; } set { m_curState = value; } }
    public int Phase { get { return m_phase; } set { m_phase = value; } }
    public WitchSkillSystem SkillSys { get { return m_skillSystem; } }

    private void Awake()
    {
        m_stateSystem = GetComponent<WitchStateSystem>();
        m_stateSystem.Witch = this;
        m_skillSystem = GetComponent<WitchSkillSystem>();
        m_skillSystem.Witch = this;
        m_curState = WitchState.Idle;
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetState(WitchState state)
    {
        m_stateSystem.SetState(state);
    }
}
