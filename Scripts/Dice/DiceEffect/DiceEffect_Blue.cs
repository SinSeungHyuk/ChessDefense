using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DiceEffect_Blue", menuName = "Scriptable Objects/Dice/DiceEffectBlue")]
public class DiceEffect_Blue : DiceEffect
{
    public override void ApplyDiceEffect(int num)
    {
        if (num < 3)
            num = 0; // ´«±Ý 3 ÀÌÇÏ´Â Æù
        else if (num < 5)
            num = Random.Range(1, 4); // 4,5´Â ³ªÀÌÆ®,ºñ¼ó,·è ¼ÂÁß¿¡ ·£´ý
        else num = 4;

        TowerDetailsSO towerData = DB_Tower.GetDataByID<TowerDetailsSO>(num);

        player.SetPlayerAdvancedMode(towerData);
    }
}
