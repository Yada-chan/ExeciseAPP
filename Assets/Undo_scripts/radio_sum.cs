using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnotherScript : MonoBehaviour
{
    void Start()
    {
        // —á‚¦‚ÎA‰Šú‰»‚É100‚ğ‰Á‚¦‚é
        sum_score.AddToSum(100);

        // ‘¼‚Ì‘€ì‚É‰‚¶‚Ä’l‚ğ‰Á‚¦‚é
        sum_score.DecToSum(100);
    }


}
