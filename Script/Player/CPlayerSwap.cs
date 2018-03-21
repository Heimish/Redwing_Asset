using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 낫, 검방패 모드
public enum PlayerMode
{
    Shield = 0,
    Scythe,
}
public class CPlayerSwap : CPlayerBase
{
    private CPlayerAttackEffect _CPlayerAttackEffect;
    public Transform _Follow;
    public PlayerMode _PlayerMode = PlayerMode.Shield; // 처음엔 검방패로 시작

    // _Shield 배열에 낫,검방패 오브젝트 넣어둠
    public GameObject[] _Weapon;
    private float m_fTime;
    private float m_fDisMin;
    public float m_fMoveDir;
    public bool m_bSwapAttack;

    void Start()
    {
        _CPlayerAttackEffect = GetComponent<CPlayerAttackEffect>();
        m_fDisMin = 1.5f;
        m_fMoveDir = 5f;
        m_bSwapAttack = false;
    }
    void Update ()
    {
        // Q버튼을 누르면 직업이 바뀜
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // swap 실행시, SP 소모
            GetComponent<PlayerParams>().SetcSp(-10f);

            if (_PlayerMode == PlayerMode.Shield)
            {
                SwapObj(false, false, true);
                _PlayerMode = PlayerMode.Scythe;
            }
            else
            {
                SwapObj(true, true, false);
                _PlayerMode = PlayerMode.Shield;
            }
            // 이펙트 생성
            CEffectManager._instance.EffectCreate(0, transform.position);
            // 캐릭터 0.2초동안 없애고 다시생성
            CObjActive._instance.ActiveObj(this.gameObject, 0.2f);
            // 캐릭터를 바꿨다는걸 알려줌
            _PlayerManager.m_bSwap = true;
        }

        
        // 캐릭터를 교체 할 경우
        if (_PlayerManager.m_bSwap)
        {
            // 시간 증가
            m_fTime += Time.deltaTime;
            // 0.2초됐을시  
            if (m_fTime >= 0.02f)
            {

                // 레이캐스트 쏘고 
                RayCastChack();
                // 이펙트 생성
                CEffectManager._instance.EffectCreate(0, transform.position);
                m_bSwapAttack = true;
                // 공격하면서 나가야하니 애니메이션도 공격부분으로 바꿔줌
                //_PlayerManager._PlayerAni_Contorl.Animation_Change(2);
                // 캐릭터를 다 교체함으로써 변수값을 바꿔줌
                _PlayerManager.m_bSwap = false;
                _PlayerManager.m_bMove = true;
                _PlayerManager.m_bAttack = false;
                // 시간 0초로바꿈
                _CPlayerAttackEffect.EffectOff();
                m_fTime = 0;
            }
        }

        if(m_bSwapAttack)
        {
            _PlayerManager._PlayerAni_Contorl.Animation_Change(5);
            m_fTime += Time.deltaTime;
            if(m_fTime >= 0.5f)
            {
                m_fTime = 0;
                m_bSwapAttack = false;
            }
        }
    }   
    
    // 레이캐스트 체크
    void RayCastChack()
    {
        // 레이 쏠위치, 방향 -> 캐릭터는 계속 직선만 보기때문에 forward를 사용함
        Ray ray = new Ray(_Follow.transform.position, _Follow.transform.forward);
        // hit 
        RaycastHit hit = new RaycastHit();
        // 거리
        float dir;

        Debug.DrawRay(ray.origin, ray.direction, Color.red, Mathf.Infinity);

        // 레이캐스트를 통해 어느 객체에 맞았을 경우 (범위는 캐릭터 거리 이동만큼)
        if (Physics.Raycast(ray, out hit, m_fMoveDir))
        {
            // 거리 =  (현재좌표 - 레이캐스트 맞은 객체좌표) - m_fDisMin
            // 거리 구한값에서 m_fDisMin를 빼주는 이유
            // 벽에서 사용하면 hit좌표의 끝에 걸려 위로 올라가기때문에 벽보다 좀뒤의 좌표로 계산
            dir = Vector3.Distance(transform.position, hit.point) - m_fDisMin;
            // 현재거리가 m_fDisMin거리보다 작을경우 
            if (dir > m_fDisMin)
            {
                // 이펙트생성
                CEffectManager._instance.EffectCreate(0, hit.transform.position);
                // 캐릭터의 위치를 dir 거리만큼 증가
                transform.position += transform.forward * dir;
            } // 아닐경우 함수호출중단
            else
                return;
        }
        else
        {
            // 직선방면으로 오브젝트가 없을시 m_fMoveDir만큼 이동
            transform.position += transform.forward * m_fMoveDir; // 캐릭터 거리 이동
        }
    }

    void SwapObj(bool shield1, bool shield2, bool scythe)
    {
        _Weapon[0].SetActive(shield1);
        _Weapon[1].SetActive(shield2);
        _Weapon[2].SetActive(scythe);
    }
}

