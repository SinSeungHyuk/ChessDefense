using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HowToPlayUIController : MonoBehaviour
{
    [SerializeField] Sprite btnNormal; //�ǹ�ư�� �����϶�
    [SerializeField] Sprite btnSelect; //�ǹ�ư�� ������ �����϶�

    private List<BtnTab> btnTabList; //�ڽĵ��� �ǹ�ư�� ������ �迭


    private void Awake()
    {
        btnTabList = GetComponentsInChildren<BtnTab>().ToList();

    }
    private void Start()
    {
        SwitchTab(btnTabList.First()); //ù��° ���� �����ش�
    }

    public void SwitchTab(BtnTab clickedBtnTab)
    {
        foreach (var btnTab in btnTabList)
        {
            bool isActiveTab = (clickedBtnTab ==  btnTab);
            btnTab.Panel.SetActive(isActiveTab);
            btnTab.ChangeButtonImage(isActiveTab ? btnSelect : btnNormal);
        }
    }
}
