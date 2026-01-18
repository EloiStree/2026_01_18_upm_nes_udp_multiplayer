using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using UnityEngine;
using UnityEngine.Events;
public class NesMultiMono_DispalyCurrentIp : MonoBehaviour

{
    [System.Serializable]
    public class StringEvent : UnityEvent<string> { }

    public StringEvent m_onIpv4Collected;
    public bool m_pushIpv4OnStart = true;

    void Start()
    {
        if(m_pushIpv4OnStart)
        PushCurrentIpToUnityEvent();
    }

    private void PushCurrentIpToUnityEvent()
    {
        string ipv4s = string.Join(",", GetAllLocalIPv4s());
        m_onIpv4Collected?.Invoke(ipv4s);
    }

    private List<string> GetAllLocalIPv4s()
    {
        List<string> results = new List<string>();

        foreach (var ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(ip))
            {
                results.Add(ip.ToString());
            }
        }

        return results;
    }
}

