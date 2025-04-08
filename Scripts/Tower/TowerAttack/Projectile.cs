using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rigid;
    private Tower tower;

    private float speed;

    private float distance;
    private float currentDistance;
    private Vector3 direction;
    private Vector3 distanceVector;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // FixedUpdate���� ������ �������� ������ ���� speed��ŭ �̵�
        distanceVector = direction * speed;
        currentDistance += distanceVector.sqrMagnitude; // ���ư� �Ÿ������ ���� magnitude
        rigid.velocity = distanceVector;

        if (currentDistance > distance)
            Destroy(gameObject);
    }

    public void InitializeProjectile(Tower tower, ProjectileData projectileData, Vector3 dir)
    {
        this.speed = projectileData.projectileSpeed;
        this.direction = dir; // ����ü ���⺤��
        this.tower = tower;
        distance = projectileData.projectileRange;
        currentDistance = 0f;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Monster monster))
        {
            monster.TakeDamage(tower);
        }
    }
}
