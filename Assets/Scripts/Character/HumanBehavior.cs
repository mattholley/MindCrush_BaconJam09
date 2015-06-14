using UnityEngine;
using System.Collections;

public class HumanBehavior : CharacterBehavior {

	// Use this for initialization
	protected override void Start () {
		base.Start();
        m_Animator = GetComponent<Animator>();

		GameObject inventoryItemObject = GameObject.Instantiate(m_tempInventoryItemPrefab);
		if(inventoryItemObject)
		{
			inventoryItemObject.transform.SetParent(m_hand.transform, false);
			
			InventoryItem inventoryItem = inventoryItemObject.GetComponent<InventoryItem>();
			Debug.Assert(inventoryItem);
			if(!inventoryItem)
			{
				Destroy(inventoryItemObject);
			}
			else
			{
				m_equippedItem = inventoryItem;
			}
		}
	}
	
	// Update is called once per frame
	protected override void Update () {
        if (!isDead)
        {
            base.Update();
            m_hand.transform.LookAt(m_aimTarget);
            m_Animator.SetFloat("velocity", m_velocity.magnitude);
            m_speedMagnitude = m_velocity.magnitude;

            if (HitTime > HitTimer)
            {
                isHit = false;
                gameObject.transform.FindChild("Group33741").GetComponent<Renderer>().material.color = Color.white;
            }
            else
            {
                HitTime += Time.deltaTime;
                gameObject.transform.FindChild("Group33741").GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }

	public override void SetVelocity(Vector2 velocity)
	{
		m_velocity.x = velocity.x * (m_moveSpeed + m_bonusMoveSpeed[m_level]);
		m_velocity.z = velocity.y * (m_moveSpeed + m_bonusMoveSpeed[m_level]);
	}

    private Animator m_Animator;
	public GameObject m_hand;

    public float m_speedMagnitude;

    public float HitTimer = 0.0f;
    public float HitTime = 0.0f;
    public bool isHit = false;
    public bool isDead = false;
}
