using UnityEngine;
using System.Collections;

public class AttackCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
        m_Collider = GetComponentInChildren<Collider>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            HumanBehavior brain = other.gameObject.GetComponent<HumanBehavior>();
            if (!brain.isHit)
            {
                Debug.Log("Hit");
                brain.m_health[brain.m_level] -= 1;
                if (brain.m_health[brain.m_level] >= 1)
                {
                    brain.HitTime = 0.0f;
                    brain.isHit = true;
                }
                else
                {
                    Animator m_Animator = brain.GetComponentInChildren<Animator>();
                    m_Animator.SetBool("IsDead", true);
                    brain.isDead = true;
                }
            }
        }
    }

    private Collider m_Collider;
}
