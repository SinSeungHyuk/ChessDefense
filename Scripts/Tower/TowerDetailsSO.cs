using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Tower_", menuName = "Scriptable Objects/Tower/Tower")]
public class TowerDetailsSO : IdentifiedObject
{
    public string towerName;
    [TextArea] public string towerDesc;

    public Mesh towerMesh;
    public Material towerMaterial;

    public float damage;
    public float fireRate;
    public TowerAttackType towerAttackType;
    public ETowerType towerType;
}
