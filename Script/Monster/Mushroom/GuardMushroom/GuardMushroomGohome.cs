using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMushroomGohome : GuardMushroomStateBase
{
    public override void BeginState()
    {
        base.BeginState();
    }

    public override void EndState()
    {
        base.EndState();
    }


        /*GuardMushroom.MoveToDestination();
        transform.position = new Vector3(GuardMushroom.GoHomePositionX,GuardMushroom.GoHomePositionY, GuardMushroom.GoHomePositionZ);

        GuardMushroom.MoveToTarget(new Vector3(GuardMushroom.GoHomePositionX,
           GuardMushroom.GoHomePositionY, GuardMushroom.GoHomePositionZ));*/

    void Update()
    {
        if (GuardMushroom.GetDistanceFromPlayer() > GuardMushroom.MStat.ChaseDistance)
        {
            GuardMushroom.GoToDestination(GuardMushroom.HomePosition, GuardMushroom.MStat.MoveSpeed, GuardMushroom.rotAnglePerSecond);

            if (Vector3.Distance(transform.position, new Vector3(GuardMushroom.GoHomePositionX,
                GuardMushroom.GoHomePositionY, GuardMushroom.GoHomePositionZ)) <= 2.0f)
            {
                GuardMushroom.SetState(GuardMushroomState.Idle);
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
