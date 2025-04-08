using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using System.Linq;
using Unity.Burst.CompilerServices;
using System;


[CreateAssetMenu(fileName = "TowerAttackQueen", menuName = "Scriptable Objects/Tower/TowerAttackQueen")]
public class TowerAttackQueen : TowerAttackType
{
    [SerializeField] private ProjectileData projectileData;
    private Tower tower;


    public override void TowerAttack(Tower tower)
    {
        this.tower = tower;

        // 투사체 데이터SO랑 방향, 무기 정보 넣어서 초기화
        Vector3 projectilePos = new Vector3(tower.transform.position.x, tower.transform.position.y + 1f, tower.transform.position.z);
        GameObject projectileObject = Instantiate(projectileData.projectile, projectilePos, Quaternion.identity);

        projectileObject.transform.DOScale(0.2f, tower.TowerFireRate)
            .OnComplete(() => DetectMonsterRoutine(projectileObject).Forget());
    }

    private async UniTask DetectMonsterRoutine(GameObject projectileObject)
    {
        Collider[] hits = Array.Empty<Collider>();

        while (hits.Length == 0)
        {
            hits = Physics.OverlapSphere(tower.transform.position, 6f, Settings.MonsterLayer);

            await UniTask.Delay(100);
        }

        FireProjectile(hits, projectileObject);
    }

    private void FireProjectile(Collider[] hits, GameObject projectileObject)
    {
        if (hits.Length > 0)
        {
            Collider target = hits
                .OrderBy(hit => (tower.transform.position - hit.transform.position).sqrMagnitude)
            .First();

            Vector3 dir = (target.transform.position - tower.transform.position).normalized;

            projectileObject.GetComponent<Projectile>().InitializeProjectile(tower, projectileData, dir);

            SoundEffectManager.Instance.PlaySoundEffect(ESoundEffectType.QueenAttack);

        }
    }
}
