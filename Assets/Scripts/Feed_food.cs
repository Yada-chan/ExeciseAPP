using UnityEngine;
using UnityEngine.UI;

public class Feed_food : MonoBehaviour
{
    private RectTransform rectTransform;
    public float speed = 50f; // X軸方向の移動速度（単位: ピクセル/秒）
    private float x = 130; // 初期X座標
    private float y;       // 計算されたY座標
    public float initialScale = 1f; // 初期スケール（1倍）

    private bool isMoving = false;    // 動作中かどうかのフラグ
    private bool isInitialized = false; // 画像が初期化されたかどうか
    private float waitTime = 0.7f;     // 静止する時間
    private float waitTimer = 0f;    // 静止用タイマー
    private bool eat_food = false; // 食べ物を食べたか確認するフラグ

     // GameManager参照の追加
    public GameManager gameManager;  // GameManagerスクリプト

     private const string CaraKcalKey = "CaraKcalValue"; // カロリーの保存キー
    // SaveDataDeleterのインスタンスを参照



    // 他クラスから値を取得・変更できるプロパティ
    void Start()
    {
        // ImageコンポーネントのRectTransformを取得
        rectTransform = GetComponent<RectTransform>();
        // GameManagerインスタンスを取得
        gameManager = GameManager.Instance;

        // 初期位置を設定
        if (rectTransform != null)
        {
            rectTransform.anchoredPosition = new Vector2(x, CalculateY(x));
            rectTransform.localScale = Vector3.zero; // 初期状態では画像を表示しない
        }
    }

    void Update()
    {
        // スペースキーを押したときに画像をロードして初期化
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving && !isInitialized)
        {
            InitializeImage();
        }

        // 初期化後の静止タイマー処理
        if (isInitialized && !isMoving)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                isMoving = true; // 動作開始
                waitTimer = 0f;  // タイマーリセット
            }
        }

        // 動作中の更新処理
        if (isMoving)
        {
            // X座標を時間に応じて減少
            x -= speed * Time.deltaTime;

            // Y座標を関数から計算
            y = CalculateY(x);

            // RectTransformを更新
            if (rectTransform != null)
            {
                rectTransform.anchoredPosition = new Vector2(x, y);

                // Xが小さくなるにつれてスケールを小さくする
                float scaleFactor = Mathf.Clamp01(x / 130f); // xが130のとき1、0のとき0
                rectTransform.localScale = Vector3.one * initialScale * scaleFactor;
            }

            // 到達判定（x <= 0）
            if (x <= 0)
            {
                Debug.Log("目標位置に到達しました！");
                rectTransform.localScale = Vector3.zero; // 完全に消える
                isMoving = false; // 動作を停止
                isInitialized = false; // 初期化状態をリセット
                eat_food = true; // 到達フラグを設定

                // true になったときに GameManager の値を更新
                if (eat_food)
                {
                    
                    if (gameManager != null)
                    {
                        Debug.Log("111GameManager.CaraKcal[0] の値: " + gameManager.CaraKcal[0]);
                        gameManager.CaraKcal[gameManager.NowCaraNum] += 150;

                        PlayerPrefs.SetInt(CaraKcalKey, gameManager.CaraKcal[0]);
                        PlayerPrefs.Save(); // 即時保存

                        Debug.Log("222GameManager.CaraKcal[0] の値: " + gameManager.CaraKcal[0]);
                        Debug.Log("GameManagerのKcalが更新されました！");
                    }
                    else
                    {
                        Debug.LogError("GameManagerがnullです！");
                    }


                    // Eat_food を false にリセット
                    eat_food = false;
                }
            }
        }
    }
    
    // y = -1/25 * (x - 50)^2 + 100 を計算する関数
    float CalculateY(float x)
    {
        return -1f / 25f * Mathf.Pow(x - 50, 2) + 100f;
    }
    /**************************************************************/
    void InitializeImage()
    {
        Image image = GetComponent<Image>();
        int foodType = FeedFood_Number(); // ランダムで0～6を取得
        Sprite sprite = null;

        // FeedFood_Number() の戻り値に応じて画像を切り替える
        switch (foodType)
        {
            case 0:
                sprite = Resources.Load<Sprite>("orange_juice");
                break;
            case 1:
                sprite = Resources.Load<Sprite>("syokupan");
                break;
            case 2:
                sprite = Resources.Load<Sprite>("mayo");
                break;
            case 3:
                sprite = Resources.Load<Sprite>("meat");
                break;
            case 4:
                sprite = Resources.Load<Sprite>("cake");
                break;
            case 5:
                sprite = Resources.Load<Sprite>("cup_ra-men");
                break;
            case 6:
                sprite = Resources.Load<Sprite>("jiro");
                break;
            default:
                Debug.LogError("食べ物ないです！");
                break;
        }

        if (sprite != null)
        {
            image.sprite = sprite;

            x = 130;
            rectTransform.anchoredPosition = new Vector2(x, CalculateY(x));
            rectTransform.localScale = Vector3.one * initialScale;

            isInitialized = true;
            eat_food = false;
            Debug.Log($"画像 '{sprite.name}' がロードされ、初期化されました！");
        }
        else
        {
            Debug.LogError("指定されたスプライトが見つかりません！");
        }
    }
    /******************************************************/
    public int FeedFood_Number()
    {
        return Random.Range(0, 7); // 0以上7未満の整数をランダムに返す
    }

    private bool hantei = false;

    // hantei を外部から変更するためのメソッド
    public void SetHantei(bool value)
    {
        hantei = value; // hantei の値を変更
    }
    /*
    // 他のクラスでつかうとき
    feedFoodScript.SetHantei(true);  // hantei を true に変更
    */
    // スペースキーが押されたらtrue、押されていないとfalseを返す関数
    public bool Key()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hantei = true; // スペースキーが押されたらtrueにする
        }
        else
        {
            hantei = false; // それ以外はfalseにする
        }

        return hantei;
    }
    /**********************************************************/

}
