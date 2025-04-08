using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Monster : MonoBehaviour
{
    private MonsterDetailsSO enemyDetails;
    private CapsuleCollider hitbox;
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private PlayerCtrl player;
    private GameObject monsterHitEffect;
    private GameObject monsterDestroyedEffect;

    private float hp;

    #region MONSTER EVENT
    private MonsterDestroyedEvent monsterDestroyedEvent;
    #endregion

    public PlayerCtrl Player => player;
    public MonsterDetailsSO EnemyDetails => enemyDetails;
    public MonsterDestroyedEvent MonsterDestroyedEvent => monsterDestroyedEvent;
    public Animator Animator => animator;
    public EPool MonsterType { get; private set; }


    private void Awake()
    {
        hitbox = GetComponent<CapsuleCollider>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        monsterDestroyedEvent = GetComponent<MonsterDestroyedEvent>();
    }
    private void Start()
    {
        //hitSoundEffect = AddressableManager.Instance.GetResource<SoundEffectSO>("SoundEffect_Hit");
    }

    public void InitializeMonster(MonsterDetailsSO data)
    {
        enemyDetails = data;

        player = GameManager.Instance.Player;
        hp = data.hp;
        MonsterType = data.monsterType;
        hitbox.enabled = true;
        monsterHitEffect = data.monsterHitEffect;
        monsterDestroyedEffect = data.monsterDestroyedEffect;

        navMeshAgent.enabled = true;
        navMeshAgent.Warp(transform.position);
        navMeshAgent.speed = data.speed;
        navMeshAgent.SetDestination(player.transform.position);
    }
     
    public void TakeDamage(Tower tower) // '무기'에 의해 피해를 입을때
    {
        SoundEffectManager.Instance.PlaySoundEffect(ESoundEffectType.MonsterHit);

        hp -= tower.TowerDamage;

        if (hp <= 0f) // 최초로 체력이 0 이하로 떨어질 경우
        {
            navMeshAgent.enabled = false;
            player.PlayerData.Gold += enemyDetails.gold;
            Instantiate(monsterDestroyedEffect, transform.position, Quaternion.identity);
            hitbox.enabled = false; // 충돌체 끄기
            monsterDestroyedEvent.CallMonsterDestroyedEvent();

            return;
        }

        Instantiate(monsterHitEffect, transform.position, Quaternion.identity);
    }
}
