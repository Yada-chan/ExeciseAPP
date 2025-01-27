using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllershow : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] omoide; // omoideのグループ
    public GameObject[] present; //presentのグループ
   //presentのグループ
    
    //Button型の宣言
    public Button Image_present;//ok_presentのボタン
    public Button Image_omoide;
    public Button ok_present;//ok_presentのボタン
    public Button ok_omoide;//ok_omoideのボタン
    private bool isomoideActive = false; // omoide内容が表示中か
    private bool ispresentActive = false; // present内容が表示中か
    void Start()
    {
        SetGroupActive(omoide,false);
        SetGroupActive(present,false);

       EnableButtons();
    }


    public void showomoide()
    {
            HideAllGroups();               // 他のグループを非表示にする
            SetGroupActive(omoide, true);  // omoideグループを表示
            DisableGroupButtons(omoide);   // omoideグループ内のボタンを無効化
            EnableSpecificButton(ok_omoide); // ok_omoideボタンのみ有効化
            DisableButtons();              // 他のメインボタンを無効化
            isomoideActive = true;  

        /*if (isomoideActive || !ispresentActive)
            return;
         
         SetGroupActive(omoide,true);
         SetButtonsInteractable(false);
         ok_omoide.interactable = true;
        isomoideActive = true;
         */

    }

     public void showpresent()
    {
        if (!ispresentActive) // 既に表示中でない場合
        {
            HideAllGroups();                // 他のグループを非表示にする
            SetGroupActive(present, true);  // presentグループを表示
            DisableGroupButtons(present);   // presentグループ内のボタンを無効化
            EnableSpecificButton(ok_present); // ok_presentボタンのみ有効化
            DisableButtons();               // 他のメインボタンを無効化
            ispresentActive = true;         // presentを表示中とする
        }
        /*if (isomoideActive || !ispresentActive)
            return;
         
         SetGroupActive(present,true);
         SetButtonsInteractable(false);
         ok_present.interactable = true;
        ispresentActive = true;*/
         
    }
 private void HideAllGroups()
    {
        SetGroupActive(omoide, false);
        SetGroupActive(present, false);
        isomoideActive = false;
        ispresentActive = false;
        EnableButtons(); // メインボタンを再有効化
    }
/*
    public void Hideomoide()
    {
        SetGroupActive(omoide,false);
        EnableButtons();
        isomoideActive = false; 
    }
     public void Hidepresent()
    {
        SetGroupActive(present,false);
        EnableButtons();
        ispresentActive = false; 
    }
*/
  private void SetGroupActive(GameObject[] group, bool isActive)
    {
        foreach (GameObject obj in group)
        {
            obj.SetActive(isActive);
        }
    }
  /*  private void SetGroupActive(GameObject group,bool isActive)
    {
       
            group.SetActive(isActive);
        
    }
    */
/*      private void SetButtonsInteractable(bool isInteractable)
    {
        ok_omoide.interactable = isInteractable;
        ok_present.interactable = isInteractable;
    }

    private void EnableButtons()
    {
         ok_omoide.interactable =true;
        ok_present.interactable =true;
    }
*/

   public void DisableGroupButtons(GameObject[] group)
    {
         foreach (GameObject obj in group)
        {
            Button button = obj.GetComponent<Button>();

            if (button != null)
             button.interactable = false;
        }
       
        
    }


    public void EnableSpecificButton(Button button)
    {
        if (button != null)
             button.interactable = false;
    }

    public void DisableButtons()
    {
       // foreach(Button button in Image_omoide)
            Image_omoide.interactable = false;

        //foreach(Button button in Image_present)
            Image_present.interactable = false;

    }
     public void EnableButtons()
    {
        //foreach(Button button in Image_omoide)
             Image_omoide.interactable = true;

        //foreach(Button button in Image_present)
            Image_present.interactable = true;

    }


  

}
