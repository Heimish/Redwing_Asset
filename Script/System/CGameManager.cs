using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameManager : MonoBehaviour
{
    public static CGameManager _instance;
    public Transform _PlayerPos;
	void Start () {
        CGameManager._instance = this;

    }
	
	// Update is called once per frame
	void Update () {
	}
}
