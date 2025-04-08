using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtWaveCount;
    [SerializeField] private TextMeshProUGUI txtWaveTimer;
    [SerializeField] private TextMeshProUGUI txtNextWaveCount;
    [SerializeField] private CanvasGroup NextWaveCountCanvas;


    public void InitializeWaveView()
    {
        GameManager.Instance.CurrentStage.Spawner.OnElapsedTimeChanged += Spawner_OnElapsedTimeChanged;
        GameManager.Instance.CurrentStage.Spawner.OnWaveStart += Spawner_OnWaveStart;
    }

    private void Spawner_OnWaveStart(Spawner arg1, int waveCount)
    {
        txtWaveTimer.text = Settings.waveTimer.ToString();
        txtWaveCount.text = "Wave " + (waveCount+1);
        txtNextWaveCount.text = "Wave " + (waveCount+1) + " Start";

        FadeNextWaveCountCanvasRoutine().Forget();
    }

    private void Spawner_OnElapsedTimeChanged(Spawner arg1, float time)
    {
        txtWaveTimer.text = time.ToString();
    }

    private async UniTask FadeNextWaveCountCanvasRoutine()
    {
        float elapsedTime = 0f;
        NextWaveCountCanvas.alpha = 0f;

        // 0.5초 동안 알파값 증가
        while (elapsedTime < 0.5f)
        {
            NextWaveCountCanvas.alpha = (elapsedTime * 2f);
            elapsedTime += Time.deltaTime;
            await UniTask.Yield();
        }

        // 1초 동안 유지
        await UniTask.Delay(1000);

        // 0.5초 동안 알파값 감소
        elapsedTime = 0f;
        while (elapsedTime < 0.5f)
        {
            NextWaveCountCanvas.alpha = 1f - (elapsedTime * 2f);
            elapsedTime += Time.deltaTime;
            await UniTask.Yield();
        }

        NextWaveCountCanvas.alpha = 0f;
    }
}
