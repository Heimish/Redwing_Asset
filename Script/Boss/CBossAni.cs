using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBossAni : CBossBase
{
    Animator _BossAni;
    public void Animation_Change(int animation_number)
    {
        _BossAni = GetComponent<Animator>();
        _BossAni.SetInteger("BossMotion", animation_number);
    }
}
