using UnityEngine;
using System.Collections;

public class QuickAndDirtyHitCheck : MonoBehaviour {

    void Start()
    {
        m_nLightCollider.GetComponent<MeshCollider>().enabled = false;
    }

    public void ToggleLightCollider()
    {
        if (m_nLightCollider.GetComponent<MeshCollider>().enabled)
        {
            m_nLightCollider.GetComponent<MeshCollider>().enabled = false;
            m_isActive = false;
        }
        else
        {
            m_nLightCollider.GetComponent<MeshCollider>().enabled = true;
            m_isActive = true;
        }
    }

    [Header("Flashlight Specific Properties")]
    public GameObject m_nLightCollider;
    public bool m_isActive;
}
