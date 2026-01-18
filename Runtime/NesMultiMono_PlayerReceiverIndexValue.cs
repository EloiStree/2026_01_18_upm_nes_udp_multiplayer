using System;
using UnityEngine;
using UnityEngine.Events;

public class NesMultiMono_PlayerReceiverIndexValue : MonoBehaviour
{
    public int m_playerIndex = 1;
    public int m_lastValueReceived;
    public UnityEvent<int> m_onIntegerCommandReceived;
    public UnityEvent<int> m_onIndexChangedByCode;

    public void Awake()
    {
        m_onIndexChangedByCode.Invoke(m_playerIndex);
    }
    public int GetPlayerIndex() { 
        return m_playerIndex;
    }
    public void SetPlayerIndex(int index)
    {
        m_playerIndex = index;
        m_onIndexChangedByCode.Invoke(index);
    }
    public void PushInValue(int value)
    {
        m_lastValueReceived = value;
        m_onIntegerCommandReceived.Invoke(value);
    }
    public void PushInValueIfGoodIndex(int index,int value)
    {
        if (index== m_playerIndex)
            PushInValue(value);
    }


    public bool IsIndex(int index)
    {
        return (index == m_playerIndex);
    }
}
