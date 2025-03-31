using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public event EventHandler KillKingEvent;
    public event EventHandler DieKingEvent;
    public event EventHandler CatchKillerEvent;
    public event EventHandler CheckEnemyTryToKill;
    public event EventHandler EnemyagainTryToKillEvent;
    public event EventHandler SpawnNewEnemyEvent;

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

    public void InvokeCheckEnemyTryToKill() 
    { 
        CheckEnemyTryToKill?.Invoke(this,EventArgs.Empty);
    }

    public void InvokeEnemyagainTryToKill() 
    {
        EnemyagainTryToKillEvent?.Invoke(this,EventArgs.Empty);
    }

    public void InvokeSpawnNewEnemyEvent()
    {
        SpawnNewEnemyEvent?.Invoke(this,EventArgs.Empty);
    }

}
