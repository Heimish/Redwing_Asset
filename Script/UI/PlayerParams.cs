using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParams : CharacterUI
{
    public string names { get; set; }
    public GameObject HPBar;
    public GameObject SPBar;
    RectTransform sp;
    RectTransform hp;

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
        hp = HPBar.GetComponent<RectTransform>();
        isDead = false;
    }

    protected override void UpdateAfterReceiveAttack()
    {
        base.UpdateAfterReceiveAttack();
    }

    public void SetHp(float Damage)
    {
        curHP -= Damage;
        if (curHP >= maxHP)
        {
            curHP = maxHP;
        }

        else if (curHP <= 0f)
        {
            curHP = 0f;
            isDead = true;
        }
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
        // player 캐릭터 스테미너 bar 실시간 UI 상태 변화
        float _sp = curSP / 100f;
        sp.localScale = new Vector3(_sp, sp.localScale.y, sp.localScale.z);

        // player 캐릭터 HP bar 실시간 UI 상태 변화
        float _hp = curHP / 100f;
        hp.localScale = new Vector3(_hp, hp.localScale.y, hp.localScale.z);
        Debug.Log("캐릭터HP : " + curHP);
        Debug.Log("스테미너" + curSP);

        // Player 캐릭터의 HP가 0 이하로 떨어지면 사망(삭제)
        CharacterisDead();
    }

}
