using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchSkillAFire : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    private Vector3 m_target;
    private int m_move;
    private float m_speed;
    private Vector3 m_readyPos;

    // properties
    public int MoveState { get { return m_move; } }
    public Vector3 ReadyPos { get { return m_readyPos; } }
    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        ReadyMove();
    }

    private void Move()
    {
        if (m_move != 2)
            return;

        m_rigidbody.velocity = transform.forward * m_speed * Time.deltaTime;
    }

    private void ReadyMove()
    {
        if (m_move != 1)
            return;

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, m_readyPos, 5.0f * Time.deltaTime);
    }

    public void Ready(Vector3 pos)
    {
        m_move = 1;
        m_readyPos = pos;
    }

    public void FireInit(Vector3 target, float speed = 30.0f)
    {
        m_move = 2;
        m_target = target;
        m_speed = speed;
        transform.LookAt(m_target);
    }
}
