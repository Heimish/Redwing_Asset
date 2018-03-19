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
        }
        if (other.gameObject.tag == "Player")
        {
            CPlayerManager._instance.PlayerHp(10f);
            CCameraShake._instance.shake = 0.2f;
            Debug.Log("캐릭터");
        }
        Destroy(this.gameObject);
        return;
    }
}
