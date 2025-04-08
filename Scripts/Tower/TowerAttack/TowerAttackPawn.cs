using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TowerAttackPawn", menuName = "Scriptable Objects/Tower/TowerAttackPawn")]
public class TowerAttackPawn : TowerAttackType
{
    [SerializeField] private GameObject attackEffect;


    public override void TowerAttack(Tower tower)
    {
        // 오브젝트 로컬 기준으로 x축 1만큼 떨어진 오프셋 (로컬 좌표)
        Vector3 localOffset = Vector3.right * 1f;
        // 오브젝트가 회전했을 때 로컬 오프셋도 같이 회전되도록 transform.rotation을 곱해줌
        Vector3 rotatedOffset = tower.transform.rotation * localOffset;
        // 월드 위치 = 오브젝트의 월드 위치 + 회전 적용된 오프셋
        Vector3 finalPosition = tower.transform.position + rotatedOffset;

        var hits = Physics.OverlapSphere(finalPosition, 1.5f, Settings.MonsterLayer);
        foreach (var hit in hits)
        {
            hit.GetComponent<Monster>().TakeDamage(tower);
        }

        Vector3 towerRotation = tower.transform.rotation.eulerAngles;
        Quaternion effectRot = Quaternion.Euler(0f, towerRotation.y + 90f, 0f);
        Vector3 effectPos = new Vector3(tower.transform.position.x, tower.transform.position.y + 0.5f, tower.transform.position.z);

        Instantiate(attackEffect, effectPos, effectRot);

        SoundEffectManager.Instance.PlaySoundEffect(ESoundEffectType.PawnAttack);

    }
}
