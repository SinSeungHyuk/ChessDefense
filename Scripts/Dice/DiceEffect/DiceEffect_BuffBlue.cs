using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(fileName = "DiceEffect_BuffBlue", menuName = "Scriptable Objects/Dice/DiceEffectBuffBlue")]
public class DiceEffect_BuffBlue : DiceEffect
{
    public override void ApplyDiceEffect(int num)
    {
        SoundEffectManager.Instance.PlaySoundEffect(ESoundEffectType.BuffTower);

        if (num < 3) // 1,2,3 => 약한 버프
        {
            player.BuffAllTower(5f);
        }
        else if (num < 5)
        {
            player.BuffAllTower(10f);
        }
        else
        {
            player.BuffAllTower(20f);
        }
    }
}
