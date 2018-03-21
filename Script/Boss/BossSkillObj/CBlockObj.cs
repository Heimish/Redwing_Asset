using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBlockObj : MonoBehaviour
{

    Vector3 vPos;

    private void OnTriggerEnter(Collider other)
    {
        vPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        CEffectManager._instance.EffectCreate(1, vPos);

        if(other.gameObject.tag == "Shild")
        {
            CPlayerManager._instance._PlayerShild.m_bShildCollider = true;
            CCameraShake._instance.shake = 0.2f;
            Debug.Log("실드");
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Player")
        {          
            // 블럭과 충돌 했을때 실드 상태가 아닐 경우 -HP 값 전달  
            other.GetComponent<PlayerParams>().SetHp(10f);

            CPlayerManager._instance.PlayerHp(10f);
                CCameraShake._instance.shake = 0.2f;
                Debug.Log("캐릭터");
            Destroy(this.gameObject);

            // 플레이어의 상태가 방패(디펜스 모드)일 경우에는 데미지를 입지 않는다.
            if (GetComponent<CPlayerAni_Contorl>()._PlayerAni_State_Shild == PlayerAni_State_Shild.Defense_Mode)
            {             
                other.GetComponent<PlayerParams>().SetHp(0f);
                Destroy(this.gameObject);
            }
        }
        //Destroy(this.gameObject);
        return;
    }
}
