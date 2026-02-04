using System;
using UnityEngine;
using UnityEngine.Events;

public class NesMultiMono_UnderMapRespawn : MonoBehaviour
{

    private void Reset()
    {
        m_rigidBodyToReset = GetComponentInChildren<Rigidbody>();
        m_targetToMove = m_rigidBodyToReset.transform;

    }
    public Vector3 m_positionAtOnEnable;
    public Rigidbody m_rigidBodyToReset;
    public Transform m_targetToMove;
    public float m_unityThresholdY = -10f;

    public UnityEvent m_onBeforeRespawned;
    public UnityEvent m_onAfterRespawned;

    private void OnEnable()
    {

        m_positionAtOnEnable = m_targetToMove.position;

    }
    public void Update()
    {
        if (m_targetToMove.position.y < m_unityThresholdY)
        {
            Respawn();
        }

    }

    private void Respawn()
    {
        m_onBeforeRespawned.Invoke();
        m_targetToMove.position = m_positionAtOnEnable;
        m_rigidBodyToReset.linearVelocity = Vector3.zero;
        m_rigidBodyToReset.angularVelocity = Vector3.zero;
        m_onAfterRespawned.Invoke();

    }
}
