using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sum_display : MonoBehaviour
{
    [Header("çáåv")]
    public Text textField;

    // Start is called before the first frame update
    void Start()
    {
        UpdateSumText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSumText();
    }

    void UpdateSumText()
    {
        textField.text = sum_score.sum.ToString();
    }
}

