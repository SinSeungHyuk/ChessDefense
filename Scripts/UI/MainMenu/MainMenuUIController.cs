using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnHowToPlay;
    [SerializeField] private Button btnExit;
    [SerializeField] private Button btnExitHowToPlay;
    [SerializeField] private Button btnExitPlay;
    [SerializeField] private Button btnPlayDay;
    [SerializeField] private Button btnPlayNightmare;
    [SerializeField] private GameObject stageView;
    [SerializeField] private GameObject howToPlayView;

    [SerializeField] private MusicTrackSO bgm;


    private void Start()
    {
        btnPlay.onClick.AddListener(OnBtnPlay);
        btnHowToPlay.onClick.AddListener(OnBtnHowToPlay);
        btnExit.onClick.AddListener(OnBtnExit);
        btnExitHowToPlay.onClick.AddListener(OnBtnExitHowToPlay);
        btnExitPlay.onClick.AddListener(OnBtnExitPlay);
        btnPlayDay.onClick.AddListener(OnBtnPlayDay);
        btnPlayNightmare.onClick.AddListener(OnBtnPlayNightmare);

        MusicManager.Instance.PlayMusic(bgm);
    }

    private void OnBtnPlay()
    {
        stageView.gameObject.SetActive(true);
    }

    private void OnBtnHowToPlay()
    {
        howToPlayView.gameObject.SetActive(true);
    }

    private void OnBtnExitPlay()
    {
        stageView.gameObject.SetActive(false);
    }

    private void OnBtnExitHowToPlay()
    {
        howToPlayView.gameObject.SetActive(false);
    }

    private void OnBtnPlayDay()
    {
        SceneManager.LoadScene(1);
    }

    private void OnBtnPlayNightmare()
    {
        SceneManager.LoadScene(2);
    }

    private void OnBtnExit()
    {
        Application.Quit();
    }
}
