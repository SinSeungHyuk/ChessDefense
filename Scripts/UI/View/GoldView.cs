using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtGold;


    public void InitializeGoldView()
    {
        txtGold.text = Settings.DefaultGold + " G";

        GameManager.Instance.Player.PlayerData.OnGoldChanged += PlayerData_OnGoldChanged;
    }

    private void PlayerData_OnGoldChanged(int gold)
    {
        txtGold.text = gold.ToString("N0") + " G";
    }
}
