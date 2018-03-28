using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerSwordCollder : MonoBehaviour
{
    private BossParams _BossParams;
   
    void Start()
    {
        _BossParams = GetComponent<BossParams>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (CPlayerManager._instance.m_nAttackCombo == 1)
            {
                other.GetComponent<MonsterParams>().SetMonsterHp(10f);
            }
            else if (CPlayerManager._instance.m_nAttackCombo == 2)
            {
                other.GetComponent<MonsterParams>().SetMonsterHp(10f);
            }
            else if (CPlayerManager._instance.m_nAttackCombo == 3)
            {
                other.GetComponent<MonsterParams>().SetMonsterHp(10f);
            }
        }

        if (other.tag == "Boss")
        {
            CBossManager._instance._BossMat.m_bBossAttackMatch = true;
            CBossManager._instance._BossMat.m_fMatchTime = 0;

            if (CPlayerManager._instance.m_nAttackCombo == 1)
            {
                other.GetComponent<BossParams>().SetBossHp(10f);
                Debug.Log("플레이어 캐릭터가 적 공격했음!");
            }
            else if (CPlayerManager._instance.m_nAttackCombo == 2)
            {
                other.GetComponent<BossParams>().SetBossHp(10f);
                Debug.Log("플레이어 캐릭터가 적 공격했음!");
            }
            else if (CPlayerManager._instance.m_nAttackCombo == 3)
            {
                other.GetComponent<BossParams>().SetBossHp(10f);
                Debug.Log("플레이어 캐릭터가 적 공격했음!");
            }
        }
    }
}