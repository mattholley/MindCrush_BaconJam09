using UnityEngine;
using System.Collections;

public class HumanPlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		m_playerBehavior = GetComponent<HumanBehavior>();
		m_controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (!m_playerBehavior.isDead)
        {
            //Aim
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo))
            {
                m_playerBehavior.m_aimTarget = hitInfo.point;
            }

            //Item
            m_playerBehavior.SetIsItemEnabled(Input.GetButton("Fire1"));

            if (Input.GetButtonUp("Fire1"))
                ScreenText.FloatText("Pew!!!", this.gameObject);

            //Movement
            Vector2 direction = Vector2.zero;
            direction.x += Input.GetAxis("Horizontal");
            direction.y += Input.GetAxis("Vertical");

            if (m_controller.isGrounded)
            {
                m_playerBehavior.Jump(Input.GetAxis("Jump"));
            }

            m_playerBehavior.SetVelocity(direction);
        }
	}

	private HumanBehavior m_playerBehavior;
	private CharacterController m_controller;
}
