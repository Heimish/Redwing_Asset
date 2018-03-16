using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerAniEvent : CPlayerBase
{
    private bool m_bMoveAttack;
    public float m_fStartTime;
    public float m_fEndTime;
    public float m_fforwordSpeed;

    // 플레이어 움직임 막기
    public void MoveFalse()
    {
        _PlayerManager.m_bMove = false;
    }
    public void MoveTrue()
    {
        _PlayerManager.m_bMove = true;
    }

    public void CameraFalse()
    {
        CCameraFind._instance.m_bCamera = false;
    }
    public void CameraTrue()
    {
        CCameraFind._instance.m_bCamera = true;
    }

    public void AttackTimeStart()
    {
        _PlayerManager.m_bAttack = true;
    }

    public void AttackTimeEnd()
    {
        _PlayerManager.m_bAttack = false;
    }

    public void AttackComboPlus()
    {
        _PlayerManager.m_nAttackCombo++;
    }
    public void AttackComboReset()
    {
        _PlayerManager.m_nAttackCombo = 0;
    }

    public void AttackMove()
    {
        m_fStartTime = 0;
        m_bMoveAttack = true;
    }
    private void Update()
    {
        if(m_bMoveAttack)
        {
            m_fStartTime += Time.deltaTime;
            _PlayerManager._PlayerController.Move(transform.forward * Time.deltaTime * _PlayerManager.m_MoveSpeed);
            if (m_fStartTime >= m_fEndTime)
            {
                m_fStartTime = 0;
                m_bMoveAttack = false;
            }
        }
    }
}

