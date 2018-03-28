using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MonsterStat))]
public class MonsterBase : MonoBehaviour
{
    protected CharacterController m_controller; // 캐릭터 컨트롤러
    protected Animator m_anim; // 애니메이션
    protected MonsterStat m_stat; // 스탯 
    protected Vector3 m_destination; // 목적지
    protected bool m_isMoing; // 현재 이동중인지
    protected bool m_isRotate; // 현재 회전중인지

    // properties
    public CharacterController Controller { get { return m_controller; } }
    public Animator Anim { get { return m_anim; } }
    public MonsterStat Stat { get { return m_stat; } }

    private void Awake()
    {
        m_controller = GetComponentInChildren<CharacterController>();
        m_anim = GetComponentInChildren<Animator>();
        m_stat = GetComponent<MonsterStat>();
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
        MoveUpdate();
    }

    /// <summary>
    /// 움직임을 처리하는 함수
    /// </summary>
    private void MoveUpdate()
    {
        if (!m_isMoing)
            return;

        RotateToTarget(m_destination);

        if (m_isRotate)
            return;

        m_controller.Move((m_destination - transform.position).normalized * m_stat.MoveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 움질일 때 회전을하는 함수
    /// </summary>
    public void RotateToTarget(Vector3 target)
    {
        if (!m_isRotate)
            return;

        target.y = transform.position.y;
        Vector3 Forward = (target - transform.position).normalized;
        if (Forward != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                Quaternion.LookRotation(Forward),
                m_stat.RotateSpeed * Time.deltaTime);
        }

        if (transform.forward == Forward)
        {
            m_isRotate = false;
        }
    }

    /// <summary>
    /// 움직이는 함수 (방향전환은 하지 않음)
    /// </summary>
    /// <param name="target"> 목적지</param>
    public void MoveToTarget(Vector3 target)
    {
        m_isMoing = true;
        m_isRotate = false;
        m_destination = target;
        m_destination.y = transform.position.y;
    }

    /// <summary>
    /// 움직이는 함수 (방향전환)
    /// </summary>
    /// <param name="target"> 몾적지 </param>
    public void MoveToTargetLookAt(Vector3 target)
    {
        MoveToTarget(target);
        m_isRotate = true;
    }

    public void MoveToTargetLookAts(Vector3 target)
    {
        MoveUpdate();
        MoveToTarget(target);
        m_isRotate = true;
    }
}
