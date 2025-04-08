using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlacedTowerView : MonoBehaviour
{ 
    [SerializeField] private List<PlacedTowerUI> placedTowerUI = new List<PlacedTowerUI>();


    public void InitializePlacedTowerView()
    {
        GameManager.Instance.Player.PlayerData.OnTowerPlaced += PlayerData_OnTowerPlaced;
    }

    private void PlayerData_OnTowerPlaced(ETowerType type, int count)
    {
        placedTowerUI.FirstOrDefault(placedTowerUI => placedTowerUI.towerType == type)
            .txtTowerCount.text = count.ToString();
    }
}

[Serializable] 
public struct PlacedTowerUI
{
    public ETowerType towerType;
    public TextMeshProUGUI txtTowerCount;
}