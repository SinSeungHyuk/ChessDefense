using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtGameResult;
    [SerializeField] private Button btnExit;
    [SerializeField] private CanvasGroup gameEndViewGroup;


    public void InitializeGameEndView(bool isWon)
    {
        string gameEndText = (isWon) ? "GAME WIN" : "GAME LOSE";

        txtGameResult.text = gameEndText;

        DOTween.To(() => 0f, value => gameEndViewGroup.alpha = value, 1f, 2f);

        btnExit.onClick.AddListener(() => SceneManager.LoadScene(0));
    }
}