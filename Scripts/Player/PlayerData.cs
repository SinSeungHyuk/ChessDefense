using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public event Action<int> OnGoldChanged;
    public event Action<ETowerType, int> OnTowerPlaced;

    private int gold;
    private Dictionary<ETowerType, int> placedTower = new Dictionary<ETowerType, int>();

    public int Gold { 
        get { return gold; }
        set
        {
            gold = value;
            OnGoldChanged?.Invoke(Gold);
        }
    }
    public IReadOnlyDictionary<ETowerType, int> PlacedTower => placedTower;

    public PlayerData()
    {
        gold = Settings.DefaultGold;

        foreach (ETowerType type in Enum.GetValues(typeof(ETowerType)))
        {
            placedTower[type] = 0;  // 각 enum 값에 대해 0으로 초기화
        }
    }

    public void PlacingTower(ETowerType type)
    {
        placedTower[type]++;
        OnTowerPlaced?.Invoke(type, placedTower[type]);
    }
}
