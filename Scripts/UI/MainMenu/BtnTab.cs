using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnTab : MonoBehaviour
{
    //해당 버튼 클릭시 열어 줄 UI를 인스펙터창에서 받아온다
    [SerializeField] GameObject panel;
    private HowToPlayUIController tabController; //부모 컨트롤러
    private Button btnTab;
    private Image ImgBtnTab;
    
    public GameObject Panel => panel;


    private void Awake()
    {
        btnTab = GetComponent<Button>();
        ImgBtnTab = GetComponent<Image>();
        tabController = transform.parent.GetComponent<HowToPlayUIController>();
    }

    private void Start()
    {
        btnTab.onClick.AddListener(SwitchTab); //버튼 리스너에 함수를 할당
    }

    private void SwitchTab() //버튼 클릭시 부모에게 내가 눌려졌음을 알림
    {
        tabController.SwitchTab(this);
    }

    public void ChangeButtonImage(Sprite sprite)
    {
        if (ImgBtnTab == null) return;

        if (ImgBtnTab.sprite != sprite) //현재 버튼 이미지의 스프라이트와 매개변수 _sprite가 다르다면
            ImgBtnTab.sprite = sprite; //_sprite로 버튼 이미지를 바꿈
    }
}
