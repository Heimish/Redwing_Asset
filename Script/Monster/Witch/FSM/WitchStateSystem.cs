using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchStateSystem : MonoBehaviour
{
    private WitchBoss m_witch;
    private Dictionary<WitchState, WitchFSMStateBase> m_states = new Dictionary<WitchState, WitchFSMStateBase>();

    // properties
    public WitchBoss Witch { get { return m_witch; } set { m_witch = value; } }

    private void Awake()
    {
        WitchState[] states = Enum.GetValues(typeof(WitchState)) as WitchState[];
        foreach (WitchState state in states)
        {
            Type t = Type.GetType("WitchState" + state.ToString());
            WitchFSMStateBase s = GetComponent(t) as WitchFSMStateBase;
            if (s == null)
                s = gameObject.AddComponent(t) as WitchFSMStateBase;

            s.Witch = m_witch;
            s.enabled = false;
            m_states.Add(state, s);
        }
        m_states[m_witch.State].enabled = true;
        m_states[m_witch.State].BeginState();
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void SetState(WitchState state)
    {
        m_states[m_witch.State].EndState();
        m_states[m_witch.State].enabled = false;
        m_witch.State = state;
        m_states[m_witch.State].enabled = true;
        m_states[m_witch.State].BeginState();
    }
}
