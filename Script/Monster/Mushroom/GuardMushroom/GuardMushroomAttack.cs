using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GuardMushroomAttack : GuardMushroomStateBase
{
    
    public float Dltime;

    public override void BeginState()
    {
        base.BeginState();
    }

    public override void EndState()
    {
        base.EndState();
    }

    void Start()
    {
        Dltime = 0f;   
    }

    public void AttackCheck()
    {
        if (GuardMushroom.GetDistanceFromPlayer() < GuardMushroom.MStat.AttackDistance + 2.0f)
        {
            Debug.Log("Hit!");
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerParams>().SetHp(10.0f);

            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerParams>().curHP == 0)
            {
                GuardMushroom.SetState(GuardMushroomState.Idle);
            }
        }
    }

    void Update()
    {
        Dltime += Time.deltaTime;
        if (Dltime > 1.5f)
        {
            if (GuardMushroom.GetDistanceFromPlayer() > GuardMushroom.MStat.AttackDistance)
            {
                GuardMushroom.SetState(GuardMushroomState.Chase);
                Dltime = 0;
                return;
            }

            else
            {
                GuardMushroom.SetState(GuardMushroomState.Return);
                Dltime = 0;
                return;
            }
        }
    }
}
