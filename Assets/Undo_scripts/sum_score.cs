using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sum_score : MonoBehaviour
{
    public static int sum = 0;
  
    public static void AddSum_radio()
    {
        sum += 100;
        Debug.Log(sum);
    }

    public static void Dec_Sum_radio()
    {
        sum -= 100;
        Debug.Log(sum);
    }
}
