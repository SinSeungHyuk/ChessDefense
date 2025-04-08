using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Monster_", menuName = "Scriptable Objects/Monster/Monster")]
public class MonsterDetailsSO : IdentifiedObject
{
    public float hp;
    public float speed = 3f;
    public float damage;

    public int gold; // 처치보상
    public EPool monsterType;

    public GameObject monsterHitEffect;
    public GameObject monsterDestroyedEffect;
}
