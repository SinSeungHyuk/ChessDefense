using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct StageData
{
    [TextArea] public string roomDescription;
    //public MusicTrackSO roomMusic; // �������� ����

    public List<ChessTile> Tiles;
    public List<WaveSpawnParameter> waveSpawnParameter;
}

[Serializable]
public struct WaveSpawnParameter
{
    public float spawnInterval; // ���� ����
    public List<MonsterSpawnParameter> monsterSpawnParameters; // ������ ���� ����&Ȯ��
}

[Serializable] // �� ���̺긶�� ������ ���� �Է�
public struct MonsterSpawnParameter
{
    public MonsterDetailsSO monsterDetailsSO; // ������ ����
    public int ratio; // ���Ͱ� ������ Ȯ��
}