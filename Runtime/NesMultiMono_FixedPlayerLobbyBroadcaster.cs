using System;
using System.Collections.Generic;
using UnityEngine;

public class NesMultiMono_FixedPlayerLobbyBroadcaster : MonoBehaviour
{
    public GameObject m_parentToOverwatch;
    public List<NesMultiMono_PlayerReceiverIndexValue> m_playerFound;
    public bool m_refreshListAtStart=true;
    public bool m_overridePlayerIndexWithOrderAtStart=true;

    void Start()
    {
        if (m_refreshListAtStart)
            RefreshListOfPlayers();
        if (m_overridePlayerIndexWithOrderAtStart)
            OverrideIndexOfPlayerWithFoundOrder();
    }

    public void PushCommandToPlayer(int index, int value) { 
    
        foreach (var player in m_playerFound)
        {
            if (player.IsIndex(index))
                player.PushInValue( value);
        }
    }

    [ContextMenu("Override index of player with found order")]
    public void OverrideIndexOfPlayerWithFoundOrder()
    {
        for (int i = 0; i < m_playerFound.Count; i++)
        {
            m_playerFound[i].SetPlayerIndex(i + 1);
        }
    }



    [ContextMenu("Refresh the list of players")]
    public void RefreshListOfPlayers()
    {
        if (m_parentToOverwatch == null)
        {
            Debug.LogWarning("Parent to overwatch is null. Nothing to scan.");
            return;
        }

        if (m_playerFound == null)
            m_playerFound = new List<NesMultiMono_PlayerReceiverIndexValue>();
        else
            m_playerFound.Clear();

        ScanRecursive(m_parentToOverwatch.transform);
    }

    private void ScanRecursive(Transform current)
    {
        // Check current GameObject
        NesMultiMono_PlayerReceiverIndexValue receiver =
            current.GetComponent<NesMultiMono_PlayerReceiverIndexValue>();

        if (receiver != null)
            m_playerFound.Add(receiver);

        // Manually iterate children using childCount
        for (int i = 0; i < current.childCount; i++)
        {
            Transform child = current.GetChild(i);
            ScanRecursive(child);
        }
    }
}
