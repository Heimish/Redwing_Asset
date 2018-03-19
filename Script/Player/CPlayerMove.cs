using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerMove : CPlayerBase
{
    void FixedUpdate()
    {
        // 플레이어가 이동중일때 함수실행
        if(_PlayerManager._PlayerAni_Contorl.m_bKey)
            MoveDirRotation();
    }
   
    void MoveDirRotation()
    {
        // 각 방향키에 따른 캐릭터 8방향 로테이션
        // 카메라각도 에서 지정각도 빼줌
        if (Input.GetKey(KeyCode.W))
        {
            PlayerRotion(CCameraFind._instance._CameraRight.eulerAngles.y - 0, 6);
            if (Input.GetKey(KeyCode.A))
                PlayerRotion(CCameraFind._instance._CameraRight.eulerAngles.y - 45, 0);
            else if (Input.GetKey(KeyCode.D))
                PlayerRotion(CCameraFind._instance._CameraRight.eulerAngles.y + 45, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            PlayerRotion(CCameraFind._instance._CameraRight.eulerAngles.y - 180, 6);
            if (Input.GetKey(KeyCode.A))
                PlayerRotion(CCameraFind._instance._CameraRight.eulerAngles.y - 135, 0);
            else if (Input.GetKey(KeyCode.D))
                PlayerRotion(CCameraFind._instance._CameraRight.eulerAngles.y + 135, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            PlayerRotion(CCameraFind._instance._CameraRight.eulerAngles.y + 90, 6);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            PlayerRotion(CCameraFind._instance._CameraRight.eulerAngles.y - 90, 6);
        }
        
    }
    // 플레이어 로테이션 함수 
    void PlayerRotion(float nRotY, float fSpeed)
    {
        _PlayerManager.m_MoveSpeed = fSpeed;
        _PlayerManager.vPlayerQuaternion.eulerAngles = new Vector3(0, nRotY, 0);
        
        // 플레이어가 이동중이고, 공격중이지않을때 실행
        if (_PlayerManager.m_bMove && !_PlayerManager.m_bAttack)
        {
            //if(_PlayerManager._PlayerController.isg)
                _PlayerManager._PlayerController.Move (transform.forward * Time.deltaTime * _PlayerManager.m_MoveSpeed);
        }
    }


}
