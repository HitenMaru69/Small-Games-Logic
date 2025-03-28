using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public event EventHandler KillKingEvent;
    public event EventHandler DieKingEvent;
    public event EventHandler CatchKillerEvent;
    private void Awake()
    {
        Instance = this;
    }

    public void InvokeKillKingEvent()
    {
        KillKingEvent?.Invoke(this,EventArgs.Empty);
    }

    public void InvokeDieKingEvent()
    {
        DieKingEvent?.Invoke(this,EventArgs.Empty);
    }

    public void InvokeCatchKillerEvent() 
    {
        CatchKillerEvent?.Invoke(this,EventArgs.Empty);
    }


}
