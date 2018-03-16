using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    Idle,
    Run,
    Attack
}

public class CBossFMS : MonoBehaviour
{
    BossState _BossState = BossState.Idle;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    void BossFMS()
    {
        switch(_BossState)
        {
            case BossState.Idle:
                {

                }
                break;
            case BossState.Run:
                {

                }
                break;
            case BossState.Attack:
                {

                }
                break;
        }
    }

    
}
