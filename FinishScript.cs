using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    public GameObject FinishUI;

    void Start()
    {
        Invoke("ShowFinish", 7f);
    }

    void ShowFinish()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FinishUI.SetActive(true);
    }

   

    
}
