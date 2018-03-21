using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    private CPlayerMove _CPlayerMove = null;
    public CPlayerMove _PlayerMove { get { return _CPlayerMove; } }

    public float maxHP { get; set; }
    public float curHP { get; set; }
    public float maxSP { get; set; }
    public float curSP { get; set; }
    public float attackMin { get; set; }
    public float attackMax { get; set; }
    public float defense { get; set; }

    public float UItime = 0f;

    public bool isDead { get; set; }

    void Start()
    {

        InitParams();

    }

    public virtual void InitParams()
    {

    }

    public float GetRandomAttack()
    {
        float randAttack = Random.Range(attackMin, attackMax + 1);

        return randAttack;
    }

    public void SetEnemyAttack(float enemyAttackPower)
    {
        curHP -= enemyAttackPower;
        UpdateAfterReceiveAttack();
    }

    protected virtual void UpdateAfterReceiveAttack()
    {
        print(name + "'s HP: " + curHP);
    }

}
