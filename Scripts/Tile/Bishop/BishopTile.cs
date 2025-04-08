using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopTile : ChessTile
{
    [SerializeField] private GameObject tileEffect;


    public override void ApplyTowerSynergy(Tower tower)
    {
        Instantiate(tileEffect, transform);

        tower.TowerUpgrade(ETowerStatType.TowerDamage, Settings.bishopTileValue);
        tower.TowerUpgrade(ETowerStatType.TowerFireRate, Settings.bishopTileValue);

    }
}
