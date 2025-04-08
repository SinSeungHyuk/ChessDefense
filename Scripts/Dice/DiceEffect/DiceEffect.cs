using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class DiceEffect : ScriptableObject
{
    [HideInInspector] public PlayerCtrl player;
    [HideInInspector] public Database DB_Tower;

    public abstract void ApplyDiceEffect(int num);
}
