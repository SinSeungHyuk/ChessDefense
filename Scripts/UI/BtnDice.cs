using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BtnDice : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private DiceDetailsSO diceData;
    [SerializeField] private GameObject diceDescView;
    private Button btnDice;
    private GameObject currentDiceDescView;


    private void Awake()
    {
        btnDice = GetComponent<Button>();
    }

    public void InitializeBtnDice()
    {
        btnDice.onClick.AddListener(DiceRoll);
    }

    private void DiceRoll()
    {
        PlayerCtrl player = GameManager.Instance.Player;

        if (player.PlayerData.Gold >= diceData.diceCost && player.IsDiceRollingMode == false)
        {
            player.PlayerData.Gold -= diceData.diceCost;
            player.PlayerRollDice(diceData);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        currentDiceDescView = Instantiate(diceDescView, GameManager.Instance.UIController.transform);
        currentDiceDescView.transform.position = eventData.position;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(currentDiceDescView);
    }
}
