using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBossBase : MonoBehaviour
{
    [HideInInspector]
    public CBossManager _BossManager;

    private void Awake()
    {
        _BossManager = GetComponent<CBossManager>();
    }
}
