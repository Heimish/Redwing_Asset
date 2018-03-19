using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerSwordCollder : MonoBehaviour
{       
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boss")
        {
            CBossManager._instance._BossMat.m_bBossAttackMatch = true;
            CBossManager._instance._BossMat.m_fMatchTime = 0;

            if (CPlayerManager._instance.m_nAttackCombo == 1)
                Debug.Log("1타");
            else if (CPlayerManager._instance.m_nAttackCombo == 2)
                Debug.Log("2타");
            else if (CPlayerManager._instance.m_nAttackCombo == 3)
                Debug.Log("3타");
        }
    }
}
