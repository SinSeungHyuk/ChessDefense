using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;


public class GameManager : Singleton<GameManager>
{
    [SerializeField] private PlayerCtrl player;
    [SerializeField] private UIController uiController;
    [SerializeField] private Stage stage;
    [SerializeField] private MusicTrackSO bgm;


    public PlayerCtrl Player => player;
    public UIController UIController => uiController;
    public Stage CurrentStage => stage;


    private void Start()
    {
        CreateMainGameScene();
    }

    private void CreateMainGameScene()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                Time.timeScale = 1f;
                break;
            case 2:
                Time.timeScale = 1.5f;
                break;
        }

        uiController.InitializeUIController();
        stage.InitializeStage(player);

        MusicManager.Instance.PlayMusic(bgm);
    }


    public void GameOver()
    {
        GameEnd();

        Camera.main.transform.DOMove(Settings.gameOverCameraPos, 2f)
            .OnComplete(() => {
                uiController.GameEnd(false);
            });
    }

    public void GameWin()
    {
        GameEnd();

        Camera.main.transform.position = Settings.gameWinCameraPos;
        Camera.main.transform.DOMove(Settings.gameOverCameraPos, 8f)
            .OnComplete(() => {
                uiController.GameEnd(true);
            });
    }

    private void GameEnd()
    {
        uiController.GameUIs.SetActive(false);
        SoundEffectManager.Instance.PlaySoundEffect(ESoundEffectType.GameEnd);
        Camera.main.GetUniversalAdditionalCameraData().cameraStack.Clear();
    }
}
