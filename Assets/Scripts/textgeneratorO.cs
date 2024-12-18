using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textgeneratorO : MonoBehaviour
{
    [SerializeField]
    private textbaseomoide textbasePrefab; //生成する羊のPrefab
 
    //羊作成
    public void CreatetextbaseO()
    {
        var sheep = Instantiate(textbasePrefab);
    }
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            CreatetextbaseO();
        }
    }
}
