using System;
using UnityEngine;
using UnityEngine.Events;

public class NesMultiMono_BytesToIndexValue : MonoBehaviour
{
    public UnityEvent<int, int> m_onIndexValueIntegerReceived;
    public int m_lastReceivedIndex;
    public int m_lastReceivedValue;
    public void PushBytesInToParseAndRelay(byte[] byteReceived) {

        if (byteReceived == null)
            return;
        if (byteReceived.Length == 8) {

            int index = BitConverter.ToInt32(byteReceived, 0);
            int value = BitConverter.ToInt32(byteReceived, 4);
            m_onIndexValueIntegerReceived.Invoke(index, value);
            m_lastReceivedIndex = index;
            m_lastReceivedValue = value;
        }
    }
}
