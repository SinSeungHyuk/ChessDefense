using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Stage : MonoBehaviour
{
    [SerializeField] private StageData stageData;
    [SerializeField] private Material originMat;
    [SerializeField] private Material synergyMat;
    [SerializeField] private Material baseMat;

    public Spawner Spawner { get; private set; }
    public List<ChessTile> Tiles => stageData.Tiles;


    private void Awake()
    {
        Spawner = GetComponentInChildren<Spawner>();
    }

    public void InitializeStage(PlayerCtrl player)
    {
        player.OnPlayerAdvancedMode += Player_OnPlayerAdvancedMode;
        player.OnPlayerAdvancedModeFinish += Player_OnPlayerAdvancedModeFinish;

        Spawner.InitializeSpawner(stageData);
    }

    private void Player_OnPlayerAdvancedMode(TowerDetailsSO towerData)
    {
        foreach (var tile in stageData.Tiles)
        {
            if (tile.IsTowerPlaced == true)
                continue;

            if (tile.TileType == towerData.towerType)
                tile.ChangeMaterial(synergyMat);
            else 
                tile.ChangeMaterial(baseMat);
        }
    }

    private void Player_OnPlayerAdvancedModeFinish(TowerDetailsSO towerData)
    {
        foreach (var tile in stageData.Tiles)
        {
            tile.ChangeMaterial(originMat);
        }
    }
}
