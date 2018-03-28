using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchSkillAObject : MonoBehaviour
{
    private WitchBoss m_witch;
    private Transform m_target;
    private List<WitchSkillAFire> m_fires = new List<WitchSkillAFire>();
    private int m_state;
    private int m_fireIdx;
    private float m_fireTime;
    private float m_readyTime;

    public void Init(WitchBoss witch)
    {
        m_witch = witch;
        foreach (WitchSkillAFire c in GetComponentsInChildren<WitchSkillAFire>())
        {
            m_fires.Add(c);
        }
    }

    public void OnSkill(Transform target)
    {
        m_target = target;
        m_state = 1;
        m_fireIdx = 0;
        m_fireTime = 0.0f;
        m_readyTime = 0.0f;

        Vector3 witchPos = m_witch.transform.position;
        witchPos.y += 0.0f;

        transform.position = witchPos;
        transform.rotation = m_witch.transform.rotation;

        foreach (WitchSkillAFire f in m_fires)
        {
            f.transform.localPosition = Vector3.zero;
        }
    }

    void Update()
    {
        switch (m_state)
        {
            case 1:
                InitFiresPosition();
                break;

            case 2:
                MoveFires();
                break;
        }
    }

    private void InitFiresPosition()
    {
        ReadyMove();

        m_readyTime += Time.deltaTime;

        if (m_readyTime < 1.0f)
            return;

        m_state = 2;
        m_fireIdx = 0;
    }

    private void ReadyMove()
    {
        if (m_fireIdx >= m_fires.Count)
            return;

        m_fires[m_fireIdx].Ready(PositionCheck());
        //m_fires[i].Ready(new Vector3(-1.5f + ((float)i / (m_fires.Count - 1) * 3.0f),
        //                                                    1.5f, 0.0f));

        m_fireIdx++;

    }

    private void MoveFires()
    {
        m_fireTime += Time.deltaTime;

        if (m_fireTime < 0.2f)
            return;

        Vector3 target = m_target.position;
        target.y += 1.0f;

        m_fires[m_fireIdx].FireInit(target, 700.0f);

        m_fireIdx++;
        m_fireTime = 0.0f;

        if (m_fireIdx == m_fires.Count)
            m_state = 3;
    }

    private Vector3 PositionCheck()
    {
        Vector3 pos = Vector3.zero;
        int loopCount = 0;

        while (CrashCheck(out pos))
        {
            loopCount++;

            if (loopCount >= 100)
            {
                Debug.LogError("영역이 너무 좁아서 발생하는 에러압니다. 영역을 줄여주세요");
                break;
            }
        }

        return pos;
    }

    private bool CrashCheck(out Vector3 pos)
    {
        pos = new Vector3(Random.Range(-1.6f, 1.6f), Random.Range(0.8f, 2.2f), Random.Range(-1.6f, 0.8f));

        for (int i = 0; i < m_fireIdx; i++)
        {
            //print(m_fireIdx + " " + i + " " + Vector3.Distance(pos, m_fires[i].ReadyPos));
            if (Vector3.Distance(pos, m_fires[i].ReadyPos) <= 1.0f)
                return true;
        }

        return false;
    }
}
