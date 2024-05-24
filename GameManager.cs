using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Crosshair crosshair;
    public TextMeshProUGUI playerSub;
    public TextMeshProUGUI objectiveText;

    public GameObject spacebar;

    public GameObject blink;
     void Start()
    {
        blink.SetActive(true);
        crosshair = FindObjectOfType<Crosshair>();
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        DontShowSpaceBar();
        Invoke("FirstLine", 9f);
        Invoke("ShowSpaceBar", 15f);
    }

    public void ClearSub()
    {
        playerSub.text = "";
    }

    public void FirstLine()
    {
        objectiveText.text = "Explore the Island.";
        playerSub.text = "They took my boat's helm. I need to get it back!";
    }
    void ShowSpaceBar()
    {
        spacebar.SetActive(true);
    }

    void DontShowSpaceBar()
    {
        spacebar.SetActive(false);
    }
}
