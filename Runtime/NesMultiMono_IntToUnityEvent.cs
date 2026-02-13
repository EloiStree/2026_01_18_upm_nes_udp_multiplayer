using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class NesMultiMono_IntToUnityEvent : MonoBehaviour
{

    public Vector2 m_arrowState;
    public bool m_menuLeftState;
    public bool m_menuRightState;
    public bool m_buttonAState;
    public bool m_buttonBState;


    //Menu Left 1309 2309
    //Menu Right 1308 2308
    //Up Arrow 1331 2331
    //Down Arrow 1335 2335
    //Left Arrow 1337 2337
    //Right Arrow 1333 2333
    //A button 1300 2300
    //B button 1301 2301


    public int[] m_intKeyArrowUp =new int[] { 1331, 1311 , 1341, 1352,1356};
    public int[] m_intKeyArrowRight = new int[] { 1333, 1313,1343 ,1350,1354 }; 
    public int[] m_intKeyArrowLeft = new int[] { 1337,1317,1347 ,1351,1355 };
    public int[] m_intKeyArrowDown = new int[] { 1335 ,1315,1345,1353,1357};
    public int[] m_intKeyMenuLeft = new int[] { 1309 };
    public int[] m_intKeyMenuRight = new int[] { 1308 };
    public int[] m_intKeyButtonA = new int[] { 1300 };
    public int[] m_intKeyButtonB = new int[] { 1302,1301,1303 };    


    public UnityEvent<Vector2> m_onArrowUpdated;
    public UnityEvent<bool> m_onArrowLeftPressed;
    public UnityEvent<bool> m_onArrowRightPressed;
    public UnityEvent<bool> m_onArrowUpPressed;
    public UnityEvent<bool> m_onArrowDownPressed;
    public UnityEvent<bool> m_onMenuLeftPressed;
    public UnityEvent<bool> m_onMenuRightPressed;
    public UnityEvent<bool> m_onButtonAPressed;
    public UnityEvent<bool> m_onButtonBPressed;

    public bool IsInCommandPress(in int value, in int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (value == array[i])
            {
                return true;
            }
        }
        return false;
    }
    public bool IsInCommandRelease(in int value, in int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (value == array[i]+1000)
            {
                return true;
            }
        }
        return false;
    }

    public void PushInIntegerToEvent(int value)
    {
        if (IsInCommandPress(value, m_intKeyArrowLeft))
            m_onArrowLeftPressed?.Invoke(true);
        else if (IsInCommandRelease(value, m_intKeyArrowLeft))
            m_onArrowLeftPressed?.Invoke(false);
        else if (IsInCommandPress(value, m_intKeyArrowRight))
            m_onArrowRightPressed?.Invoke(true);
        else if (IsInCommandRelease(value, m_intKeyArrowRight))
            m_onArrowRightPressed?.Invoke(false);
        else if (IsInCommandPress(value, m_intKeyArrowUp))
            m_onArrowUpPressed?.Invoke(true);
        else if (IsInCommandRelease(value, m_intKeyArrowUp))
            m_onArrowUpPressed?.Invoke(false);
        else if (IsInCommandPress(value, m_intKeyArrowDown))
            m_onArrowDownPressed?.Invoke(true);
        else if (IsInCommandRelease(value, m_intKeyArrowDown))
            m_onArrowDownPressed?.Invoke(false);
        else if (IsInCommandPress(value, m_intKeyMenuLeft))
            m_onMenuLeftPressed?.Invoke(true);
        else if (IsInCommandRelease(value, m_intKeyMenuLeft))
            m_onMenuLeftPressed?.Invoke(false);
        else if (IsInCommandPress(value, m_intKeyMenuRight))
            m_onMenuRightPressed?.Invoke(true);
        else if (IsInCommandRelease(value, m_intKeyMenuRight))
            m_onMenuRightPressed?.Invoke(false);
        else if (IsInCommandPress(value, m_intKeyButtonA))
            m_onButtonAPressed?.Invoke(true);
        else if (IsInCommandRelease(value, m_intKeyButtonA))
            m_onButtonAPressed?.Invoke(false);
        else if (IsInCommandPress(value, m_intKeyButtonB))
            m_onButtonBPressed?.Invoke(true);
        else if (IsInCommandRelease(value, m_intKeyButtonB))
            m_onButtonBPressed?.Invoke(false);

        if (IsInCommandPress(value, m_intKeyArrowLeft))
        {
            m_arrowState.x = -1;
            NotifyArrowUpdated();
        }
        else if (IsInCommandPress(value, m_intKeyArrowRight))
        {
            m_arrowState.x = 1;
            NotifyArrowUpdated();
        }
        else if (IsInCommandPress(value, m_intKeyArrowUp))
        {
            m_arrowState.y = 1;
            NotifyArrowUpdated();
        }
        else if (IsInCommandPress(value, m_intKeyArrowDown))
        {
            m_arrowState.y = -1;
            NotifyArrowUpdated();
        }
        else if (IsInCommandRelease(value, m_intKeyArrowLeft) || IsInCommandRelease(value, m_intKeyArrowRight))
        {
            m_arrowState.x = 0;
            NotifyArrowUpdated();
        }
        else if (IsInCommandRelease(value, m_intKeyArrowUp) || IsInCommandRelease(value, m_intKeyArrowDown))
        {
            m_arrowState.y = 0;
            NotifyArrowUpdated();
        }

        if (IsInCommandPress(value, m_intKeyMenuLeft))
            m_menuLeftState = true;
        else if (IsInCommandRelease(value, m_intKeyMenuLeft))
            m_menuLeftState = false;

        if (IsInCommandPress(value, m_intKeyMenuRight))
            m_menuRightState = true;
        else if (IsInCommandRelease(value, m_intKeyMenuRight))
            m_menuRightState = false;

        if (IsInCommandPress(value, m_intKeyButtonA))
            m_buttonAState = true;
        else if (IsInCommandRelease(value, m_intKeyButtonA))
            m_buttonAState = false;

        if (IsInCommandPress(value, m_intKeyButtonB))
            m_buttonBState = true;
        else if (IsInCommandRelease(value, m_intKeyButtonB))
            m_buttonBState = false;

    }
    private void NotifyArrowUpdated()
    {
        m_onArrowUpdated?.Invoke(m_arrowState);
    }

    public void GetPlayerArrowState(out Vector2 arrowState)
    {
        arrowState = m_arrowState;
    }
    public void GetPlayerMenuLeftState(out bool menuLeftState)
    {
        menuLeftState = m_menuLeftState;
    }
    public void GetPlayerMenuRightState(out bool menuRightState)
    {
        menuRightState = m_menuRightState;
    }
    public void GetPlayerButtonAState(out bool buttonAState)
    {
        buttonAState = m_buttonAState;
    }
    public void GetPlayerButtonBState(out bool buttonBState)
    {
        buttonBState = m_buttonBState;
    }
}
