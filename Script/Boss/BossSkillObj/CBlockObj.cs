using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBlockObj : MonoBehaviour
{
    Vector3 vPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "MapObject")
        {
            vPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            CEffectManager._instance.EffectCreate(1, vPos);
            Destroy(this.gameObject);
        }
    }
}
