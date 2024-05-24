using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crosshair : MonoBehaviour
{
    [Header("Script References")]
    public PlayerScript playerScript;
    public Inventory inventory;

    [Header("Raycast")]
    public LayerMask layerMask;
    public Transform crosshair;
    public TextMeshProUGUI pressE;

    [Header("Player Subtitle")]
    public TextMeshProUGUI playerSub;

    [Header("Animator")]
    public Animator playerSubAnim;
    public Animator NPCSubAnim;
    public Animator gateOne;

    [Header("NPC Subtitle")]
    public TextMeshProUGUI NPCSub;

    [Header("Bridge Wall / Chainsaw")]
    public GameObject Blockage;
    public bool hasChainsaw = false;
    public GameObject chainsaw;
    public bool hasMachete = false;

    [Header("Item Icons")]
    public GameObject chainsawIcon;
    public GameObject macheteIcon;
    public GameObject helmIcon;
    public GameObject potionIcon;

    [Header("FrancisSub")]
    public int francis;
    public int francisco;
    public bool franciscoTalk = false;
    public bool francisTalk = false;
    public bool firstTalkDone = false;
    public bool hasPasscode = false;
    public bool franciscoFirstTalkDone = false;

    [Header("NPCs")]
    public GameObject FrancisGO;
    public GameObject FranciscoGO;

    [Header("Helm")]
    public bool hasHelm = false;
    public GameObject Helm;

    [Header("Potion")]
    public GameObject potionOne;
    public GameObject potionTwo;
    public GameObject potionThree;
    public GameObject potionFour;
    public GameObject potionFive;
    public GameObject potionSix;
    public GameObject potionSeven;
    public GameObject potionEight;
    public GameObject potionNine;
    public GameObject potionTen;
    public GameObject potionEleven;
    public GameObject potionTwelve;
    public GameObject potionThirteen;
    public GameObject potionFourteen;
    public GameObject potionFifthteen;
    public GameObject potionSixteen;
    public GameObject potionSeventeen;
    public GameObject potionEightteen;
    public GameObject potionNineteen;
    public GameObject potionTwenty;

    [Header("CheckpoinDone")]
    public GameObject lastCheckpoint;
    public GameObject lastEnemies;


    public bool canPressE = true;
    public bool showPressE = true;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        playerScript = FindObjectOfType<PlayerScript>();
        Invoke("FirstLine", 6f);
        Invoke("ClearSub", 13f);
    }

    void Update()
    {
        //Invoke("CrosshairIcon", 13f);

        CrosshairIcon();

        if (Input.GetKeyDown(KeyCode.E) && canPressE == true)
        {
            HitSelect();
        }
    }

    public void HitSelect()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3f, layerMask))
        {
            if (hit.collider.name == "PotionOne")             // Potion
            {
                inventory.RemainingPotion++;
                potionOne.SetActive(false);
                potionIcon.SetActive(true);
            }

            if (hit.collider.name == "PotionTwo")             // Potion
            {
                inventory.RemainingPotion++;
                potionTwo.SetActive(false);
                potionIcon.SetActive(true);
            }

            if (hit.collider.name == "PotionThree")             // Potion
            {
                inventory.RemainingPotion++;
                potionThree.SetActive(false);
                potionIcon.SetActive(true);
            }

            if (hit.collider.name == "PotionFour")             // Potion
            {
                inventory.RemainingPotion++;
                potionFour.SetActive(false);
                potionIcon.SetActive(true);
            }

            if (hit.collider.name == "PotionFive")             // Potion
            {
                inventory.RemainingPotion++;
                potionFive.SetActive(false);
                potionIcon.SetActive(true);
            }

            if (hit.collider.name == "PotionSix")             // Potion
            {
                inventory.RemainingPotion++;
                potionSix.SetActive(false);
                potionIcon.SetActive(true);
            }

            if (hit.collider.name == "PotionSeven")             // Potion
            {
                inventory.RemainingPotion++;
                potionSeven.SetActive(false);
                potionIcon.SetActive(true);
            }

            if (hit.collider.name == "PotionEight")             // Potion
            {
                inventory.RemainingPotion++;
                potionEight.SetActive(false);
                potionIcon.SetActive(true);
            }

            if (hit.collider.name == "PotionNine")             // Potion
            {
                inventory.RemainingPotion++;
                potionNine.SetActive(false);
                potionIcon.SetActive(true);
            }

            if (hit.collider.name == "PotionTen")             // Potion
            {
                inventory.RemainingPotion++;
                potionTen.SetActive(false);
                potionIcon.SetActive(true);
            }

            if (hit.collider.name == "PotionEleven")             // Potion
            {
                inventory.RemainingPotion++;
                potionEleven.SetActive(false);
                potionIcon.SetActive(true);
            }

            if (hit.collider.name == "PotionTwelve")             // Potion
            {
                inventory.RemainingPotion++;
                potionTwelve.SetActive(false);
                potionIcon.SetActive(true);
            }

            if (hit.collider.name == "PotionThirteen")             // Potion
            {
                inventory.RemainingPotion++;
                potionThirteen.SetActive(false);
                potionIcon.SetActive(true);
            }

            if (hit.collider.name == "PotionFourteen")             // Potion
            {
                inventory.RemainingPotion++;
                potionFourteen.SetActive(false);
                potionIcon.SetActive(true);
            }

            if (hit.collider.name == "PotionFifthteen")             // Potion
            {
                inventory.RemainingPotion++;
                potionFifthteen.SetActive(false);
                potionIcon.SetActive(true);
            }

            if (hit.collider.name == "PotionSixteen")             // Potion
            {
                inventory.RemainingPotion++;
                potionSixteen.SetActive(false);
                potionIcon.SetActive(true);
            }

            if (hit.collider.name == "PotionSeventeen")             // Potion
            {
                inventory.RemainingPotion++;
                potionSeventeen.SetActive(false);
                potionIcon.SetActive(true);
            }

            if (hit.collider.name == "PotionEighteen")             // Potion
            {
                inventory.RemainingPotion++;
                potionEightteen.SetActive(false);
                potionIcon.SetActive(true);
            }

            if (hit.collider.name == "PotionNineteen")             // Potion
            {
                inventory.RemainingPotion++;
                potionNineteen.SetActive(false);
                potionIcon.SetActive(true);
            }

            if (hit.collider.name == "PotionTwenty")             // Potion
            {
                inventory.RemainingPotion++;
                potionTwenty.SetActive(false);
                potionIcon.SetActive(true);
            }

            if (hit.collider.name == "Helm Slot" && hasHelm == false && canPressE == true)              // Helm false
            {
                CantPressE();
                Invoke("CanPressE", 3f);
                playerSubAnim.SetBool("isSub", true);
                GameManager.instance.playerSub.text = "My boat's helm is missing. I need to get it back.";
                Invoke("ClearSub", 3f);
            }

            else if (hit.collider.name == "Helm Slot" && hasHelm == true && canPressE == true && inventory.isHelmEquipped == false)         // Helm True
            {
                CantPressE();
                Invoke("CanPressE", 3f);
                playerSubAnim.SetBool("isSub", true);
                GameManager.instance.playerSub.text = "I need to equip the Helm.";
                Invoke("ClearSub", 3f);
            }

            else if (hit.collider.name == "Helm Slot" && hasHelm == true && canPressE == true && inventory.isHelmEquipped == true)         // Helm True
            {
                SceneManager.LoadScene("SceneTwo");
            }

            if (hit.collider.name == "Helm")                                // Got Helm
            {
                lastEnemies.SetActive(true);
                lastCheckpoint.SetActive(true);
                GameManager.instance.objectiveText.text = "Get back to the boat.";
                helmIcon.SetActive(true);
                Invoke("CanPressE", 3f);
                playerSubAnim.SetBool("isSub", true);
                GameManager.instance.playerSub.text = "My boat's helm!!! I need to get back to my boat.";
                Invoke("ClearSub", 3f);
                Helm.SetActive(false);
                hasHelm = true;
            }

            if (hit.collider.name == "Bridge Wall" && hasChainsaw == false && canPressE == true)         //Bridge Wall   
            {
                CantPressE();
                Invoke("CanPressE", 3f);
                playerSubAnim.SetBool("isSub", true);
                GameManager.instance.playerSub.text = "I need to get rid of this blockage. An axe or a chainsaw might do the job.";
                Invoke("ClearSub", 3f);
            }

            else if (hit.collider.name == "Bridge Wall" && hasChainsaw == true && inventory.isChainsawEquipped == false && canPressE == true)         //Bridge Wall   
            {
                CantPressE();
                Invoke("CanPressE", 3f);
                playerSubAnim.SetBool("isSub", true);
                GameManager.instance.playerSub.text = "I need to equip the chainsaw.";
                Invoke("ClearSub", 2.5f);
            }

            else if (hit.collider.name == "Bridge Wall" && hasChainsaw == true && inventory.isChainsawEquipped == true && canPressE == true)         //Bridge Wall   
            {
                GameManager.instance.objectiveText.text = "Look for the boat's helm.";
                CantPressE();
                Invoke("CanPressE", 3f);
                PlayerSubAnimation();
                GameManager.instance.playerSub.text = "Great! I can pass the bridge now.";
                Invoke("ClearSub", 3f);
                hasChainsaw = false;
                Blockage.SetActive(false);
                inventory.chainsawInHand.SetActive(false);
                chainsawIcon.SetActive(false);
                inventory.equipped.text = "-";
            }

            if (hit.collider.name == "Chainsaw" && canPressE == true)                                    //Chainsaw
            {
                GameManager.instance.objectiveText.text = "Clear the bridge blockage with the chainsaw.";
                CantPressE();
                Invoke("CanPressE", 3f);
                PlayerSubAnimation();
                GameManager.instance.playerSub.text = "Hell yeah!";
                Invoke("ClearSub", 2f);
                hasChainsaw = true;
                chainsawIcon.SetActive(true);
                chainsaw.SetActive(false);
            }

            if (hit.collider.name == "Francis" && firstTalkDone == false && canPressE == true)
            {
                showPressE = false;
                pressE.text = "";
                canPressE = false;
                francisTalk = true;
                playerScript.GamePaused();
                NPCSubAnim.SetBool("isSub", true);
                NPCSub.text = "Hey there, stranger. My name is Francis.I Haven't seen your face around these parts. What brings you here?";
            }

            if (hit.collider.name == "Francisco" && franciscoFirstTalkDone == false && canPressE == true)
            {
                showPressE = false;
                pressE.text = "";
                franciscoTalk = true;
                canPressE = false;
                playerScript.GamePaused();
                NPCSubAnim.SetBool("isSub", true);
                NPCSub.text = "To get past this gate, you must tell me the password.";
            }

            if (hit.collider.name == "Francisco" && franciscoFirstTalkDone == true && hasPasscode == true && canPressE == true)
            {
                showPressE = false;
                pressE.text = "";
                franciscoTalk = true;
                canPressE = false;
                playerScript.GamePaused();
                NPCSubAnim.SetBool("isSub", true);
                NPCSub.text = "So, you got the password now?";
            }
        }
    }
    public void CrosshairIcon()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3f, layerMask))
        {
            if (showPressE == true)
            {
                pressE.text = "Press E to Interact";
            }
            else
            {
                pressE.text = "";
            }
            
            crosshair.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            if (hit.collider.name == "Francis" && francisTalk == true)
            {
                if (Input.GetKeyDown(KeyCode.Space) && francis == 1)
                {
                    NPCSub.text = "Oh I see, so you are looking for your boat's helm?";
                    francis++;
                }
                else if (Input.GetKeyDown(KeyCode.Space) && francis == 2)
                {
                    NPCSub.text = "You'll need to get past this bridge. But you'll need to get rid of this trees first.";
                    francis++;

                }
                else if (Input.GetKeyDown(KeyCode.Space) && francis == 3)
                {
                    NPCSub.text = "There's a chainsaw in the north past the village, I can't go there because I'm too afraid to fight those bastards.";
                    francis++;

                }
                else if (Input.GetKeyDown(KeyCode.Space) && francis == 4)
                {
                    NPCSub.text = "They're also the ones who took your boat's helm. They are weird as hell, becareful!";
                    francis++;
                }

                else if (Input.GetKeyDown(KeyCode.Space) && francis == 5)
                {
                    NPCSub.text = "I've got a twin who's keeping the gates shut up north,  and the code to pass the gate is '27 Inch Gaming Monitor'";
                    francis++;
                }
                else if (Input.GetKeyDown(KeyCode.Space) && francis == 6)
                {
                    francis++;
                    firstTalkDone = true;
                    NPCSub.text = "Here's a machete. Please get rid of those bastards too, thanks!";
                }
                else if (Input.GetKeyDown(KeyCode.Space) && francis == 7)
                {
                    GameManager.instance.objectiveText.text = "Look for francis's twin up north.";
                    macheteIcon.SetActive(true);
                    hasMachete = true;
                    hasPasscode = true;
                    canPressE = true;
                    playerScript.GameRunning();
                    NPCClearSub();
                    FrancisGO.SetActive(false);
                    showPressE = true;
                }

            }

            if (hit.collider.name == "Francisco" && franciscoTalk == true && hasPasscode == false)
            {
                if (Input.GetKeyDown(KeyCode.Space) && francisco == 1)
                {
                    NPCClearSub();
                    francisco++;
                    PlayerSubAnimation();
                    playerSub.text = "Code? what code?";
                }

                else if (Input.GetKeyDown(KeyCode.Space) && francisco == 2)
                {
                    NPCSubAnimation();
                    NPCSub.text = "If you don't know the password, get out of here. There are dangerous people on the other side.";
                    ClearSub();
                    francisco++;
                    GameManager.instance.objectiveText.text = "Look for the gate's password.";
                }

                else if (Input.GetKeyDown(KeyCode.Space) && francisco == 3)
                {
                    franciscoTalk = false;
                    NPCClearSub();
                    canPressE = true;
                    playerScript.GameRunning();
                    francisco++;
                    franciscoFirstTalkDone = true;
                    showPressE = true;
                }
            }

            if (hit.collider.name == "Francisco" && franciscoTalk ==  true && hasPasscode == true)
            {
                if (Input.GetKeyDown(KeyCode.Space) && francisco == 1)
                {
                    NPCClearSub();
                    PlayerSubAnimation();
                    playerSub.text = "Yeah, it's 27 Inch Gaming Monitor.";
                    francisco++;
                }

                else if (Input.GetKeyDown(KeyCode.Space) && francisco == 2)
                {
                    ClearSub();
                    NPCSubAnimation();
                    NPCSub.text = "Correct, you may pass now.";
                    francisco++;
                }

                else if (Input.GetKeyDown(KeyCode.Space) && francisco == 3)
                {
                    GameManager.instance.objectiveText.text = "Find the chainsaw.";
                    NPCClearSub();
                    canPressE = true;
                    playerScript.GameRunning();
                    FranciscoGO.SetActive(false);
                    gateOne.SetBool("isOpen", true);
                    showPressE = true;
                }

                if (Input.GetKeyDown(KeyCode.Space) && francisco == 4)
                {
                    NPCClearSub();
                    PlayerSubAnimation();
                    playerSub.text = "Yeah, it's 27 Inch Gaming Monitor.";
                    francisco++;
                }

                else if (Input.GetKeyDown(KeyCode.Space) && francisco == 5)
                {
                    ClearSub();
                    NPCSubAnimation();
                    NPCSub.text = "Correct, you may pass now.";
                    francisco++;
                }

                else if (Input.GetKeyDown(KeyCode.Space) && francisco == 6)
                {
                    GameManager.instance.objectiveText.text = "Find the chainsaw.";
                    NPCClearSub();
                    canPressE = true;
                    playerScript.GameRunning();
                    francisco++;
                    FranciscoGO.SetActive(false);
                    gateOne.SetBool("isOpen", true);
                    showPressE = true;
                }
            }
        }

        else
        {
            pressE.text = "";
            crosshair.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

    public void ClearSub()
    {
        playerSubAnim.SetBool("isSub", false);
        playerSub.text = "";
    }
    public void PlayerSubAnimation()
    {
        playerSubAnim.SetBool("isSub", true);
    }
    public void NPCSubAnimation()
    {
        NPCSubAnim.SetBool("isSub", true);
    }

    public void NPCClearSub()
    {
        NPCSubAnim.SetBool("isSub", false);
        NPCSub.text = "";
    }

    public void FirstLine()
    {
        playerSubAnim.SetBool("isSub", true);
        playerSub.text = "My head hurts..";
    }
    
    public void CanPressE()
    {
        showPressE = true;
        canPressE = true;
    }

    public void CantPressE()
    {
        showPressE = false;
        canPressE = false;
    }
}
