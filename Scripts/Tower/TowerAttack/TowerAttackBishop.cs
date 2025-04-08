using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TowerAttackBishop", menuName = "Scriptable Objects/Tower/TowerAttackBishop")]
public class TowerAttackBishop : TowerAttackType
{
    [SerializeField] private ProjectileData projectileData;


    public override void TowerAttack(Tower tower)
    {
        Vector3 rightVector = tower.transform.right;
        Quaternion rotationPos = Quaternion.AngleAxis(30f, Vector3.up);
        Quaternion rotationNeg = Quaternion.AngleAxis(-30f, Vector3.up);
        Vector3 rotatedVectorPos = rotationPos * rightVector;
        Vector3 rotatedVectorNeg = rotationNeg * rightVector;

        // 투사체 데이터SO랑 방향, 무기 정보 넣어서 초기화
        Vector3 projectilePos = new Vector3(tower.transform.position.x, tower.transform.position.y + 0.5f, tower.transform.position.z);
        GameObject projectileObjectPos = Instantiate(projectileData.projectile, projectilePos, Quaternion.identity);
        projectileObjectPos.GetComponent<Projectile>().InitializeProjectile(tower, projectileData, rotatedVectorPos);

        GameObject projectileObjectNeg = Instantiate(projectileData.projectile, projectilePos, Quaternion.identity);
        projectileObjectNeg.GetComponent<Projectile>().InitializeProjectile(tower, projectileData, rotatedVectorNeg);

        SoundEffectManager.Instance.PlaySoundEffect(ESoundEffectType.BishopAttack);

    }
}