using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceUIController : MonoBehaviour
{
    [SerializeField] private DiceView diceView;


    public void InitializeDiceUIController()
    {
        diceView.InitializeDiceView();
    }
}
