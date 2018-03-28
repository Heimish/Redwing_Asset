using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMushroomChase : GuardMushroomStateBase
{
    public override void BeginState()
    {
        base.BeginState();
    }

    public override void EndState()
    {
        base.EndState();
    }

    void Update()
    {
        if (GuardMushroom.GetDistanceFromPlayer() < GuardMushroom.MStat.ChaseDistance && GuardMushroom.GetDistanceFromPlayer() > GuardMushroom.MStat.AttackDistance)
        { 
            GuardMushroom.GoToDestination(GuardMushroom.Player.position, GuardMushroom.MStat.MoveSpeed, GuardMushroom.rotAnglePerSecond);
        }

        if (GuardMushroom.GetDistanceFromPlayer() < GuardMushroom.MStat.AttackDistance)
        {
            if (GuardMushroom.attackTimer > GuardMushroom.attackDelay)
            {
                GuardMushroom.SetState(GuardMushroomState.Attack);
                return;
            }
        }

        else
        {
            GuardMushroom.SetState(GuardMushroomState.Return);
            return;
        }
    }
}
