using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


// �������� ���ٰ����� ���� ��� static Ŭ����
public static class UtilitieHelper
{
    // ���ͷκ��� ���� ���ϱ�  ===========================================================
    public static float GetAngleFromVector(Vector3 vector)
    {
        float radians = Mathf.Atan2(vector.y, vector.x); // Atan2(y,x) ���� ���ϱ�
        float degrees = radians * Mathf.Rad2Deg;         // ���� ��׸��� ��ȯ

        return degrees;
    }

    // �����κ��� ���⺤�� ���ϱ�  ===========================================================
    public static Vector3 GetDirectionVectorFromAngle(float angle)
    {
        Vector3 direction = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0f);
        return direction;
    }

    // ����ȭ�� �ۿ� �ִ� ������Ʈ���� �˻� =====================================================
    public static bool IsOutScreen(GameObject target)
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(target.transform.position);
        bool isOutScreen = screenPoint.x <= 0 || screenPoint.x >= Screen.width || screenPoint.y <= 0 || screenPoint.y >= Screen.height;

        return isOutScreen;
    }

    // Ȯ�� ����ϱ�  ===========================================================
    public static bool isSuccess(int percent)
    {
        int chance = Random.Range(1, 101);
        return percent >= chance; // �����ϸ� true
    }
    public static bool isSuccess(float percent)
    {
        int chance = Random.Range(1, 101);
        return percent >= chance; // �����ϸ� true
    }

    // �ۼ�Ʈ % ����ϱ�  ===========================================================
    public static int IncreaseByPercent(int value, float percent)
    {
        float increase = value * (percent / 100);
        return value + (int)increase;
    }
    public static float IncreaseByPercent(float value, float percent)
    {
        float increase = value * (percent / 100);
        return value + increase;
    }
    public static int DecreaseByPercent(int value, float percent)
    {
        float increase = value * (percent / 100);
        return Mathf.RoundToInt(value - increase);
    }
    public static float DecreaseByPercent(float value, float percent)
    {
        float increase = value * (percent / 100);
        return value - increase;
    }

    // ���� ���� �������� ���ú��� ��ȯ ====================================================================
    public static float LinearToDecibels(int linear)
    {
        float linearScaleRange = 20f;
        return Mathf.Log10((float)linear / linearScaleRange) * 20f;
    }
}
