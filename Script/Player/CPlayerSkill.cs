using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillState
{
    None = 0,
    Run,
    Shile,
    Stat,
    AttackSkill,
}

public class CPlayerSkill : CPlayerBase
{
    public SkillState _SkillState = SkillState.None;

    // 스킬사용할때 다른 애니메이션 막기
    private bool m_bShildRun;
    public bool m_ShildRun { get { return m_bShildRun; } set { value = m_bShildRun; } }

    public float m_fTimer;
    private float m_fEndTime;

	void Start () 
	{
		m_bShildRun = false;
        m_fTimer = 0;
        m_fEndTime = 0.3f;
    }
	
	void Update () 
	{
        ShildRunSkill();
        StateSide();
        StatBuf();
    }

    void StatBuf()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine("PlayerStatUp");
            _SkillState = SkillState.Stat;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _PlayerManager.m_bAnimator = false;
            _PlayerManager._PlayerAni_Contorl.Animation_Change(2);
            _SkillState = SkillState.AttackSkill;
            StartCoroutine("ResetSkill");
        }
    }
	void ShildRunSkill()
	{
	    if(Input.GetKey(KeyCode.E) && !m_bShildRun)
        {
            m_bShildRun = true;
        }
        if (m_bShildRun)
        {
            _PlayerManager.m_bMove = false;
            if (m_fTimer < m_fEndTime)
            {
                _SkillState = SkillState.Run;
                m_fTimer += Time.deltaTime;
            }       
            else
            {
                if (m_fTimer >= m_fEndTime)
                {
                    _SkillState = SkillState.Shile;
                    m_fTimer = m_fEndTime;
                    StartCoroutine("ResetSkill");
                }
            }
        }
    }

    void StateSide()
    {
        switch(_SkillState)
        {
            case SkillState.None:
                {
                    _PlayerManager.PlayerStat(10, 10, 10, 6);
                }
                break;
            case SkillState.Run:
                {
                    _PlayerManager.m_bMove = false;
                    _PlayerManager._PlayerController.Move(transform.forward * Time.deltaTime * _PlayerManager.m_MoveSpeed * 4f);
                    _PlayerManager._PlayerAni_Contorl.Animation_Change(5);
                }
                break;
            case SkillState.Shile:
                {
                    _PlayerManager._PlayerAni_Contorl.Animation_Change(5);
                }
                break;
            case SkillState.Stat:
                {
                    _PlayerManager.PlayerStat(20, 20, 20, 7.2f);
                }
                break;

            case SkillState.AttackSkill:
                {
                    _PlayerManager.PlayerStat(40, 40, 40, 6);
                }break;
        }
    }

    IEnumerator ResetSkill()
    {
        yield return new WaitForSeconds(0.2f);
        m_bShildRun = false;
        m_fTimer = 0;
        _PlayerManager.m_bMove = true;
        _PlayerManager.m_bAnimator = true;
        _PlayerManager._PlayerAni_Contorl.Animation_Change(0);
        _SkillState = SkillState.None;
    }

    IEnumerator PlayerStatUp()
    {
        yield return new WaitForSeconds(10);
        _SkillState = SkillState.None;
    }
}
