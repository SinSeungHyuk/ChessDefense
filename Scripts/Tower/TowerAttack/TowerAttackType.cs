using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerAttackType : ScriptableObject
{
    public abstract void TowerAttack(Tower tower);
}
