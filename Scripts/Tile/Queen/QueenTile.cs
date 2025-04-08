using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenTile : ChessTile
{
    [SerializeField] private GameObject tileEffect;


    public override void ApplyTowerSynergy(Tower tower)
    {
        Instantiate(tileEffect, transform);

        tower.TowerUpgrade(ETowerStatType.TowerDamage, Settings.queenTileValue);
        tower.TowerUpgrade(ETowerStatType.TowerFireRate, Settings.queenTileValue);
    }
}
