using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    None,
    Idle,
    Run,
    BlcokSkill,
    FootHoldSkill,
    Attack,
}

public class CBossFMS : CBossBase
{
    public BossState _BossState = BossState.Idle;

    void Update ()
    {
        transform.LookAt(CGameManager._instance._PlayerPos);
        BossFMS();
    }

    void BossFMS()
    {
        switch(_BossState)
        {
            case BossState.Idle:
                {
                    Idle();
                }
                break;
            case BossState.Run:
                {
                    Run();
                }
                break;
            case BossState.BlcokSkill:
                {
                    _BossManager._BossAni.Animation_Change(4);
                }
                break;
            case BossState.FootHoldSkill:
                {
                    _BossManager._Boss_Skill.m_bFoothold = true;
                    _BossManager._BossAni.Animation_Change(3);
                }
                break;
            case BossState.Attack:
                {
                    _BossManager._BossAni.Animation_Change(5);
                }
                break;
        }
    }

    void Idle()
    {
        _BossState = BossState.Run;
    }

    void Run()
    {
        if (Vector3.Distance(transform.position, CGameManager._instance._PlayerPos.position) < _BossManager.m_fMaxDistance)
        {
            if(_BossManager._BossPatten.m_nPattenNumber == 0)
                _BossManager._BossPatten._AttackPatten = AttackPatten.LongPatten1;
        }
        else
        {
            if (_BossManager._BossPatten.m_bPattenAttack == false)
            {
                _BossManager._BossPatten.m_nPattenNumber = 0;
                _BossManager._BossPatten._AttackPatten = AttackPatten.None;
                if(_BossManager._BossPatten.m_nPattenNumber == 3 ||
                    _BossManager._BossPatten.m_nPattenNumber == 0)
                {
                    _BossManager._BossAni.Animation_Change(1);
                    transform.LookAt(CGameManager._instance._PlayerPos);
                    transform.position += transform.forward * Time.deltaTime * _BossManager.m_MoveSpeed;
                }
            }
        }
    }

    public void IdleReturn()
    {
        if (Vector3.Distance(transform.position, CGameManager._instance._PlayerPos.position) < _BossManager.m_fMaxDistance)
        {
            _BossState = BossState.Run;
        }
        else
        {
            _BossState = BossState.Idle;
        }
    }
}
