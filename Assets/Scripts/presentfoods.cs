using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class presentfoods : MonoBehaviour
{


    // Start is called before the first frame update
     /*public GameManager gameManager; // GameManager の参照
    //public TMP_Text pointText; // ポイントを表示するTextMeshPro-Text (UI)
    // 商品のポイントコストを内部で定義
    public TMP_Text[] foodsnum;//商品全体の数
    public TMP_Text syouhinselect;  //商品名を表示するTextMeshPro-Text (UI)
    public GameObject popup; // ポップアップ用の親オブジェクト
    private int point=0; // 変数保持

     private readonly Dictionary<int, string> itemNames = new Dictionary<int, string>
    {
        { 0, "Orange Juice" },
        { 1, "Syokupan" },
        { 2, "Mayo" },
        { 3, "Meat" },
        { 4, "Cake" },
        { 5, "Cup Ramen" },
        { 6, "Jiro" }
    };
    private void Start()
    {
        gameManager = GameManager.Instance;
        //RestoreChara_Point();
        //UpdatePointText(); // 初期表示
        if (gameManager == null)
        {
            Debug.LogError("GameManager が見つかりません！シーン内に GameManager を配置してください。");
        }
         if (popup != null)
        {
            popup.SetActive(false); // 初期状態で非表示にする
        }
        else
        {
            Debug.LogError("Popupオブジェクトが設定されていません！");
        }
    }

    public void textclick(String buttonName)
    {
        int selectedItemIndex = gameManager.SelectItem;
        string normalizedButtonName = buttonName.Trim('"').Trim().ToLower();
        Debug.Log($"受け取ったボタン名（正規化後）: \"{normalizedButtonName}\"");
        //gameManager.Item[selectedItemIndex]--;
        popup.SetActive(true); // ポップアップを表示

    }*/
}

