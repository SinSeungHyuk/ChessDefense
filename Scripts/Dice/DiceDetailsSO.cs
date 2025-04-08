using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DiceDetails_", menuName = "Scriptable Objects/Dice/Dice")]
public class DiceDetailsSO : ScriptableObject
{
    public string diceName;
    [TextArea] public string diceDesc;

    public Material diceMaterial;
    public int diceCost;
    public DiceEffect diceEffect;
}
