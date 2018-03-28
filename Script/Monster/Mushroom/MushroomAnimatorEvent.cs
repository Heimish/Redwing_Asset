using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomAnimatorEvent : MonoBehaviour {

    private GuardMushroom _GuardMushroom;
    private QueenMushroom _QueenMushroom;

    private void Awake()
    {
        _GuardMushroom = transform.GetComponent<GuardMushroom>();
        _QueenMushroom = transform.GetComponent<QueenMushroom>();

    }

    void GuardMHitCheck()
    {
        print(_GuardMushroom.GetCurrentState().GetType().ToString());
        GuardMushroomAttack _GuardMAttaked = _GuardMushroom.GetCurrentState() as GuardMushroomAttack;
        Debug.Log(_GuardMAttaked);
        if(_GuardMAttaked != null)
        {
            Debug.Log("Not null");
            _GuardMAttaked.AttackCheck();
        }
    }
}
