using UnityEngine;

public class FoodProjectile : MonoBehaviour
{
    public Vector3 startPosition = new Vector3(180, -180, 0);  // 食べ物の初期位置
    public Vector3 targetPosition = new Vector3(0, 0, 0);      // キャラの位置（画面の中心）
    public float moveDuration = 3f;  // 食べ物がキャラに届くまでの時間
    public float gravity = 9.8f;  // 重力加速度（m/s²）

    private Vector3 velocity;  // 初速度
    private float moveTime = 0f;  // 移動時間

    void Start()
    {
        // 水平距離と垂直距離を計算
        Vector3 distance = targetPosition - startPosition;
        float horizontalDistance = distance.x;  // 水平距離
        float verticalDistance = distance.y;    // 垂直距離

        // 到達する時間（移動時間）を計算
        float timeToReachTarget = moveDuration;

        // 垂直方向の速度を計算
        float verticalSpeed = (verticalDistance + 0.5f * gravity * timeToReachTarget * timeToReachTarget) / timeToReachTarget;

        // 水平方向の速度を計算
        float horizontalSpeed = horizontalDistance / timeToReachTarget;

        // 初速度（水平と垂直の成分）
        velocity = new Vector3(horizontalSpeed, verticalSpeed, 0);
        transform.position = startPosition;
    }

    void Update()
    {
        moveTime += Time.deltaTime;

        // 時間に基づいて位置を更新
        float t = Mathf.Clamp01(moveTime / moveDuration);

        // 水平方向の移動
        float x = startPosition.x + velocity.x * moveTime;

        // 垂直方向の移動（重力を考慮）
        float y = startPosition.y + velocity.y * moveTime - 0.5f * gravity * Mathf.Pow(moveTime, 2);

        // 位置を設定
        transform.position = new Vector3(x, y, 0);

        // 完了したらスクリプトを無効化
        if (t >= 1f)
        {
            enabled = false; // スクリプトを停止
        }
    }
}

