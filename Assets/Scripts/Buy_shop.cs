using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro を使用するための名前空間

public class OKButtonHandler : MonoBehaviour
{
    public GameManager gameManager; // GameManager の参照
    public TMP_Text pointText; // ポイントを表示するTextMeshPro-Text (UI)


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

        if (gameManager == null)
        {
            Debug.LogError("GameManager が見つかりません！シーン内に GameManager を配置してください。");
        }

        if (pointText == null)
        {
            Debug.LogError("pointText が設定されていません！");
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
                pointText.text = gameManager.Point.ToString();

                Debug.Log($"商品購入完了！選択された商品: {itemNames[selectedItemIndex]}, コスト: {itemCost}, 残りポイント: {gameManager.Point}");

                // 現在の所持アイテムを表示
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
            }
            else
            {
                Debug.LogError("ポイントが不足しています！(この状態は警告の制御を ItemButtonHandler に統一したため、基本的に発生しない想定)");
            }
        }
        else
        {
            Debug.LogError("選択されたアイテムが不明です！");
        }
    }
}
