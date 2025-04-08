using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TowerAttackPawn", menuName = "Scriptable Objects/Tower/TowerAttackPawn")]
public class TowerAttackPawn : TowerAttackType
{
    [SerializeField] private GameObject attackEffect;


    public override void TowerAttack(Tower tower)
    {
        // ������Ʈ ���� �������� x�� 1��ŭ ������ ������ (���� ��ǥ)
        Vector3 localOffset = Vector3.right * 1f;
        // ������Ʈ�� ȸ������ �� ���� �����µ� ���� ȸ���ǵ��� transform.rotation�� ������
        Vector3 rotatedOffset = tower.transform.rotation * localOffset;
        // ���� ��ġ = ������Ʈ�� ���� ��ġ + ȸ�� ����� ������
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
