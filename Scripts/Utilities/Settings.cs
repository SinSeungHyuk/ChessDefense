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
    public static LayerMask MonsterLayer = LayerMask.GetMask("Monster"); // 체스를 깔 수 있는 타일 레이어
    #endregion

    #region TILE SETTING
    public static float pawnTileValue = 15f; // 폰 타일 시너지 밸류
    public static float knightTileValue = 20f; // 나이트 타일 시너지 밸류
    public static float bishopTileValue = 10f; // 비숍 타일 시너지 밸류
    public static float rookTileValue = 15f; // 룩 타일 시너지 밸류
    public static float queenTileValue = 20f; // 퀸 타일 시너지 밸류
    #endregion

    public const float musicFadeOutTime = 0.5f;
    public const float musicFadeInTime = 0.5f;
}
