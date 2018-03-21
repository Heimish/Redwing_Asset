using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CPlayerMove : CPlayerBase
{
    public Vector3 m_moveDir = Vector3.zero;
    public Vector3 m_destination = Vector3.zero;
    public GameObject m_Cube;
    void FixedUpdate()
    {
        Movement();
    }


    // 플레이어 로테이션 함수 
    void PlayerRotion(float nRotY, float fSpeed)
    {
        _PlayerManager.m_MoveSpeed = fSpeed;
        _PlayerManager.vPlayerQuaternion.eulerAngles = new Vector3(0, nRotY, 0);

        // 플레이어가 이동중이고, 공격중이지않을때 실행
        if (_PlayerManager.m_bMove && !_PlayerManager.m_bAttack &&
            !_PlayerManager._PlayerAni_Contorl.m_bDefenseIdle &&
            !_PlayerManager.m_isRotation)
        {
            //if(_PlayerManager._PlayerController.isg)
            _PlayerManager._PlayerController.Move(transform.forward * Time.deltaTime * _PlayerManager.m_MoveSpeed);
        }
    }

    private void Movement()
    {
        float fHorizontal;
        float fVertical;
        fHorizontal = Input.GetAxis("Horizontal");
        fVertical = Input.GetAxis("Vertical");

        Vector3 horizontalPos = CCameraFind._instance.transform.right * fHorizontal;
        Vector3 verticalPos = CCameraFind._instance.transform.forward * fVertical;

        m_destination = transform.position + horizontalPos + verticalPos;
        m_destination.y = transform.position.y;

        Vector3 direction = m_destination - transform.position;
        m_moveDir = direction.normalized;

        if (!Input.GetKey(KeyCode.W) &&
            !Input.GetKey(KeyCode.S))
        {
            fVertical = 0.0f;
        }

        if (!Input.GetKey(KeyCode.A) &&
            !Input.GetKey(KeyCode.D))
        {
            fHorizontal = 0.0f;
        }

        if (Mathf.Abs(fHorizontal) > 0 ||
            Mathf.Abs(fVertical) > 0)
        {
            _PlayerManager._PlayerAni_Contorl._PlayerAni_State_Shild = PlayerAni_State_Shild.Run;
            PlayerRotion(0, 6);
        }

        if (Mathf.Abs(fHorizontal) == 0f &&
            Mathf.Abs(fVertical) == 0f)
        {
            if (!Input.GetKey(KeyCode.A) &&
            !Input.GetKey(KeyCode.D) &&
            !Input.GetKey(KeyCode.W) &&
            !Input.GetKey(KeyCode.S))
                _PlayerManager._PlayerAni_Contorl._PlayerAni_State_Shild = PlayerAni_State_Shild.Idle;
        }
        //m_Cube.transform.position = transform.position + direction.normalized;
    }


}

