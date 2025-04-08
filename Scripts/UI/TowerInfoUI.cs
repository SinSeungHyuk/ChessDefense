using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerInfoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtTowerName;
    [SerializeField] private TextMeshProUGUI txtTowerDamage;
    [SerializeField] private TextMeshProUGUI txtTowerFireRate;


    public void InitializeTowerInfoUI(Tower tower, bool isActive)
    {
        gameObject.SetActive(isActive);

        transform.position = Input.mousePosition;

        txtTowerName.text = tower.TowerData.towerDesc;
        txtTowerDamage.text = tower.TowerDamage.ToString("F2");
        txtTowerFireRate.text = tower.TowerFireRate.ToString("F2");
    }
}
