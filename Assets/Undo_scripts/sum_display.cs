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
        textField.text = sum_score.sum.ToString();
    }


}
