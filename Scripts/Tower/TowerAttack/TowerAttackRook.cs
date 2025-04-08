using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TowerAttackRook", menuName = "Scriptable Objects/Tower/TowerAttackRook")]
public class TowerAttackRook : TowerAttackType
{
    [SerializeField] private ProjectileData projectileData;



    public override void TowerAttack(Tower tower)
    {
        Vector3 towerRotation = tower.transform.rotation.eulerAngles;
        Quaternion newRotation = Quaternion.Euler(0f, towerRotation.y, 0f);

        // 투사체 데이터SO랑 방향, 무기 정보 넣어서 초기화
        Vector3 projectilePos = new Vector3(tower.transform.position.x, tower.transform.position.y + 0.5f, tower.transform.position.z);
        GameObject projectileObject = Instantiate(projectileData.projectile, projectilePos, newRotation);
        projectileObject.GetComponent<Projectile>().InitializeProjectile(tower, projectileData, tower.transform.right);

        SoundEffectManager.Instance.PlaySoundEffect(ESoundEffectType.RookAttack);

    }
}
