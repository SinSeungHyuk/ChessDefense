using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button btnCancel;
    [SerializeField] private TowerInfoUI towerInfoUI;
    [SerializeField] private GameObject gameUIs;

    private DiceUIController diceUIController;
    private WaveUIController waveUIController;
    private GoldUIController goldUIController;
    private PlacedTowerUIController placedTowerUIController;
    private GameEndUIController gameEndUIController;
    private PauseUIController pauseUIController;

    private PlayerCtrl player;

    public GameObject GameUIs => gameUIs;


    private void Awake()
    {
        diceUIController = GetComponent<DiceUIController>();
        waveUIController = GetComponent<WaveUIController>();
        goldUIController = GetComponent<GoldUIController>();
        placedTowerUIController = GetComponent<PlacedTowerUIController>();
        gameEndUIController = GetComponent<GameEndUIController>();
        pauseUIController = GetComponent<PauseUIController>();

        btnCancel.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pauseUIController.InitializePauseUIController();
        }
    }

    public void InitializeUIController()
    {
        player = GameManager.Instance.Player;

        diceUIController.InitializeDiceUIController();
        waveUIController.InitializeWaveUIController();
        goldUIController.InitializeGoldUIController();
        placedTowerUIController.InitializePlacedTowerUIController();

        btnCancel.onClick.AddListener(OnBtnCancel);
    }

    public void GameEnd(bool isWon)
    {
        gameEndUIController.InitializeGameEndUIController(isWon);
    }

    public void ActivateBtnCancel(bool isActive)
    {
        btnCancel.gameObject.SetActive(isActive);
    }

    public void ActivateTowerInfoUI(Tower tower, bool isActive)
    {
        towerInfoUI.InitializeTowerInfoUI(tower , isActive);
    }

    private void OnBtnCancel()
    {
        player.RefundTower();
    }
}
