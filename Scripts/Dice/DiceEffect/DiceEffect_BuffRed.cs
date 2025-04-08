using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(fileName = "DiceEffect_BuffRed", menuName = "Scriptable Objects/Dice/DiceEffectBuffRed")]
public class DiceEffect_BuffRed : DiceEffect
{
    public override void ApplyDiceEffect(int num)
    {
        if (num < 3) // 1,2,3 => ³ÊÇÁ
        {
            player.BuffAllTower(-15f);
        }
        else 
        {
            SoundEffectManager.Instance.PlaySoundEffect(ESoundEffectType.BuffTower);

            player.BuffAllTower(20f);
        }
    }
}
