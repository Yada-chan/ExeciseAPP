using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro を使用するための名前空間

public class ItemButtonHandler : MonoBehaviour
{
    private GameManager gameManager; // GameManagerの参照を保持
    public GameObject caution; // 警告用の親オブジェクト
    public GameObject popup; // ポップアップ用の親オブジェクト
    public TMP_Text syouhinmeiText; // 商品名を表示するTextMeshPro-Text (UI)
    public TMP_Text syouhinkakakuText; // 商品価格を表示するTextMeshPro-Text (UI)
    //public TMP_Text PointText; // ポイントを表示するTextMeshPro-Text (UI)
    //private int point = 0;
    //private const string CaraPointKey = "CaraPointValue"; // ポイントの保存キー

    // アイテム名と対応するポイント減少量、およびアイテムインデックスを定義
    private readonly Dictionary<string, (int cost, int itemIndex)> itemData = new Dictionary<string, (int, int)>
    {
        { "orangejuice", (10, 0) },
        { "syokupan", (20, 1) },
        { "mayo", (50, 2) },
        { "meat", (50, 3) },
        { "cake", (50, 4) },
        { "cupra-men", (100, 5) },
        { "jiro", (500, 6) }
    };

    private void Start()
    {
        // GameManagerのインスタンスを取得
        gameManager = GameManager.Instance;

        if (gameManager == null)
        {
            Debug.LogError("GameManagerが見つかりません！シーン内にGameManagerを配置してください。");
        }

        if (caution != null)
        {
            caution.SetActive(false); // 初期状態で非表示にする
        }
        else
        {
            Debug.LogError("Cautionオブジェクトが設定されていません！");
        }

        if (popup != null)
        {
            popup.SetActive(false); // 初期状態で非表示にする
        }
        else
        {
            Debug.LogError("Popupオブジェクトが設定されていません！");
        }

        if (syouhinmeiText == null)
        {
            Debug.LogError("syouhinmeiText が設定されていません！");
        }

        if (syouhinkakakuText == null)
        {
            Debug.LogError("syouhinkakakuText が設定されていません！");
        }
        //if (PlayerPrefs.HasKey(CaraPointKey))
        //{
        //    gameManager.Point = PlayerPrefs.GetInt(CaraPointKey);
        //    point = gameManager.Point;
        //}
        //UpdatePointText();

    }

    // ボタンが押されたときに呼び出される関数
    public void OnButtonPressed(string buttonName)
    {
        // ボタン名を正規化（小文字化、不要な引用符の除去）
        string normalizedButtonName = buttonName.Trim('"').Trim().ToLower();
        Debug.Log($"受け取ったボタン名（正規化後）: \"{normalizedButtonName}\"");

        if (itemData.TryGetValue(normalizedButtonName, out var data))
        {
            Debug.Log("ボタンが押されました: " + normalizedButtonName);

            if (gameManager.Point >= data.cost)
            {
                // ポイントが足りる場合
                gameManager.SelectItem = data.itemIndex; // 選択中の商品インデックスを設定
                syouhinmeiText.text = normalizedButtonName; // 商品名を設定
                syouhinkakakuText.text = data.cost.ToString(); // 商品価格を設定
                caution.SetActive(false); // 警告を非表示
                popup.SetActive(true); // ポップアップを表示
            }
            else
            {
                // ポイントが足りない場合
                caution.SetActive(true); // 警告を表示
                popup.SetActive(false); // ポップアップを非表示
            }
        }
        else
        {
            Debug.LogError($"不明なアイテム: \"{buttonName}\"");
        }
    }
    //void UpdatePointText()
    //{
    //    if (PointText != null)
    //    {
    //        PointText.text = point.ToString();// 変数をTextに反映
    //    }
    //}


}