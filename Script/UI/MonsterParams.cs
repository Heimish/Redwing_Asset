using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterParams : CharacterUI
{
    public string names { get; set; }
    public GameObject MHPBar;
    RectTransform hp;

    public override void InitParams()
    {
        names = "Enemy";
        maxHP = 100f;
        curHP = maxHP;
        attackMin = 10f;
        attackMax = 20f;
        defense = 1f;
        saveHP = maxHP;

        isDead = false;
    }

    private void FixedUpdate()
    {
        if (curHP > saveHP)
        {
                curHP -= 30 * Time.deltaTime;
                if (curHP < saveHP)
                {
                    curHP = saveHP;
                    Debug.Log("Monster`s HP : " + curHP);

                    if (curHP <= 0)
                    {
                        isDead = true;
                    }
                }      
        }
    }

    public void SetMonsterHp(float Damage)
    {
        saveHP -= Damage;
        curHP = Mathf.Clamp(curHP, 0, maxHP);
    }

    protected override void UpdateAfterReceiveAttack()
    {
        base.UpdateAfterReceiveAttack();
    }

    private void Awake()
    {
        hp = MHPBar.GetComponent<RectTransform>();
        isDead = false;
    }

    void Update()
    {
        // 몬스터 HP bar 실시간 UI 상태 변화
        float _hp = curHP / 100f;
        hp.localScale = new Vector3(_hp, hp.localScale.y, hp.localScale.z);

        // 몬스터 HP가 0 이하로 떨어지면 사망(삭제)
        CharacterisDead();

        //Debug.Log("몬스터 HP : " + curHP);
    }
}
