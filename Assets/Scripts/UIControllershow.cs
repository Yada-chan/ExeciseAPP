using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllershow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] omoide;
    public GameObject[] present;

    //Button型の宣言

    public Button[] Image_omoide; // omideのボタン
    public Button[] Image_present; //presentのボタン 

    private bool isomoideActive = true; // Aが表示中か
    private bool ispresentActive = true; // Bが表示中か
    void Start()
    {
        SetGroupActive(omoide,false);
        SetGroupActive(present,false);

       EnableButtons();
    }


    public void showomoide()
    {
        if(isomoideActive || ispresentActive)
        {return;}

        SetGroupActive(omoide,true);
        DisableButtons();
        isomoideActive = true;
    }

    public void showpresent()
    {
         if(isomoideActive || ispresentActive)
        {return;}
        
        SetGroupActive(present,true);
        DisableButtons();
        ispresentActive = true;
    }

    public void Hideomoide()
    {
        SetGroupActive(omoide,false);
        isomoideActive = false;
         EnableButtons();
    }

    public void Hidepresent()
    {
        SetGroupActive(present,false);
        ispresentActive = false;
         EnableButtons();
    }

    private void SetGroupActive(GameObject[] group,bool isActive)
    {
        foreach (GameObject obj in group)
        {
            obj.SetActive(isActive);
        }
    }

    public void DisableButtons()
    {
         foreach (Button button in Image_omoide)
        {
             button.interactable = false;
        }
       
        foreach (Button button in Image_present)
        {
             button.interactable = false;
        }
    }

    public void EnableButtons()
    {
        
         foreach (Button button in Image_omoide)
        {
             button.interactable = true;
        }
       
        foreach (Button button in Image_present)
        {
             button.interactable = true;
        }
    }


}
