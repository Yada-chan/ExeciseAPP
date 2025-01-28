using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    public Image targetImage;  // 画像を表示するUI Imageコンポーネント
    public int imageIndex = 1; // 表示する画像を選択するためのインデックス（デフォルトは1）

    void Start()
    {
        // 画像をロード
        if (imageIndex > 0 && imageIndex <= 8)
        {
            string imagePath = GetImagePath(imageIndex);
            Sprite sprite = Resources.Load<Sprite>(imagePath);

            if (sprite != null)
            {
                targetImage.sprite = sprite;
                Debug.Log(imagePath + "の画像が表示されています");
            }
            else
            {
                Debug.LogError("画像が見つかりません: " + imagePath);
            }
        }
        else
        {
            Debug.LogError("引数は1から8の範囲内でなければなりません。");
        }
    }

    string GetImagePath(int index)
    {
        switch (index)
        {
            case 1:
                return "jiro";  // Resourcesフォルダ内の「jiro.jpeg」を指定
            default:
                return null;  // その他の引数は無効
        }
    }
}

