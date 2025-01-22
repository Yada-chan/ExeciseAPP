using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider kcalSlider; // UnityのInspectorで割り当てる
    private GameManager gameManager;

    private void Start()
    {
        // GameManagerのインスタンスを取得
        gameManager = GameManager.Instance;

        // Sliderの初期値をCaraKcal[0]に設定
        if (kcalSlider != null)
        {
            kcalSlider.value = gameManager.CaraKcal[0];
            kcalSlider.maxValue = 100; // 必要なら設定
            kcalSlider.minValue = 0;   // 必要なら設定
        }
    }

    private void Update()
    {
        if (kcalSlider != null)
        {
            // Sliderの値をCaraKcal[0]に同期
            gameManager.CaraKcal[0] = (int)kcalSlider.value;

            // CaraKcalが100に達したらレベルを上げ、リセットする
            if (gameManager.CaraKcal[0] >= 100)
            {
                gameManager.CaraKcal[0] = 0; // CaraKcalをリセット
                kcalSlider.value = 0;       // Sliderもリセット

                /***************レベル表示*****************/
                var caraDate=gameManager.GetCharacterData(gameManager.NowCaraNum);
                int caraLevel = caraDate.cara_level;
                Debug.Log("Level Up! 新しいレベル: " + caraLevel);
                /*********************************/
            }
        }

    // デバッグ用: KキーでCaraKcalを10増加
            if (Input.GetKeyDown(KeyCode.K))
            {
                gameManager.CaraKcal[0] += 5;
                kcalSlider.value = gameManager.CaraKcal[0]; // Sliderにも反映
                Debug.Log("デバック：カロリー追加！　現在の値 = " + gameManager.CaraKcal[0]);
            }
    }
}
