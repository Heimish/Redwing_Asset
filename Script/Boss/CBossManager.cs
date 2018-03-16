using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBossManager : MonoBehaviour
{
    private CBossAni _CBossAni = null;
    public CBossAni _BossAni { get { return _CBossAni; } }

    // 보스 이동속도
    private float m_fMoveSpeed;
    public float m_MoveSpeed { get { return m_fMoveSpeed; } set { value = m_fMoveSpeed; } }

    // 보스 체력
    private float m_fHp;
    public float m_Hp {  get { return m_fHp; } set { value = m_fHp; } }

    // 보스가 공격중인지
    private bool m_bAttack;
    public bool m_Attack { get { return m_bAttack; } set { value = m_bAttack; } }


	void Start ()
    {
        _CBossAni = GetComponent<CBossAni>();

        m_fMoveSpeed = 4f;
        m_fHp = 100f;
        m_bAttack = false;
	}

}
