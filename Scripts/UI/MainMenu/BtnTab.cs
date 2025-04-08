using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnTab : MonoBehaviour
{
    //�ش� ��ư Ŭ���� ���� �� UI�� �ν�����â���� �޾ƿ´�
    [SerializeField] GameObject panel;
    private HowToPlayUIController tabController; //�θ� ��Ʈ�ѷ�
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
        btnTab.onClick.AddListener(SwitchTab); //��ư �����ʿ� �Լ��� �Ҵ�
    }

    private void SwitchTab() //��ư Ŭ���� �θ𿡰� ���� ���������� �˸�
    {
        tabController.SwitchTab(this);
    }

    public void ChangeButtonImage(Sprite sprite)
    {
        if (ImgBtnTab == null) return;

        if (ImgBtnTab.sprite != sprite) //���� ��ư �̹����� ��������Ʈ�� �Ű����� _sprite�� �ٸ��ٸ�
            ImgBtnTab.sprite = sprite; //_sprite�� ��ư �̹����� �ٲ�
    }
}
