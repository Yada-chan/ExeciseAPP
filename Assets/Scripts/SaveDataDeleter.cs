using UnityEngine;

public class SaveDataDeleter : MonoBehaviour
{
    private const string CaraKcalKey = "CaraKcalValue"; // カロリーの保存キー
    private const string CaraLevelKey = "CaraLevelValue"; // レベルの保存キー
    private const string CaraPointKey = "CaraPointValue"; //    ポイントの保存キー

    void Awake()
    {
        // このオブジェクトがシーン遷移後も残るようにする
        DontDestroyOnLoad(gameObject);
    }

    void Update()
{
    // Deleteキーが押されたらセーブデータを削除
    if (Input.GetKeyDown(KeyCode.Delete))
    {
        DeleteSaveData();
    }
}

    // セーブデータを削除するメソッド（手動で呼び出す）
    public void DeleteSaveData()
    {
        /*******************************************/
        if (PlayerPrefs.HasKey(CaraKcalKey))
        {
            PlayerPrefs.DeleteKey(CaraKcalKey);
            PlayerPrefs.Save(); // 即時保存
            Debug.Log("Slider Save data deleted.");
        }
        else
        {
            Debug.Log("No save data found to delete.");
        }
        /****************************************/
        if (PlayerPrefs.HasKey(CaraLevelKey))
        {
            PlayerPrefs.DeleteKey(CaraLevelKey);
            PlayerPrefs.Save(); // 即時保存
            Debug.Log("Level Save data deleted.");
        }
        else
        {
            Debug.Log("No save data found to delete.");
        }
        /*******************************************/
        if (PlayerPrefs.HasKey(CaraPointKey))
        {
            PlayerPrefs.DeleteKey(CaraPointKey);
            PlayerPrefs.Save(); // 即時保存
            Debug.Log("Point Save data deleted.");
        }
        else
        {
            Debug.Log("No save data found to delete.");
        }
    }

}
