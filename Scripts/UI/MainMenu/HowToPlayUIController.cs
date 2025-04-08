using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HowToPlayUIController : MonoBehaviour
{
    [SerializeField] Sprite btnNormal; //탭버튼이 정상일때
    [SerializeField] Sprite btnSelect; //탭버튼이 눌러진 상태일때

    private List<BtnTab> btnTabList; //자식들인 탭버튼을 저장할 배열


    private void Awake()
    {
        btnTabList = GetComponentsInChildren<BtnTab>().ToList();

    }
    private void Start()
    {
        SwitchTab(btnTabList.First()); //첫번째 탭을 눌러준다
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
