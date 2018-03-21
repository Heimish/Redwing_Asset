using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossParams : CharacterUI
{
    public string names { get; set; }
    public GameObject BMHPBar;
    public GameObject BossMonster;
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

    public void SetHp(float Damage)
    {
        curHP -= Damage;
        if(curHP >= maxHP)
        {
            curHP = maxHP;
        }

        else if(curHP <= 0f)
        {
            curHP = 0f;
            isDead = true;
        }
    }

    public void BossisDead()
    {
        if(isDead == true)
        {
            Destroy(BossMonster, 1f);
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
        float _hp = curHP / 200f;
        hp.localScale = new Vector3(_hp, hp.localScale.y, hp.localScale.z);
        BossisDead();
        Debug.Log("보스 HP : " + curHP);
    }
}
