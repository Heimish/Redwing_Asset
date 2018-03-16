using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerManager : MonoBehaviour
{
    public static CPlayerManager _instance = null;

    private CPlayerMove _CPlayerMove = null;
    public CPlayerMove _PlayerMove { get { return _CPlayerMove; } }
    
    private CPlayerAni_Contorl _CPlayerAni_Contorl = null;
    public CPlayerAni_Contorl _PlayerAni_Contorl {  get { return _CPlayerAni_Contorl; } }

    private CPlayerCombe _CPlayerCombe = null;
    public CPlayerCombe _PlayerCombe { get { return _CPlayerCombe; } }

    private CPlayerSkill _CPlayerSkill = null;
    public CPlayerSkill _PlayerSkill { get { return _CPlayerSkill; } }

    private CPlayerSwap _CPlayerSwap = null;
    public CPlayerSwap _PlayerSwap { get { return _CPlayerSwap; } }

    private CPlayer_AniChange _CPlayer_AniChange = null;
    public CPlayer_AniChange _Player_AniChange { get { return _CPlayer_AniChange; } }

    // 플레이어 속도
    [SerializeField]
    private float m_fMoveSpeed;
    public float m_MoveSpeed { get { return m_fMoveSpeed; } set { m_fMoveSpeed = value; } }

    // 플레이어 중력
    [SerializeField]
    private float m_fGravity;
    public float m_Gravity { get { return m_fGravity; } set { m_fGravity = value; } }

    // 플레이어 HP
    [SerializeField]
    private float m_fPlayerHp;
    public float m_PlayerHp { get { return m_fPlayerHp; } set { m_fPlayerHp = value; } }

    // 플레이어 스테미나
    [SerializeField]
    private float m_fPlayerStm;
    public float m_PlayerStm { get { return m_fPlayerStm; } set { m_fPlayerStm = value; } }

    // 플레이어 게이지 (반격,방어 등)
    [SerializeField]
    private float m_fPlayerGauge;
    public float m_PlayerGauge { get { return m_fPlayerGauge; } set { m_fPlayerGauge = value; } }

    // 플레이어 반격공격 데미지
    [SerializeField]
    private int m_nPlayerParryDmg;
    public int m_PlayerParryDmg { get { return m_nPlayerParryDmg; } set { m_nPlayerParryDmg = value; } }

    // 플레이어 공격력
    [SerializeField]
    private int[] m_nPlayerHitDmg = new int[3];
    public int[] m_PlayerHitDmg { get { return m_nPlayerHitDmg; } set { m_nPlayerHitDmg = value; } }

    // 플레이어 콤보 공격시 이동거리
    [SerializeField]
    private float[] m_fPlayerHitMove = new float[3];
    public float[] m_PlayerHitMove { get { return m_fPlayerHitMove; } set { m_fPlayerHitMove = value; } }

    public Quaternion vPlayerQuaternion = Quaternion.identity; // 플레이어 로테이션
    public CharacterController _PlayerController; // 현재 캐릭터가 가지고있는 캐릭터 컨트롤러 콜라이더.
    public bool m_bMove; // 플레이어가 이동중인지
    public bool m_bAttack; // 플레이어가 공격중인지 체크
    public int m_nAttackCombo; // 플레이어 타수콤보 체크 ( 1타,2타,3타 연계에 사용함)
    public bool m_bAnimator; // 기본 공격이 아닌 스킬을 사용할때 다른동작을 막기위해 사용
    public bool m_bSwap; // 스왑할때 애니메이션 Idle 안들어가게 막기


    void Start()
    {

        CPlayerManager._instance = this;
        _CPlayerMove = GetComponent<CPlayerMove>();
        _CPlayerAni_Contorl = GetComponent<CPlayerAni_Contorl>();
        _CPlayerCombe = GetComponent<CPlayerCombe>();
        _CPlayerSkill = GetComponent<CPlayerSkill>();
        _PlayerController = GetComponent<CharacterController>();
        _CPlayerSwap = GetComponent <CPlayerSwap>();

        // 플레이어 스탯 설정
        m_fMoveSpeed = 6;
        m_fGravity = 10;
        m_fPlayerHp = 100;
        m_fPlayerStm = 100;
        m_fPlayerGauge = 100;
        m_nAttackCombo = 0;

        m_bMove = true;
        m_bAnimator = true;
    }

    void Update()
    {
        // 이동
        PlayerRotation();
        //PlayerDed();
    }

    // 플레이어 사망시
    void PlayerDed()
    {
        if (m_fPlayerHp <= 0)
        {            
            return;
        }
    }

    // 플레이어 로테이션을 부드럽게 이동
    public void PlayerRotation()
    {
        if(CCameraFind._instance.m_bCamera)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, vPlayerQuaternion, 20 * Time.deltaTime);
        }
    }
    // 플레이어 이동속도 설정
    public float PlayerMoveSpeed(float speed)
    {
        m_fMoveSpeed = speed;
        return m_fMoveSpeed;
    }

    // 플레이어 스테미나 처리
    public float PlayerStm(int type, float sizeStm)
    {
        if (type == 1) m_fPlayerStm -= sizeStm;
        else if (type == 2) m_fPlayerStm += sizeStm;
        return m_fPlayerStm;
    }

    // 플레이어 데미지 처리 
    public float PlayerHp(int type, float sizeHp)
    {
        if (type == 1) m_fPlayerHp -= sizeHp;
        else if (type == 2) m_fPlayerHp += sizeHp;
        return m_fPlayerHp;
    }

    // 카메라 연출 줌,인 연출 함수
    public void PlayerHitCamera(float hitDitance)
    {
        CCameraRayObj._instance.MaxCamera(hitDitance);
    }
    
    // 플레이어 스탯(데미지) 관리
    public void PlayerStat(int dmg1, int dmg2, int dmg3, float speed)
    {
        m_nPlayerHitDmg[0] = dmg1;
        m_nPlayerHitDmg[1] = dmg2;
        m_nPlayerHitDmg[2] = dmg2;
        m_fMoveSpeed = speed;
        // 이펙트 넣어주기
    }
}
