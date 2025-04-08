using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackEvent : MonoBehaviour
{
    public event Action<TowerAttackEvent, TowerAttackEventArgs> OnTowerAttack;

    public void CallTowerAttackEvent(Tower tower)
    {
        OnTowerAttack?.Invoke(this, new TowerAttackEventArgs()
        {
            tower = tower,
        });
    }
}

public class TowerAttackEventArgs : EventArgs
{
    public Tower tower;
}