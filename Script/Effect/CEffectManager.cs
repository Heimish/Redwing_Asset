using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Effect_State
{
    Swap = 0,
    BossBlock,
    Foothold,
}
public class CEffectManager : MonoBehaviour
{
    // 싱글턴
    public static CEffectManager _instance = null;

    // Enum값으로 이펙트 설정
    Effect_State _Effect_State = Effect_State.Swap;

    // 딕셔너리로 키값으로 관리
    Dictionary<Effect_State, GameObject> _Effects = new Dictionary<Effect_State, GameObject>();
    

    void Start ()
    {
        // 싱글턴
        CEffectManager._instance = this;

        // 딕셔너리 안에 enum으로 설정됀 값에 리소스 로드시켜두기
        _Effects.Add(Effect_State.Swap, Resources.Load("Effect/SwapEffect") as GameObject);
        _Effects.Add(Effect_State.BossBlock, Resources.Load("Effect/Boss_Block") as GameObject);
        _Effects.Add(Effect_State.Foothold, Resources.Load("Effect/Boss_Foothold") as GameObject);
    }

    // 이펙트 불러올 키값,좌표
    public GameObject EffectCreate(int nID, Vector3 vPos)
    {
        // 일반적으로 오브젝트 가져올때 방식으로 사용하고, 인자값을 enum값으로 형변환시킴
        GameObject effect = Instantiate(_Effects[(Effect_State)nID]);
        // 이펙트 좌표 설정
        effect.transform.position = new Vector3(vPos.x, vPos.y, vPos.z);

        return effect;
    }
}
