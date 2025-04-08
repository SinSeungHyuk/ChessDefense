using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings
{
    public static float waveTimer = 20f;
    public static int DefaultGold = 100;
    public static int RefundTowerGold = 15;

    public static Vector3 towerOriginRotation = new Vector3(-90, 0, 0);
    public static Vector3 gameOverCameraPos = new Vector3(0f, 8f, -4.77f);
    public static Vector3 gameWinCameraPos = new Vector3(32f, 8f, -4.77f);

    #region LAYERMASK SETTING
    public static LayerMask MonsterLayer = LayerMask.GetMask("Monster"); // ü���� �� �� �ִ� Ÿ�� ���̾�
    #endregion

    #region TILE SETTING
    public static float pawnTileValue = 15f; // �� Ÿ�� �ó��� ���
    public static float knightTileValue = 20f; // ����Ʈ Ÿ�� �ó��� ���
    public static float bishopTileValue = 10f; // ��� Ÿ�� �ó��� ���
    public static float rookTileValue = 15f; // �� Ÿ�� �ó��� ���
    public static float queenTileValue = 20f; // �� Ÿ�� �ó��� ���
    #endregion

    public const float musicFadeOutTime = 0.5f;
    public const float musicFadeInTime = 0.5f;
}
