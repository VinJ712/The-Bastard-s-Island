using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("ScriptReferences")]
    public PlayerScript playerScript;
    public Crosshair crosshair;

    [Header("Inventory")]
    public Transform indicatorPos;
    public Transform firstPos;
    public Transform secondPos;
    public Transform thirdPos;
    public Transform fourthPos;
    public Transform fifthPos;

    [Header("Objects")]
    public GameObject chainsawInHand;
    public GameObject macheteInHand;
    public GameObject helmInHand;
    public GameObject potionInHand;

    [Header("EquippedText")]
    public TextMeshProUGUI equipped;

    [Header("Is Equipped?")]
    public bool isChainsawEquipped = false;
    public bool isPotionEquipped = false;
    public bool isHelmEquipped = false;

    [Header("MacheteAnim")]
    public Animator macheteAnim;
    public bool canAttack = false;
    public GameObject macheteCollider;

    [Header("Potion")]
    public Animator healthPlusAnim;
    public int RemainingPotion = 0;
    public float potionHealAmount = 35;
    public TextMeshProUGUI potionQty;
    public GameObject potionQtyBG;
    public bool healCD = false;


    private void Start()
    {
        playerScript = FindObjectOfType<PlayerScript>();
        crosshair = FindObjectOfType<Crosshair>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack == true)
        {
            canAttack = false;
            Debug.Log("Attack!");
            macheteAnim.SetBool("isAttacking", true);
            Invoke("CanAttack", 0.1f);
            Invoke("AttackIdle", 0.5f);
            Invoke("CantAttack", 0.2f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))               //Hand
        {
            isHelmEquipped = false;
            isPotionEquipped = false;
            isChainsawEquipped = false;
            indicatorPos.position = firstPos.position;
            chainsawInHand.SetActive(false);
            equipped.text = "Hand";
            macheteInHand.SetActive(false);
            canAttack = false;
            potionInHand.SetActive(false);
            helmInHand.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))               //Machete
        {
            isHelmEquipped = false;
            isPotionEquipped = false;
            equipped.text = "-";
            isChainsawEquipped = false;
            indicatorPos.position = secondPos.position;
            chainsawInHand.SetActive(false);
            potionInHand.SetActive(false);
            helmInHand.SetActive(false);
            if (crosshair.hasMachete == true)
            {
                equipped.text = "Machete";
                macheteInHand.SetActive(true);
                canAttack = true;
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))               //Chainsaw
        {
            isHelmEquipped = false;
            isPotionEquipped = false;
            equipped.text = "-";
            indicatorPos.position = thirdPos.position;
            macheteInHand.SetActive(false);
            canAttack = false;
            potionInHand.SetActive(false);
            helmInHand.SetActive(false);
            if (crosshair.hasChainsaw == true)
            {
                isChainsawEquipped = true;
                equipped.text = "Chainsaw";
                chainsawInHand.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))               //Helm
        {
            isPotionEquipped = false;
            equipped.text = "-";
            isChainsawEquipped = false;
            indicatorPos.position = fourthPos.position;
            chainsawInHand.SetActive(false);
            macheteInHand.SetActive(false);
            canAttack = false;
            potionInHand.SetActive(false);
            if(crosshair.hasHelm == true)
            {
                isHelmEquipped = true;
                equipped.text = "Helm";
                helmInHand.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))               //Potion
        {
            helmInHand.SetActive(false);
            isHelmEquipped = false;
            isPotionEquipped = true;
            equipped.text = "-";
            isChainsawEquipped = false;
            indicatorPos.position = fifthPos.position;
            chainsawInHand.SetActive(false);
            macheteInHand.SetActive(false);
            canAttack = false;

            if (RemainingPotion > 0)
            {
                equipped.text = "HP Potion";
                potionInHand.SetActive(true);
            }
            else if (RemainingPotion <= 0)
            {
                equipped.text = "-";
                potionInHand.SetActive(false);
                crosshair.potionIcon.SetActive(false);
                
            }
        }

        if (Input.GetMouseButtonDown(0) && isPotionEquipped == true && playerScript.playersHealth < 100 && RemainingPotion > 0 && healCD == false)     //Potion
        {
            healthPlusAnim.SetBool("isHealing", true);
            Invoke("HPAnimIdle", 2f);
            healCD = true;
            Invoke("HealCD", 2f);
;           Debug.Log("Potion -1");
            RemainingPotion--;
            playerScript.playersHealth += potionHealAmount;
            if(RemainingPotion <= 0)
            {
                potionInHand.SetActive(false);
                crosshair.potionIcon.SetActive(false);
                isPotionEquipped = false;
                equipped.text = "-";
            }
        }

        else if (Input.GetMouseButtonDown(0) && isPotionEquipped == true && RemainingPotion <= 0)
        {
            Debug.Log("Not Enough Potion");
        }

        if (RemainingPotion > 0)
        {
            potionQty.text = RemainingPotion.ToString();
            potionQtyBG.SetActive(true);
        }
        else if (RemainingPotion <= 0)
        {
            potionQtyBG.SetActive(false);
        }
    }

    void HealCD()
    {
        healCD = false;
    } 

    void HPAnimIdle()
    {
        healthPlusAnim.SetBool("isHealing", false);
    }

    void CanAttack()
    {
        macheteCollider.SetActive(true);
    }
    void CantAttack()
    {
        macheteCollider.SetActive(false);
    }

    public void AttackIdle()
    {
        canAttack = true;
        macheteAnim.SetBool("isAttacking", false);
    }

}
