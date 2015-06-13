using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseCharacter : MonoBehaviour {


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [Header("Character Base Stats")]
    public bool m_bIsActive;
    public float m_nCHealth;
    public float m_nSpeed;
    public float m_nGravity;
    public string m_strCName;
    public string m_strCAction;
    public string m_strCreatureType;
    public enum State
    {
        WANDER, COMBAT, IDLE, DEAD
    }
    public State m_CState;

    [Header("AI Specific Properties")]
    public NavMeshAgent m_CNavMesh;
    public List<Transform> m_CWaypoints;
    public int m_CCurrentWaypoint;
    public CharacterController m_CCharacterController;
    public float m_nIdleTimer;
    public float m_nIdleTime;
}
