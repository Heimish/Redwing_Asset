
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerShild : CPlayerBase
{
    public BoxCollider _ShildCollider;
    public GameObject _ShildEffect;
    public bool m_bShildCollider;
    private float m_fShildTimer;

	void Start () {
        _ShildCollider.enabled = false;
        m_bShildCollider = false;
        m_fShildTimer = 0;
    }
	
	
	void Update ()
    {
        if(m_bShildCollider)
        {
            _ShildEffect.SetActive(true);
            m_fShildTimer += Time.deltaTime;
            if(m_fShildTimer >= 0.5f)
            {
                _ShildEffect.SetActive(false);
                m_bShildCollider = false;
                m_fShildTimer = 0;
            }
        }

		if(_PlayerManager._PlayerAni_Contorl._PlayerAni_State_Shild == PlayerAni_State_Shild.Defense_ModeIdle)
        {
            _ShildCollider.enabled = true;
        }
        else
        {
            _ShildCollider.enabled = false;
        }
	}
}
