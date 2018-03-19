using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerAttackEffect : MonoBehaviour
{
    public GameObject[] _AttackEffect;

    public void EffectOff()
    {
        for(int i = 0; i < _AttackEffect.Length; i++)
            _AttackEffect[i].SetActive(false);
    }
    public void Effect1()
    {
        _AttackEffect[0].SetActive(true);
    }
    public void Effect2()
    {
        _AttackEffect[1].SetActive(true);
    }
    public void Effect3()
    {
        _AttackEffect[2].SetActive(true);
    }

    public void EffectOnOff(bool one, bool two, bool three)
    {
        _AttackEffect[0].SetActive(one);
        _AttackEffect[1].SetActive(two);
        _AttackEffect[2].SetActive(three);
    }
}
