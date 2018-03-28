using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchStateIdle : WitchFSMStateBase
{
    private GameObject m_hero;
    private float m_distance;

    public override void BeginState()
    {
        m_hero = GameObject.Find("Player");
    }

    void Update ()
    {
		if (Vector3.Distance(transform.position, m_hero.transform.position) <= 3.0f)
        {
            Witch.SetState(WitchState.Chase);
        }
	}

    public override void EndState()
    {
    }
}
