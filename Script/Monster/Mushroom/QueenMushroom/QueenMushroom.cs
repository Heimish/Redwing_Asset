using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public enum QueenMushroomState
{
    Idle = 0,
    Chase,
    Attack,
    Return,
    Healing,
    Stungun,
    Gohome,
    Dead
}

[RequireComponent(typeof(MonsterStat))]
public class QueenMushroom : MonsterBase
{
    public QueenMushroomState startState;
    public QueenMushroomState currentState;
    bool _isInit = false;
    private Dictionary<QueenMushroomState, QueenMushroomStateBase> _states = new Dictionary<QueenMushroomState, QueenMushroomStateBase>();

    // 플레이어 위치
    private Transform _player;
    public Transform Player { get { return _player; } }

    // 몬스터 지정된 Home 값
    private Vector3 _home;
    public Vector3 Home { get { return _home; } }

    // 몬스터 지정 위치 좌표 x + y + z를 합한 값
    private Vector3 _homePosition;
    public Vector3 HomePosition { get { return _homePosition; } }

    float _curTime;
    public float CurTime { set { _curTime = value; } get { return _curTime; } }

    float _maxTime;
    public float MaxTime { set { _maxTime = value; } get { return _maxTime; } }

    public float attackDelay = 3.0f; // 공격 딜레이 속도
    public float attackTimer = 0.0f; // 공격 딜레이 시간
    public float rotAnglePerSecond = 360.0f;// 몬스터 초당 회전 속도

    // 몬스터 지정 위치 좌표 x + y + z
    public float GoHomePositionX;
    public float GoHomePositionY;
    public float GoHomePositionZ;

    public MonsterStat MStat { get { return m_stat; } set { m_stat = value; } }

    private int _animParamID;


    public QueenMushroomStateBase GetCurrentState()
    {
        return _states[currentState];
    }

    public void SetState(QueenMushroomState newState)
    {
        if (_isInit)
        {
            _states[currentState].enabled = false;
            _states[currentState].EndState();
        }
        currentState = newState;
        _states[currentState].BeginState();
        _states[currentState].enabled = true;
        m_anim.SetInteger(_animParamID, (int)currentState);
        /*if (currentState == MonsterState.Dead)
        {
            _isDead = true;
        }*/
    }

    public float GetDistanceFromPlayer() // Player 캐릭터와 거리를 되돌려줄 함수
    {
        float distance = Vector3.Distance(transform.position, _player.position);

        return distance;
    }

    public void TurnToDestination()
    {
        Quaternion lookRotation = Quaternion.LookRotation(Player.position - transform.position);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation,
            Time.deltaTime * rotAnglePerSecond);
    }

    public void MoveToDestination()
    {
        m_controller.Move(transform.forward * m_stat.MoveSpeed * Time.deltaTime);
    }

    // 움직이는 함수 (속도 입력이 포함 되어있음)
    public void GoToDestination(Vector3 target, float moveSpeed, float turnSpeed)
    {
        Transform t = m_controller.transform;
        Vector3 Forward = target - t.position;
        Forward.y = 0.0f;
        if (Forward != Vector3.zero)
        {
            t.rotation = Quaternion.RotateTowards(
                t.rotation,
                Quaternion.LookRotation(Forward),
                turnSpeed * Time.deltaTime);
        }

        Vector3 nextPos = Vector3.MoveTowards(
            t.position,
            target,
            moveSpeed * Time.deltaTime);

        Vector3 deltaMove = nextPos - t.position;
        deltaMove.y += Physics.gravity.y * Time.deltaTime;
        m_controller.Move(deltaMove);
    }

    private void Awake()
    {
        _homePosition = (new Vector3(GoHomePositionX, GoHomePositionY, GoHomePositionZ));
        m_stat = GetComponent<MonsterStat>();
        m_controller = GetComponentInChildren<CharacterController>();
        m_anim = GetComponentInChildren<Animator>();
        m_stat.ChaseDistance = 10.0f;
        m_stat.AttackDistance = 1.8f;
        m_stat.MoveSpeed = 5.0f;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _curTime = 0;
        _home = transform.position;
        _animParamID = Animator.StringToHash("CurrentState");

        QueenMushroomState[] stateValues = (QueenMushroomState[])Enum.GetValues(typeof(QueenMushroomState));
        foreach (QueenMushroomState s in stateValues)
        {
            Type FSMType = Type.GetType("QueenMushroom" + s.ToString("G"));
            QueenMushroomStateBase state = (QueenMushroomStateBase)GetComponent(FSMType);
            if (state == null)
                state = (QueenMushroomStateBase)gameObject.AddComponent(FSMType);

            state.enabled = false;
            _states.Add(s, state);
        }

        SetState(startState);
        _isInit = true;

    }

    private void Start()
    {
        if (Application.isPlaying)
        {
            SetState(startState);
            _isInit = true;
        }
    }

    void Update()
    {
        attackTimer += Time.deltaTime;
    }
}

