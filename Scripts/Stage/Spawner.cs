using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public event Action<Spawner, int> OnWaveStart;
    public event Action<Spawner, int> OnWaveFinish;
    public event Action<Spawner, float> OnElapsedTimeChanged; // 웨이브 경과시간

    private List<WaveSpawnParameter> waveSpawnParameterList; // 각 웨이브별 스폰정보
    private WaveSpawnParameter currentWaveSpawnParameter; // 현재 웨이브 스폰정보
    private int waveCount;
    private int waveTimer;
    private float elapsedTime;
    private CancellationTokenSource cts;

    public int WaveCount => waveCount;
    public int WaveTimer => waveTimer;
    public float ElapsedTime => elapsedTime;


    private void OnEnable()
    {
        OnWaveStart += MonsterSpawnEvent_OnWaveStart;
        OnWaveFinish += MonsterSpawnEvent_OnWaveFinish;
    }
    private void OnDisable()
    {
        OnWaveStart -= MonsterSpawnEvent_OnWaveStart;
        OnWaveFinish -= MonsterSpawnEvent_OnWaveFinish;

        UniTaskCancel();
    }

    public void InitializeSpawner(StageData stageData)
    {
        waveSpawnParameterList = stageData.waveSpawnParameter;

        OnWaveStart?.Invoke(this, 0);
    }

    private void MonsterSpawnEvent_OnWaveStart(Spawner spawner, int waveCount)
    {
        // 웨이브카운트 (0부터 시작) == 웨이브 수 (1부터 시작) -> 마지막 웨이브까지 종료된 시점
        if (waveCount == waveSpawnParameterList.Count)
        {
            StageFinish();

            return;
        }

        // UI에서는 웨이브 카운트 + 1을 보여줘야함
        cts = new CancellationTokenSource();

        currentWaveSpawnParameter = waveSpawnParameterList[waveCount];

        elapsedTime = Settings.waveTimer; // 웨이브 기본시간으로 초기화
        WaveTimerRoutine().Forget();
        SpawnMonsterRoutine().Forget();
    }

    private void MonsterSpawnEvent_OnWaveFinish(Spawner spawner, int waveCount)
    {
        UniTaskCancel();

        this.waveCount++; // 웨이브가 종료되고 웨이브 카운트 증가
        OnWaveStart?.Invoke(this, this.waveCount); // 다음 웨이브 시작
    }

    private void StageFinish()
    {
        UniTaskCancel();

        GameManager.Instance.GameWin();
    }

    private async UniTask WaveTimerRoutine()
    {
        while (elapsedTime > 0f)
        {
            await UniTask.Delay(1000, cancellationToken: cts.Token);

            elapsedTime -= 1f;
            OnElapsedTimeChanged?.Invoke(this, elapsedTime);
        }

        elapsedTime = 0f;
        OnWaveFinish?.Invoke(this, waveCount);
    }

    private async UniTask SpawnMonsterRoutine()
    {
        float interval = currentWaveSpawnParameter.spawnInterval;

        while (elapsedTime > 0f)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(interval), cancellationToken: cts.Token);

            RandomSpawn();
        }
    }

    private void RandomSpawn()
    {
        List<MonsterSpawnParameter> monsterParameters = currentWaveSpawnParameter.monsterSpawnParameters;

        // totalRatio : 몬스터의 스폰확률 전부 더한 값
        int totalRatio = monsterParameters.Sum(x => x.ratio);

        // 난수, 현재 몬스터의 스폰확률 누적값
        int randomNumber = UnityEngine.Random.Range(0, totalRatio);
        int ratioSum = 0;

        foreach (var monsterInfo in monsterParameters)
        {
            // 현재 순회중인 몬스터가 난수에 포함되면 스폰당첨
            ratioSum += monsterInfo.ratio;
            if (randomNumber < ratioSum)
            {
                Spawn(monsterInfo);
                break;
            }
        }
    }

    private void Spawn(MonsterSpawnParameter monsterInfo)
    {
        var monster = ObjectPoolManager.Instance.Get(monsterInfo.monsterDetailsSO.monsterType, transform).GetComponent<Monster>(); ;
        monster.InitializeMonster(monsterInfo.monsterDetailsSO);
    }

    private void UniTaskCancel()
    {
        cts?.Cancel();
        cts?.Dispose();
        cts = null;
    }
}
