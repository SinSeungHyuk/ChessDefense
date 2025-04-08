using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DiceEffect_Red", menuName = "Scriptable Objects/Dice/DiceEffectRed")]
public class DiceEffect_Red : DiceEffect
{
    public override void ApplyDiceEffect(int num)
    {
        if (num < 2)
        {
            player.FinishPlacingTower();
            return; // ���� 2 ���ϴ� ��
        }
        else if (num > 3)
            player.PlayerData.Gold += 40;

        num = Random.Range(0, 5); // ���� �⹰


        TowerDetailsSO towerData = DB_Tower.GetDataByID<TowerDetailsSO>(num);

        player.SetPlayerAdvancedMode(towerData);
    }
}
