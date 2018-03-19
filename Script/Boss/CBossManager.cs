using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBossManager : MonoBehaviour
{
    public static CBossManager _instance = null;

    private CBossAni _CBossAni = null;
    public CBossAni _BossAni { get { return _CBossAni; } }

    private CBoss_Skill _CBoss_Skill = null;
    public CBoss_Skill _Boss_Skill { get { return _CBoss_Skill; } }

    private CBossPatten _CBossPatten = null;
    public CBossPatten _BossPatten { get { return _CBossPatten; } }

    private CBossFMS _CBossFMS = null;
    public CBossFMS _BossFMS { get { return _CBossFMS; } }

    private CBossMat _CBossMat = null;
    public CBossMat _BossMat { get { return _CBossMat; } }

    // 보스 이동속도
    private float m_fMoveSpeed;
    public float m_MoveSpeed { get { return m_fMoveSpeed; } set { value = m_fMoveSpeed; } }

    // 보스 체력
    private float m_fHp;
    public float m_Hp {  get { return m_fHp; } set { value = m_fHp; } }

    // 보스가 공격중인지
    private bool m_bAttack;
    public bool m_Attack { get { return m_bAttack; } set { value = m_bAttack; } }

    // 보스 쿼터니언
    private Quaternion _BossQuaternion;
    public Quaternion BossQuaternion { get { return _BossQuaternion; } set { value = _BossQuaternion; } }

    // 보스 인식 거리
    public float m_fMaxDistance;
    public float m_fMinDistance;

    private bool m_bFootAttackCamera;
    private float m_fFootAttackTimer;

    void Start ()
    {
        CBossManager._instance = this;

        m_bFootAttackCamera = false;
        m_fFootAttackTimer = 0;

        m_fMaxDistance = 13;
        m_fMinDistance = 4;

        _CBossAni = GetComponent<CBossAni>();
        _CBoss_Skill = GetComponent<CBoss_Skill>();
        _CBossPatten = GetComponent<CBossPatten>();
        _CBossFMS = GetComponent<CBossFMS>();
        _CBossMat = GetComponent<CBossMat>();

        m_fMoveSpeed = 4f;
        m_fHp = 100f;
        m_bAttack = false;

    }

    void Update()
    {
        if(m_bFootAttackCamera)
        {
            m_fFootAttackTimer += Time.deltaTime;
            CCameraRayObj._instance.MaxCamera(6f);
            if(m_fFootAttackTimer >= 2.5f)
            {
                CCameraRayObj._instance.MaxCamera(4f);
                m_fFootAttackTimer = 0;
                m_bFootAttackCamera = false;
            }
        }
    }

    public void AttackerCamera()
    {
        if(Vector3.Distance(transform.position, CGameManager._instance._PlayerPos.position) < m_fMaxDistance + 5f)
        {
            CCameraShake._instance.shake = 1.0f;
            m_bFootAttackCamera = true;
        }
    }

}
