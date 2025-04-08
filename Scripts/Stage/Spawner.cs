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
    public event Action<Spawner, float> OnElapsedTimeChanged; // ���̺� ����ð�

    private List<WaveSpawnParameter> waveSpawnParameterList; // �� ���̺꺰 ��������
    private WaveSpawnParameter currentWaveSpawnParameter; // ���� ���̺� ��������
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
        // ���̺�ī��Ʈ (0���� ����) == ���̺� �� (1���� ����) -> ������ ���̺���� ����� ����
        if (waveCount == waveSpawnParameterList.Count)
        {
            StageFinish();

            return;
        }

        // UI������ ���̺� ī��Ʈ + 1�� ���������
        cts = new CancellationTokenSource();

        currentWaveSpawnParameter = waveSpawnParameterList[waveCount];

        elapsedTime = Settings.waveTimer; // ���̺� �⺻�ð����� �ʱ�ȭ
        WaveTimerRoutine().Forget();
        SpawnMonsterRoutine().Forget();
    }

    private void MonsterSpawnEvent_OnWaveFinish(Spawner spawner, int waveCount)
    {
        UniTaskCancel();

        this.waveCount++; // ���̺갡 ����ǰ� ���̺� ī��Ʈ ����
        OnWaveStart?.Invoke(this, this.waveCount); // ���� ���̺� ����
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

        // totalRatio : ������ ����Ȯ�� ���� ���� ��
        int totalRatio = monsterParameters.Sum(x => x.ratio);

        // ����, ���� ������ ����Ȯ�� ������
        int randomNumber = UnityEngine.Random.Range(0, totalRatio);
        int ratioSum = 0;

        foreach (var monsterInfo in monsterParameters)
        {
            // ���� ��ȸ���� ���Ͱ� ������ ���ԵǸ� ������÷
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
