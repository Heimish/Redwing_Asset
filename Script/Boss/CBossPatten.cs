using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CheckPlayer
{
    None,
    Short,
    Long
}
public enum AttackPatten
{
    None = 0,
    ShortPatten1,
    ShortPatten2,
    LongPatten1,
    LongPatten2,
    Random,
}
public class CBossPatten : CBossBase
{
    public CheckPlayer _CheckPlayer = CheckPlayer.None;
    public AttackPatten _AttackPatten = AttackPatten.None;

    public bool m_bPattenAttack;
    public float m_fPattenTime;
    public int m_nPattenNumber;

    void Start()
    {
        m_bPattenAttack = false;
        m_nPattenNumber = 0;
        m_fPattenTime = 0;
    }


    void Update ()
    {
        CheckPlayerSide();
        AttackPattenSide();


        if (m_nPattenNumber == 3)
        {
            m_fPattenTime += Time.deltaTime;
            if (m_fPattenTime >= 7f)
            {
                _BossManager._BossFMS._BossState = BossState.Idle;
                m_fPattenTime = 0;
                m_nPattenNumber = 0;
                m_bPattenAttack = false;
            }
        }
    }

    void CheckPlayerSide()
    {
        switch(_CheckPlayer)
        {
            case CheckPlayer.None:
                {
                }
                break;
            case CheckPlayer.Short:
                {

                }
                break;
            case CheckPlayer.Long:
                {

                }
                break;
        }
    }
    void AttackPattenSide()
    {
        switch (_AttackPatten)
        {
            case AttackPatten.None:
                {

                }
                break;
            case AttackPatten.ShortPatten1:
                {
                    StartCoroutine("ShortPatten1Start");
                }
                break;
            case AttackPatten.ShortPatten2:
                {

                }
                break;
            case AttackPatten.LongPatten1:
                {
                    m_bPattenAttack = true;
                    Long1();
                }
                break;
            case AttackPatten.LongPatten2:
                {

                }
                break;
            case AttackPatten.Random:
                {

                }break;
        }
    }

    void Long1()
    {
        if (m_nPattenNumber == 0)
        {
            _BossManager._BossFMS._BossState = BossState.FootHoldSkill;
            if (_BossManager._Boss_Skill.m_bFoothold == false)
                m_nPattenNumber = 1;
        }
        else if (m_nPattenNumber == 1)
        {
            m_fPattenTime += Time.deltaTime;
            if (m_fPattenTime >= 1.5f)
            {
                if (_BossManager._Boss_Skill.m_bAttackBlockSkill == false)
                {
                    _BossManager._BossFMS._BossState = BossState.BlcokSkill;
                    m_fPattenTime = 0;
                    m_nPattenNumber = 2;
                }
            }
        }
        else if (m_nPattenNumber == 2)
        {
            m_fPattenTime += Time.deltaTime;
            if (m_fPattenTime >= 2f)
            {
                _BossManager._Boss_Skill.RandSkillStart();
                m_nPattenNumber = 3;
                m_fPattenTime = 0;
                _AttackPatten = AttackPatten.None;
            }
        }
        
    }
}
