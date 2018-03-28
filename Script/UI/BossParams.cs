using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossParams : CharacterUI
{
    public string names { get; set; }
    public GameObject BMHPBar;
    RectTransform hp;

    public override void InitParams()
    {
        names = "BossMonster";
        maxHP = 200f;
        curHP = maxHP;
        attackMin = 10f;
        attackMax = 20f;
        defense = 1f;

        isDead = false;
    }

    public void SetBossHp(float Damage)
    {
        curHP -= Damage;
        curHP = Mathf.Clamp(curHP, 0, maxHP);

        if (curHP == 0)
        {
            isDead = true;
        }
    }

    protected override void UpdateAfterReceiveAttack()
    {
        base.UpdateAfterReceiveAttack();
    }

    private void Awake()
    {
        hp = BMHPBar.GetComponent<RectTransform>();
        isDead = false;
    }

    void Update()
    {
        // Boss 캐릭터 HP bar 실시간 UI 상태 변화
        float _hp = curHP / 200f;
        hp.localScale = new Vector3(_hp, hp.localScale.y, hp.localScale.z);

        // Boss 캐릭터의 HP가 0 이하로 떨어지면 사망(삭제)
        CharacterisDead();

       // Debug.Log("보스 HP : " + curHP);
    }
}
