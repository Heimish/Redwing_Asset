using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMushroomIdle : GuardMushroomStateBase
{

    public Vector3 direction;
    public float velocity;
    public float default_velocity;
    public float accelaration;
    public Vector3 default_direction;

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
        GuardMushroom.attackTimer = 0f;
        // 가속도 지정 
        accelaration = 0.1f;
        default_velocity = 0.1f;
        StartCoroutine("RandomeAction");
    }
    IEnumerator RandomeAction()
    {
        //랜덤값 움직임 방향 벡터
        default_direction.x = Random.Range(-2.0f, 2.0f);
        default_direction.z = Random.Range(-2.0f, 2.0f);
        yield return new WaitForSeconds(7.0f);
        StartCoroutine("RandomeAction");
    }

    void Update()
    {
        GuardMushroom.GoToDestination(new Vector3(this.transform.position.x + default_direction.x, this.transform.position.y, this.transform.position.z + default_direction.z), 1.0f, GuardMushroom.rotAnglePerSecond);
      
        if (Vector3.Distance(this.transform.position, GuardMushroom.HomePosition) > 10.0f)
        {
            GuardMushroom.GoToDestination(GuardMushroom.HomePosition, 1.0f, GuardMushroom.rotAnglePerSecond);
        }

        if (GuardMushroom.GetDistanceFromPlayer() < GuardMushroom.MStat.ChaseDistance)
        {
            GuardMushroom.GoToDestination(GuardMushroom.Player.position, GuardMushroom.MStat.MoveSpeed, GuardMushroom.rotAnglePerSecond);
            GuardMushroom.SetState(GuardMushroomState.Chase);
            return;
        }
    }
}
