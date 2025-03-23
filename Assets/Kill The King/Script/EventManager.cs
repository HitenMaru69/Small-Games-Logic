using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public event EventHandler KillKingEvent;

    private void Awake()
    {
        Instance = this;
    }

    public void InvokeKillKingEvent()
    {
        KillKingEvent?.Invoke(this,EventArgs.Empty);
    }

}
