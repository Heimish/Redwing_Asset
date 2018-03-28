using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchFSMStateBase : MonoBehaviour
{
    private WitchBoss m_witch;

    // properties
    public WitchBoss Witch { get { return m_witch; } set { m_witch = value; } }

    public virtual void BeginState()
    {

    }

    public virtual void EndState()
    {

    }
}
