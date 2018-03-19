using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBossMat : CBossBase
{
    public float m_fMatchTime;
    public bool m_bBossAttackMatch;
    public GameObject _ChangeMaterial;
    public Material _BossMat;
    public Material _BossAttackMat;

    void Start()
    {
        m_fMatchTime = 0;
        m_bBossAttackMatch = false;
    }
    void Update ()
    {
        if (m_bBossAttackMatch)
        {
            _ChangeMaterial.GetComponent<Renderer>().material = _BossAttackMat;
            m_fMatchTime += Time.deltaTime;
            if (m_fMatchTime >= 0.1f)
            {
                _ChangeMaterial.GetComponent<Renderer>().material = _BossMat;
                m_fMatchTime = 0;
                m_bBossAttackMatch = false;
            }
        }
        else
        {
            m_fMatchTime = 0;
            _ChangeMaterial.GetComponent<Renderer>().material = _BossMat;
        }
    }
}
