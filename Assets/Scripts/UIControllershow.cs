using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllershow : MonoBehaviour
{
    // グループ内のUI要素を管理
    public GameObject[] omoide;         // omoideグループ内のUI要素
    public GameObject[] present;       // presentグループ内のUI要素

    public Button Image_omoide;        // omoide用ボタン
    public Button Image_present;       // present用ボタン

    public Button ok_omoide;           // omoideグループを閉じるボタン
    public Button ok_present;          // presentグループを閉じるボタン

    private void Start()
    {
        // 初期状態で全グループを非表示
        SetGroupActive(omoide, false);
        SetGroupActive(present, false);

        // ボタンのクリックイベントを登録
        Image_omoide.onClick.AddListener(ShowOmoide);
        Image_present.onClick.AddListener(ShowPresent);
        ok_omoide.onClick.AddListener(HideOmoide);
        ok_present.onClick.AddListener(HidePresent);

        EnableButton(Image_omoide);
        EnableButton(Image_present);
    }

    // omoideグループを表示
    private void ShowOmoide()
    {
        SetGroupActive(present, false);  // 他のグループを非表示
        SetGroupActive(omoide, true);    // omoideグループを表示
        //Image_present.interactable = false;
        DisableButton(Image_present);
    }

    // presentグループを表示
    private void ShowPresent()
    {
        SetGroupActive(omoide, false);   // 他のグループを非表示
        SetGroupActive(present, true);   // presentグループを表示
        //Image_omoide.interactable = false;
        DisableButton(Image_omoide);
    }

    // omoideグループを非表示
    private void HideOmoide()
    {
        SetGroupActive(omoide, false);
        EnableButton(Image_present);
        //Image_present.interactable = true;
    }

    // presentグループを非表示
    private void HidePresent()
    {
        SetGroupActive(present, false);
        EnableButton(Image_omoide);
        //Image_omoide.interactable = true;
    }

    // 指定されたグループを表示/非表示に設定
    private void SetGroupActive(GameObject[] group, bool isActive)
    {
        foreach (GameObject obj in group)
        {
            obj.SetActive(isActive);
        }
    }

       private void DisableButton(Button button)
    {
        if (button != null)
        {
            button.interactable = false;
        }
    }

    // ボタンを有効化
    private void EnableButton(Button button)
    {
        if (button != null)
        {
            button.interactable = true;
        }
    }




}