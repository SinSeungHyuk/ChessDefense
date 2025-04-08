using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceView : MonoBehaviour
{
    [SerializeField] private List<BtnDice> btnDiceList = new List<BtnDice>();


    public void InitializeDiceView()
    {
        foreach (var btnDice in btnDiceList)
        {
            btnDice.InitializeBtnDice();
        }
    }
}
