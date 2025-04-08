using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct StageData
{
    [TextArea] public string roomDescription;
    //public MusicTrackSO roomMusic; // 스테이지 음악

    public List<ChessTile> Tiles;
    public List<WaveSpawnParameter> waveSpawnParameter;
}

[Serializable]
public struct WaveSpawnParameter
{
    public float spawnInterval; // 스폰 간격
    public List<MonsterSpawnParameter> monsterSpawnParameters; // 스폰할 몬스터 종류&확률
}

[Serializable] // 각 웨이브마다 몬스터의 정보 입력
public struct MonsterSpawnParameter
{
    public MonsterDetailsSO monsterDetailsSO; // 몬스터의 정보
    public int ratio; // 몬스터가 스폰될 확률
}