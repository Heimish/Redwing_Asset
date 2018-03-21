using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParams : CharacterUI
{
    public string names { get; set; }
    public GameObject HPBar;
    public GameObject SPBar;
    RectTransform sp;

    // 플레이어 캐릭터 공격 & 막기 상태 체크
    public bool PlayerSPAttackCheck;

    public override void InitParams()
    {
        names = "Player";
        maxHP = 100f;
        curHP = maxHP;
        maxSP = 100f;
        curSP = maxSP;
        attackMin = 10f;
        attackMax = 20f;
        defense = 1f;

        isDead = false;
    }

    private void Awake()
    {
        sp = SPBar.GetComponent<RectTransform>();
    }

    protected override void UpdateAfterReceiveAttack()
    {
        base.UpdateAfterReceiveAttack();
    }

    public void SetcSp(float _csp)
    {
        curSP += _csp;
        if (curSP >= maxSP)
        {
            curSP = maxSP;
        }
        else if (curSP <= 0f)
        {
            curSP = 0f;
        }
    }

    public void SpUset()
    {
        UItime += Time.deltaTime;
        if (UItime >= 0.5f)
        {
            GetComponent<PlayerParams>().SetcSp(1f);
            UItime = 0f;
        }
    }

    public void SpHalfUset()
    {
        UItime += Time.deltaTime;
        if (UItime >= 10f)
        {
            GetComponent<PlayerParams>().SetcSp(0f);
            UItime = 0f;
        }
    }

    void Update()
    {      
        float _sp = curSP / 100f;
        sp.localScale = new Vector3(_sp, sp.localScale.y, sp.localScale.z);
        Debug.Log("스테미너" + curSP);
    }

}
