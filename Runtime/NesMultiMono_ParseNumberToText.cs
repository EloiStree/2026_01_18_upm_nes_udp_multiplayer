using UnityEngine;
using UnityEngine.Events;

public class NesMultiMono_ParseNumberToText : MonoBehaviour
{
    public UnityEvent<string> m_onTextUpdated;
    public string format= "{0}";

    public void PushIn(int number)
    {
        string text = string.Format(format, number);
        m_onTextUpdated?.Invoke(text);
    }
}
