using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class kiroku : MonoBehaviour,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // クリックされたときの処理を書く
        Debug.Log("クリックされました");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecordButtonClicked(PointerEventData eventData)
    {
        Vector2 clickPosition=eventData.position;
        Debug.Log("記録ボタンが押されました。座標："+clickPosition);
    }
}
