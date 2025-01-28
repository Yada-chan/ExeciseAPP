using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro を使用するための名前空間

public class OKButtonHandler : MonoBehaviour
{
    public GameManager gameManager; // GameManager の参照
    public TMP_Text PointText; // ポイントを表示するTextMeshPro-Text (UI)
    private int point = 0;
    private const string CaraPointKey = "CaraPointValue"; // ポイントの保存キー
    private const string ItemKeyPrefix = "Item"; // 所持アイテム保存キーのプレフィックス


    // 商品のポイントコストを内部で定義
    private readonly Dictionary<int, int> itemCosts = new Dictionary<int, int>
    {
        { 0, 10 }, // orangejuice
        { 1, 20 }, // syokupan
        { 2, 50 }, // mayo
        { 3, 50 }, // meat
        { 4, 50 }, // cake
        { 5, 100 }, // cupra-men
        { 6, 500 }  // jiro
    };

    // 商品名をインデックスに対応させる辞書
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
        // GameManager のインスタンスを取得
        gameManager = GameManager.Instance;
        Debug.Log("1");

        if (gameManager == null)
        {
            Debug.LogError("GameManager が見つかりません！シーン内に GameManager を配置してください。");
        }

        if (PointText == null)
        {
            Debug.LogError("PointText が設定されていません！");
        }
        Debug.Log("1");

        // ポイントの読み込み
        if (PlayerPrefs.HasKey(CaraPointKey))
        {
            gameManager.Point = PlayerPrefs.GetInt(CaraPointKey);
            point = gameManager.Point;
        }
        else
        {
            gameManager.Point = 0; // ポイントの初期値
            point = gameManager.Point;
        }

        // 所持アイテムの読み込み
        for (int i = 0; i < gameManager.Item.Length; i++)
        {
            string itemKey = ItemKeyPrefix + i;
            if (PlayerPrefs.HasKey(itemKey))
            {
                gameManager.Item[i] = PlayerPrefs.GetInt(itemKey);
            }
            else
            {
                gameManager.Item[i] = 0; // 初期値を0に設定（アイテムがまだない場合）
            }
        }

    }


    public void OnOKButtonPressed()
    {
        int selectedItemIndex = gameManager.SelectItem; // 選択中の商品インデックス

        if (itemCosts.TryGetValue(selectedItemIndex, out int itemCost))
        {
            if (gameManager.Point >= itemCost)
            {
                // 商品購入処理
                gameManager.Item[selectedItemIndex]++;
                gameManager.Point -= itemCost;
                
                // ポイントの保存
                PlayerPrefs.SetInt(CaraPointKey, gameManager.Point); // ポイントを保存
                PlayerPrefs.Save(); // 即時保存

                // 所持アイテムの保存
                for (int i = 0; i < gameManager.Item.Length; i++)
                {
                    string itemKey = ItemKeyPrefix + i;
                    PlayerPrefs.SetInt(itemKey, gameManager.Item[i]);
                }

                PlayerPrefs.Save(); // 所持アイテムの即時保存

                Debug.Log($"商品購入完了！選択された商品: {itemNames[selectedItemIndex]}, コスト: {itemCost}, 残りポイント: {gameManager.Point}");

                // 所持アイテムの表示
                Debug.Log("現在の所持アイテム:");
                for (int i = 0; i < gameManager.Item.Length; i++)
                {
                    if (itemNames.TryGetValue(i, out string itemName))
                    {
                        Debug.Log($"- {itemName}: {gameManager.Item[i]} 個");
                    }
                    else
                    {
                        Debug.Log($"- アイテム{i}: {gameManager.Item[i]} 個");
                    }
                }

                point = gameManager.Point;
                PointText.text = point.ToString();
            }
            else
            {
                Debug.LogError("ポイントが不足しています！");
            }
        }
        else
        {
            Debug.LogError("選択されたアイテムが不明です！");
        }
    }


}
