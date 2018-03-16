using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCameraFind : MonoBehaviour
{
    public static CCameraFind _instance = null;    
    public float CameraMoveSpeed = 120.0f;
    public GameObject CameraFollowObj;
    public float clampAngle = 80.0f;
    public float inputSensitivity = 150.0f; // 움직이는 속도값
    public float mouseX; // 현재 계속 받아오는 마우스X값
    public float mouseY; // 현재 계속 받아오는 마우스Y값
    public float finalInputX; // 마우스X값 저장
    public float finalInputZ; // 마우스Y값 저장
    private float rotY = 0.0f; // 카메라의 Y축값
    private float rotX = 0.0f; // 카메라의 X축값

    // 캐릭터가 카메라를 바라보는지 
    public bool m_bCamera;
    // 카메라의 로테이션 y값을 저장하기 위해 사용
    public Quaternion _CameraRight = Quaternion.identity;

    public float m_fLerpSpeed;

    void Start()
    {
        CCameraFind._instance = this;
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        m_bCamera = true;
        m_fLerpSpeed = 100;

    }
    void Update()
    {
        // 따로 설정한 Input 값을 가져옴
        float inputX = Input.GetAxis("RightStickHorizontal");
        float inputZ = Input.GetAxis("RightStickVertical");

        // 마우스 x, y값 받아오기
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");   

        // 설정됀 마우스의 값을 서로 더해줌 
        finalInputX = inputX + mouseX;
        finalInputZ = inputZ + mouseY;

        // 마우스정보 * 지정속도 -> rotY(카메라 로테이션)값에 계속 더해줌
        rotY += finalInputX * inputSensitivity * Time.deltaTime;
        rotX += finalInputZ * inputSensitivity * Time.deltaTime;

        // 카메라 각도 360' 회전하는걸 막아주며 지정됀 값범위 내에서만 확인가능
        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        // 카메라 로테이션 돌려주기
        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

        // 카메라 마우스 y값을 보간
        _CameraRight.eulerAngles = new Vector3(0, rotY, 0);
    }
    void LateUpdate()
    {
        CameraUpdater();
    }
    void CameraUpdater()
    {
        // 플레이어 중심에 설정한 오브젝트 좌표값을 받아옴
        Transform target = CameraFollowObj.transform;
        //transform.position = Vector3.MoveTowards(transform.position, target.position, CameraMoveSpeed * Time.deltaTime);
        if (CPlayerManager._instance.m_nAttackCombo == 0)
        {
            if (CPlayerManager._instance.m_bSwap)
                m_fLerpSpeed = 10;
            else
            {
                if (m_fLerpSpeed <= 100)
                {
                    m_fLerpSpeed += 2;
                }
            }
        }
        else
        {
            m_fLerpSpeed = 10;
        }
        transform.position = Vector3.Lerp(transform.position, target.position, m_fLerpSpeed * Time.deltaTime);
    }
}
