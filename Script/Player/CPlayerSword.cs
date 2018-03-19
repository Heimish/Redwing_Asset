using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerSword : CPlayerBase
{
    public BoxCollider _SowrdCollder;
    private bool m_bCollder;
    private float m_fCollderTimer;
    void Start()
    {
        _SowrdCollder.enabled = false;
        m_bCollder = false;
        m_fCollderTimer = 0;
    }
    void Update()
    {
        if(m_bCollder)
        {
            m_fCollderTimer += Time.deltaTime;
            if(m_fCollderTimer >= 0.3f)
            {
                m_fCollderTimer = 0;
                m_bCollder = false;
                SowrdFalse();
            }
        }
    }
    public void SowrdTrue()
    {
        _SowrdCollder.enabled = true;
        m_bCollder = true;
    }
    public void SowrdFalse() { _SowrdCollder.enabled = false; }
}
