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
    public int m_intKeyArrowUp = 1331;
    public int m_intKeyArrowRight = 1333;
    public int m_intKeyArrowLeft = 1337;
    public int m_intKeyArrowDown = 1335;
    public int m_intKeyMenuLeft = 1309;
    public int m_intKeyMenuRight = 1308;
    public int m_intKeyButtonA = 1300;
    public int m_intKeyButtonB = 1301;


    public UnityEvent<Vector2> m_onArrowUpdated;
    public UnityEvent<bool> m_onArrowLeftPressed;
    public UnityEvent<bool> m_onArrowRightPressed;
    public UnityEvent<bool> m_onArrowUpPressed;
    public UnityEvent<bool> m_onArrowDownPressed;
    public UnityEvent<bool> m_onMenuLeftPressed;
    public UnityEvent<bool> m_onMenuRightPressed;
    public UnityEvent<bool> m_onButtonAPressed;
    public UnityEvent<bool> m_onButtonBPressed;

    public void PushInIntegerToEvent(int value)
    {
        if (value == m_intKeyArrowLeft)
            m_onArrowLeftPressed?.Invoke(true);
        else if (value == m_intKeyArrowLeft + 1000)
            m_onArrowLeftPressed?.Invoke(false);
        else if (value == m_intKeyArrowRight)
            m_onArrowRightPressed?.Invoke(true);
        else if (value == m_intKeyArrowRight + 1000)
            m_onArrowRightPressed?.Invoke(false);
        else if (value == m_intKeyArrowUp)
            m_onArrowUpPressed?.Invoke(true);
        else if (value == m_intKeyArrowUp + 1000)
            m_onArrowUpPressed?.Invoke(false);
        else if (value == m_intKeyArrowDown)
            m_onArrowDownPressed?.Invoke(true);
        else if (value == m_intKeyArrowDown + 1000)
            m_onArrowDownPressed?.Invoke(false);
        else if (value == m_intKeyMenuLeft)
            m_onMenuLeftPressed?.Invoke(true);
        else if (value == m_intKeyMenuLeft + 1000)
            m_onMenuLeftPressed?.Invoke(false);
        else if (value == m_intKeyMenuRight)
            m_onMenuRightPressed?.Invoke(true);
        else if (value == m_intKeyMenuRight + 1000)
            m_onMenuRightPressed?.Invoke(false);
        else if (value == m_intKeyButtonA)
            m_onButtonAPressed?.Invoke(true);
        else if (value == m_intKeyButtonA + 1000)
            m_onButtonAPressed?.Invoke(false);
        else if (value == m_intKeyButtonB)
            m_onButtonBPressed?.Invoke(true);
        else if (value == m_intKeyButtonB + 1000)
            m_onButtonBPressed?.Invoke(false);

        if (value == m_intKeyArrowLeft)
        {
            m_arrowState.x = -1;
            NotifyArrowUpdated();
        }
        else if (value == m_intKeyArrowRight)
        {
            m_arrowState.x = 1;
            NotifyArrowUpdated();
        }
        else if (value == m_intKeyArrowUp)
        {
            m_arrowState.y = 1;
            NotifyArrowUpdated();
        }
        else if (value == m_intKeyArrowDown)
        {
            m_arrowState.y = -1;
            NotifyArrowUpdated();
        }
        else if (value == m_intKeyArrowLeft + 1000 || value == m_intKeyArrowRight + 1000)
        {
            m_arrowState.x = 0;
            NotifyArrowUpdated();
        }
        else if (value == m_intKeyArrowUp + 1000 || value == m_intKeyArrowDown + 1000)
        {
            m_arrowState.y = 0;
            NotifyArrowUpdated();
        }

        if (value == m_intKeyMenuLeft)
            m_menuLeftState = true;
        else if (value == m_intKeyMenuLeft + 1000)
            m_menuLeftState = false;

        if (value == m_intKeyMenuRight)
            m_menuRightState = true;
        else if (value == m_intKeyMenuRight + 1000)
            m_menuRightState = false;

        if (value == m_intKeyButtonA)
            m_buttonAState = true;
        else if (value == m_intKeyButtonA + 1000)
            m_buttonAState = false;

        if (value == m_intKeyButtonB)
            m_buttonBState = true;
        else if (value == m_intKeyButtonB + 1000)
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
