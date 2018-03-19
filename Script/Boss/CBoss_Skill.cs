﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossPattern
{
    None = 0,
    Block,
    Foothold
}

public class CBoss_Skill : MonoBehaviour
{
    BossPattern _BossPattern = BossPattern.None;

    Vector3 vPlayerPos;
    Vector3 vPlayerPos2;

    // 구체블럭 
    private GameObject _BlockObj; // 구체 블럭 프리팹
    public Transform[] _BossSkillPos; // 보스 뒤에 스킬스폰 좌표
    List<GameObject> _BlockList = new List<GameObject>(); // 블럭 리스트
    private bool m_bAttackBlockSkill; // 블럭스킬공격중임을 알려줌
    private int m_nBlockType; // 블럭 날린갯수
    private float m_nBlockTimer; // 딜레이 
    public float m_nBlockSpeed; // 블럭 스피드

    // 발판
    private GameObject _FootholdObj;  // 발판 프리팹
    private GameObject _FootholdObjRoad; // 발판 정보 로드 
    private bool m_bFoothold; // 발판 스킬중임을 알려줌


    void Start()
    {
        m_nBlockTimer = 0;
        m_nBlockType = -2;
        m_nBlockSpeed = 7f;
        m_bAttackBlockSkill = false;
        _BlockObj = Resources.Load("Boss/BossSkill1") as GameObject;


        _FootholdObjRoad = Resources.Load("Boss/BossFoothold") as GameObject;
        m_bFoothold = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            m_nBlockType = -2;
            _BlockList.Clear();
            // 블럭 5개 생성
            for (int i = 0; i < _BossSkillPos.Length; i++)
            {
                BlockObjCreate(_BossSkillPos[i].transform.position);
            }
            m_nBlockType++;
            StartCoroutine("AttackStart");
            m_bAttackBlockSkill = true;
            _BossPattern = BossPattern.Block;
        }


        if(Input.GetKeyDown(KeyCode.T))
        {
            vPlayerPos2 = GameObject.Find("Player").transform.position;
            _FootholdObj = Instantiate(_FootholdObjRoad) as GameObject;
            _FootholdObj.transform.position = vPlayerPos2;
            StartCoroutine("StartFoothold");
        }
        StateSide();
    }

    void StateSide()
    {
        switch (_BossPattern)
        {
            case BossPattern.None:
                {

                }
                break;
            case BossPattern.Block:
                {
                    BlockAttack();
                }
                break;
            case BossPattern.Foothold:
                {

                }
                break;
        }
    }
    void BlockAttack()
    {
        if (m_bAttackBlockSkill)
        {
            if (m_nBlockType < 5)
            {
                m_nBlockTimer += Time.deltaTime;
            }
            else
            {
                _BossPattern = BossPattern.None;
                return;
            }

            if (m_nBlockTimer >= 0.4f)
            {
                if (_BlockList[m_nBlockType] == null || m_nBlockTimer >= 1.0f)
                {
                    StartCoroutine("AttackStart");
                    m_nBlockTimer = 0;
                }
                else
                {
                    _BlockList[m_nBlockType].transform.position = Vector3.Lerp(_BlockList[m_nBlockType].transform.position, CGameManager._instance._PlayerPos.transform.position, m_nBlockSpeed * Time.deltaTime);
                }
            }
        }
    }
    void BlockObjCreate(Vector3 vPos)
    {
        GameObject _obj = Instantiate(_BlockObj) as GameObject;
        _BlockList.Add(_obj);
        _obj.transform.position = vPos;
    }

    IEnumerator AttackStart()
    {
        yield return new WaitForSeconds(0.1f);
        m_nBlockType++;
        yield return new WaitForSeconds(0.25f);
            
    }

    IEnumerator StartFoothold()
    {
        yield return new WaitForSeconds(1f);
        CEffectManager._instance.EffectCreate(2, _FootholdObj.transform.position);
        Destroy(_FootholdObj.gameObject);
    }
}
