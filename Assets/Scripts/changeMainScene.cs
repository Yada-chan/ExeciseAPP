using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeMainScene : MonoBehaviour
{
    public void change_button(){
        SceneManager.LoadScene("main_Scene");
    }
}

