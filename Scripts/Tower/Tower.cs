using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private MeshFilter mesh;
    private MeshRenderer meshRenderer;
    private TowerAttackEvent towerAttackEvent;

    public TowerDetailsSO TowerData {  get; private set; }
    public ETowerType TowerType {  get; private set; }
    public TowerAttackType TowerAttackType { get; private set; }
    public float TowerDamage { get; private set; } // ������
    public float TowerFireRate { get; private set; } // ���ݼӵ�
    public float TowerFireRateTimer { get; private set; } // ���� ���ݱ��� ���� �ð�


    private void Awake()
    {
        mesh = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        towerAttackEvent = GetComponent<TowerAttackEvent>();
    }

    private void Update()
    {
        // ����ӵ� 
        if (TowerFireRateTimer > 0f)
            TowerFireRateTimer -= Time.deltaTime;
        else
        {
            towerAttackEvent.CallTowerAttackEvent(this);
            TowerFireRateTimer = TowerFireRate;
        }
    }

    public void InitializeTower(TowerDetailsSO towerData) // Ÿ�� �ʱ�ȭ
    {
        mesh.mesh = towerData.towerMesh;
        meshRenderer.material = towerData.towerMaterial;

        TowerData = towerData;
        TowerType = towerData.towerType;
        TowerAttackType = towerData.towerAttackType;
        TowerDamage = towerData.damage;
        TowerFireRate = towerData.fireRate;
    }

    public void TowerUpgrade(ETowerStatType type, float value)
    {
        switch (type)
        {
            case ETowerStatType.TowerDamage:
                TowerDamage = UtilitieHelper.IncreaseByPercent(TowerDamage, value);
                break;
            case ETowerStatType.TowerFireRate:
                TowerFireRate = UtilitieHelper.DecreaseByPercent(TowerFireRate, value);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
