using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerMove : CPlayerBase
{
    void FixedUpdate()
    {
        // 플레이어가 이동중일때 함수실행
        if (_PlayerManager.m_bMove)
            MoveDirRotation();
    }
   
    void MoveDirRotation()
    {
        // 각 방향키에 따른 캐릭터 8방향 로테이션
        // 카메라각도 에서 지정각도 빼줌
        if (Input.GetKey(KeyCode.W))
        {
            PlayerRotion(CCameraFind._instance._CameraRight.eulerAngles.y - 0);
            if (Input.GetKey(KeyCode.A))
                PlayerRotion(CCameraFind._instance._CameraRight.eulerAngles.y - 45);
            else if (Input.GetKey(KeyCode.D))
                PlayerRotion(CCameraFind._instance._CameraRight.eulerAngles.y + 45);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            PlayerRotion(CCameraFind._instance._CameraRight.eulerAngles.y - 180);
            if (Input.GetKey(KeyCode.A))
                PlayerRotion(CCameraFind._instance._CameraRight.eulerAngles.y - 135);
            else if (Input.GetKey(KeyCode.D))
                PlayerRotion(CCameraFind._instance._CameraRight.eulerAngles.y + 135);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            PlayerRotion(CCameraFind._instance._CameraRight.eulerAngles.y + 90);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            PlayerRotion(CCameraFind._instance._CameraRight.eulerAngles.y - 90);
        }
        
    }
    // 플레이어 로테이션 함수 
    void PlayerRotion(float nRotY)
    {
        _PlayerManager.vPlayerQuaternion.eulerAngles = new Vector3(0, nRotY, 0);
        
        // 플레이어가 이동중이고, 공격중이지않을때 실행
        if (_PlayerManager.m_bMove && !_PlayerManager.m_bAttack)
        {
			if (_PlayerManager._PlayerController.isGrounded) {
				_PlayerManager._PlayerController.Move (transform.forward * Time.deltaTime * _PlayerManager.m_MoveSpeed);
			}
        }
    }


}
