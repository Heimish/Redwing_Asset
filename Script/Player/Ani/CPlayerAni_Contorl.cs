using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 애니메이션 동작을 검방패, 낫 모드 나눔

// 낫
public enum PlayerAni_State_Scythe
{
    Idle = 0,
    Run,
    Attack1,
    Attack2,
    Attack3,
    None
}
// 검방패
public enum PlayerAni_State_Shild
{
    Idle = 0,
    Run,
    Attack1,
    Attack2,
    Attack3,
    TankerIdle,
    TankerCountAttack,
    None,
}


public class CPlayerAni_Contorl : CPlayerBase
{
    // 애니 초기화
    public PlayerAni_State_Shild _PlayerAni_State_Shild = PlayerAni_State_Shild.Idle;
    public PlayerAni_State_Scythe _PlayerAni_State_Scythe = PlayerAni_State_Scythe.None;

    private Animator _PlayerAniFile;

    void Start ()
    {
        // 현재 애니메이터 값 가져오기
        _PlayerAniFile = GetComponent<Animator>();
    }

    void Update()
    {
        if (!_PlayerManager._PlayerSkill.m_ShildRun && _PlayerManager.m_bAnimator)
        {
            
            if (_PlayerManager._PlayerSwap._PlayerMode == PlayerMode.Shield)
            {
                ShieldAniGetKey();
                ShieldAni();
            }
            else
            {
                SyctheAniGetKey();
                SyctheAni();
            }
        }        
    }
    // 낫모드 키입력시 애니메이션 변경
    void SyctheAniGetKey()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_PlayerManager.m_nAttackCombo == 0)
                _PlayerAni_State_Scythe = PlayerAni_State_Scythe.Attack1;
            if (_PlayerManager.m_bAttack)
            {
                if (_PlayerManager.m_nAttackCombo == 1)
                    _PlayerAni_State_Scythe = PlayerAni_State_Scythe.Attack2;
                else if (_PlayerManager.m_nAttackCombo == 2)
                    _PlayerAni_State_Scythe = PlayerAni_State_Scythe.Attack3;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                _PlayerAni_State_Scythe = PlayerAni_State_Scythe.Run;
            }
            else
            {
                _PlayerAni_State_Scythe = PlayerAni_State_Scythe.Idle;
            }
        }
    }
    void ShieldAniGetKey()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_PlayerManager.m_nAttackCombo == 0)
                _PlayerAni_State_Shild = PlayerAni_State_Shild.Attack1;
            if (_PlayerManager.m_bAttack)
            {
                if (_PlayerManager.m_nAttackCombo == 1)
                    _PlayerAni_State_Shild = PlayerAni_State_Shild.Attack2;
                else if (_PlayerManager.m_nAttackCombo == 2)
                    _PlayerAni_State_Shild = PlayerAni_State_Shild.Attack3;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _PlayerAni_State_Shild = PlayerAni_State_Shild.TankerIdle;
                if (Input.GetMouseButton(1))
                {
                    _PlayerAni_State_Shild = PlayerAni_State_Shild.TankerCountAttack;
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    _PlayerAni_State_Shild = PlayerAni_State_Shild.Run;
                }
                else
                {
                    _PlayerAni_State_Shild = PlayerAni_State_Shild.Idle;
                }
            }
        }
    }

    void ShieldAni()
    {
        switch (_PlayerAni_State_Shild)
        {
            case PlayerAni_State_Shild.None:
                {

                }break;
            case PlayerAni_State_Shild.Idle:
                {
                    if(_PlayerManager.m_nAttackCombo == 0)
                    {
                        if(!_PlayerManager._PlayerSkill.m_ShildRun)
                        {
                            Animation_Change(0);
                        }
                    }
                }
                break;
            case PlayerAni_State_Shild.Run:
                {
                    Animation_Change(1);
                }
                break;
            case PlayerAni_State_Shild.Attack1:
                {                    
                    Animation_Change(2);
                }
                break;
            case PlayerAni_State_Shild.Attack2:
                {
                    Animation_Change(3);
                }
                break;
            case PlayerAni_State_Shild.Attack3:
                {
                    Animation_Change(4);
                }
                break;
            case PlayerAni_State_Shild.TankerIdle:
                {
                    Animation_Change(5);
                }
                break;
            case PlayerAni_State_Shild.TankerCountAttack:
                {
                    Animation_Change(6);
                }
                break;
        }

    }
    void SyctheAni()
    {
        switch (_PlayerAni_State_Scythe)
        {
            case PlayerAni_State_Scythe.Idle:
                {
                    if (_PlayerManager.m_nAttackCombo == 0)
                        Animation_Change(0);
                }
                break;
            case PlayerAni_State_Scythe.Run:
                {
                    Animation_Change(1);
                }
                break;
            case PlayerAni_State_Scythe.Attack1:
                {
                    Animation_Change(2);
                }
                break;
            case PlayerAni_State_Scythe.Attack2:
                {
                    Animation_Change(3);
                }
                break;
            case PlayerAni_State_Scythe.Attack3:
                {
                    Animation_Change(4);
                }
                break;

        }
    }

    public void Animation_Change(int animation_number)
    {
        _PlayerAniFile = GetComponent<Animator>();
        
        if(_PlayerManager._PlayerSwap._PlayerMode == PlayerMode.Shield)
            _PlayerAniFile.SetInteger("motion", animation_number);
        else
            _PlayerAniFile.SetInteger("Scythe", animation_number);
    }
}
