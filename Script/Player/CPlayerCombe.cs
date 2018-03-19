using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerCombe : CPlayerBase
{
	void Update ()
    {
        if (_PlayerManager.m_bSwap == false)
        {
            if (_PlayerManager.m_nAttackCombo == 0)
            {
                _PlayerManager.PlayerHitCamera(4f);
            }
            else if (_PlayerManager.m_nAttackCombo == 1)
            {
                _PlayerManager.PlayerHitCamera(3.5f);
            }
            else if (_PlayerManager.m_nAttackCombo == 2)
            {
                _PlayerManager.PlayerHitCamera(3.0f);
            }
        }
    }
}
