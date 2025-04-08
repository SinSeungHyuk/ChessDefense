using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCtrl : MonoBehaviour
{
    public event Action<TowerDetailsSO> OnPlayerAdvancedMode;
    public event Action<TowerDetailsSO> OnPlayerAdvancedModeFinish;

    private bool isAdvancedMode; // Ÿ�� ��ġ���
    private bool isDiceRollingMode; // �ֻ��� ������ �ִ���
    private Vector3 clickPos;
    private DiceCtrl diceCtrl;
    private PlayerData playerData;
    private SphereCollider hitbox;


    public PlayerData PlayerData => playerData;
    public bool IsAdvancedMode => isAdvancedMode;
    public bool IsDiceRollingMode => isDiceRollingMode;
    public TowerDetailsSO CurrentTowerData {  get; private set; }


    private void Awake()
    {
        diceCtrl = GetComponent<DiceCtrl>();
        hitbox = GetComponent<SphereCollider>();
        playerData = new PlayerData();
    }

    private void Update()
    {
        MouseMovement();
    }


    public void PlayerRollDice(DiceDetailsSO diceData)
    {
        isDiceRollingMode = true;
        diceCtrl.DiceRoll(diceData);
    }

    public void SetPlayerAdvancedMode(TowerDetailsSO towerData)
    {
        isAdvancedMode = true;
        CurrentTowerData = towerData;

        OnPlayerAdvancedMode?.Invoke(towerData);

        GameManager.Instance.UIController.ActivateBtnCancel(true);
        //Time.timeScale = 0.25f;
    }

    public void BuffAllTower(float value)
    {
        isDiceRollingMode = false;

        var tiles = GameManager.Instance.CurrentStage.Tiles;
        tiles = tiles.Where(tile => tile.IsTowerPlaced == true).ToList();

        foreach (var tile in tiles)
        {
            tile.Tower.TowerUpgrade(ETowerStatType.TowerDamage, value);
            tile.Tower.TowerUpgrade(ETowerStatType.TowerFireRate, value);
        }
    }

    public void FinishPlacingTower()
    {
        OnPlayerAdvancedModeFinish?.Invoke(CurrentTowerData);        

        isAdvancedMode = false;
        isDiceRollingMode = false;
        CurrentTowerData = null;

        GameManager.Instance.UIController.ActivateBtnCancel(false);
        //Time.timeScale = 1f;
    }

    public void RefundTower()
    {
        playerData.Gold += Settings.RefundTowerGold;
        FinishPlacingTower();
    }

    private void MouseMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            // �巡�׵� ���� Viewport �������� ��ȯ
            Vector3 movePos = Camera.main.ScreenToViewportPoint(clickPos - Input.mousePosition);
            // movePos.x �� ���� X�� �̵�, movePos.y �� ���� Z�� �̵�
            // Y���� ����
            float xDelta = movePos.x;
            float zDelta = movePos.y;

            Camera.main.transform.position = new Vector3(
               Camera.main.transform.position.x + xDelta,
               Camera.main.transform.position.y, // Y���� ����
               Camera.main.transform.position.z + zDelta
            );
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if ((1 <<  other.gameObject.layer) == Settings.MonsterLayer )
        {
            hitbox.enabled = false;
            GameManager.Instance.GameOver();
        }
    }
}
