using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DiceEffect_White", menuName = "Scriptable Objects/Dice/DiceEffectWhite")]
public class DiceEffect_White : DiceEffect
{
    public override void ApplyDiceEffect(int num)
    {
        if (num == 5)
        {
            num = Random.Range(0, 5);
        }

        TowerDetailsSO towerData = DB_Tower.GetDataByID<TowerDetailsSO>(num);

        player.SetPlayerAdvancedMode(towerData);
    }
}
