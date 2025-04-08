using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    private TowerAttackEvent towerAttackEvent;
    private Tower tower;


    private void Awake()
    {
        towerAttackEvent = GetComponent<TowerAttackEvent>();
    }
    private void OnEnable()
    {
        towerAttackEvent.OnTowerAttack += TowerAttackEvent_OnTowerAttack;
    }
    private void OnDisable()
    {
        towerAttackEvent.OnTowerAttack -= TowerAttackEvent_OnTowerAttack;
    }



    private void TowerAttackEvent_OnTowerAttack(TowerAttackEvent arg1, TowerAttackEventArgs args)
    {
        tower = args.tower;
        OnWeaponAttack(args);
    }

    private void OnWeaponAttack(TowerAttackEventArgs weaponAttackEventArgs)
    {
        // ���ݼӵ�(��Ÿ��) �����Ҷ� ���� �õ�
        if (tower.TowerFireRateTimer > 0f)
            return;

        tower.TowerAttackType.TowerAttack(tower);
    }
}
