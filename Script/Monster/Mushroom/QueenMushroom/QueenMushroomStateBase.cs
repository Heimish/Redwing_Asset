using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(QueenMushroom))]
public class QueenMushroomStateBase : MonoBehaviour
{
    public QueenMushroom _QueenMushroom;
    public QueenMushroom QueenMushroom { get { return _QueenMushroom; } set { _QueenMushroom = value; } }

    private void Awake()
    {
        _QueenMushroom = GetComponent<QueenMushroom>();
    }

    public virtual void BeginState()
    {
    }

    public virtual void EndState()
    {
    }
}
