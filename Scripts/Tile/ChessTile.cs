using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessTile : MonoBehaviour
{
    [SerializeField] private ETowerType tileType;
    private PlayerCtrl player;
    private TowerPreview towerPreview;
    private Tower tower;
    private Vector3 towerPos;
    private MeshRenderer meshRenderer;

    public ETowerType TileType => tileType;
    public bool IsTowerPlaced => tower != null;
    public Tower Tower => tower;


    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        player = GameManager.Instance.Player;
        towerPos = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
    }

    private void OnMouseUp()
    {
        if (player.IsAdvancedMode && IsTowerPlaced == false)
        {
            tower = ObjectPoolManager.Instance.Get(EPool.Tower, towerPos, towerPreview.transform.rotation).GetComponent<Tower>();
            tower.InitializeTower(player.CurrentTowerData);

            if (tower.TowerType == tileType)
            {    // 시너지가 발생하는 타일-타워일 경우
                ApplyTowerSynergy(tower);
                SoundEffectManager.Instance.PlaySoundEffect(ESoundEffectType.BuffTower);

            }

            ObjectPoolManager.Instance.Release(towerPreview.gameObject, EPool.TowerPreview);

            player.FinishPlacingTower();
            player.PlayerData.PlacingTower(tower.TowerType);
        }
    }

    private void OnMouseEnter()
    {
        if (player.IsAdvancedMode && IsTowerPlaced == false)
        {
            towerPreview = ObjectPoolManager.Instance.Get(EPool.TowerPreview, towerPos, Quaternion.Euler(Settings.towerOriginRotation)).GetComponent<TowerPreview>();
            towerPreview.InitializeTowerPreview(player.CurrentTowerData);
        }

        if (IsTowerPlaced == true)
        {       
            GameManager.Instance.UIController.ActivateTowerInfoUI(tower, true);
        }
    }

    private void OnMouseExit()
    {
        if (towerPreview != null)
        {
            ObjectPoolManager.Instance.Release(towerPreview.gameObject, EPool.TowerPreview);
        }

        if (IsTowerPlaced == true)
        {
            GameManager.Instance.UIController.ActivateTowerInfoUI(tower, false);
        }
    }

    public void ChangeMaterial(Material material)
    {
        meshRenderer.material = material;
    }

    public abstract void ApplyTowerSynergy(Tower tower);
}
