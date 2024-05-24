using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    
    [Header("ScriptReferences")]
    public PlayerScript playerScript;
    public LayerMask enemyLayermask;

    [Header("EnemyStats")]
    public float enemyHP;
    public float maxHP;
    public Image enemyHPBar;
    public TextMeshProUGUI enemyHPText;
    public Transform enemyRangePos;
    public Transform enemyPrefabPos;

    public GameObject enemyParentUI;
    public GameObject enemyParentParent;

    [Header("Machetes Damage")]
    public float macheteDmg;

    [Header("Enemy Stats")]
    public float enemyDmg;
    public Animator enemyAnim;
    public bool isEnemyAttacking;

    private void Start()
    {
        playerScript = FindObjectOfType<PlayerScript>();
    }

    private void Update()
    {
        CrosshairIcon();
        enemyHPBar.fillAmount = enemyHP / maxHP;
        if (enemyHP > maxHP) enemyHP = maxHP;
        enemyRangePos.position = enemyPrefabPos.position;
        if (enemyHP <= 0)
        {
            Debug.Log("'Destroyed'");
            Destroy(enemyParentParent.gameObject);
        }
    }

    public void OnTriggerEnter(Collider actor)
    {
        if (actor.gameObject.CompareTag("Machete") && enemyHP >= 0)
        {
            Debug.Log("Enemy HP: " + enemyHP);
            enemyHP -= macheteDmg;
            enemyHPText.text = enemyHP.ToString();
        }

        if (actor.gameObject.CompareTag("Player"))
        {
            isEnemyAttacking = true;
            enemyAnim.SetBool("isAttacking", true);
            Invoke("IsNotAttacking", 1.6f);
            Invoke("DamagePlayer", 0.5f);
            Debug.Log("Players HP: " + playerScript.playersHealth);
        }
    }

    public void CrosshairIcon()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 20f, enemyLayermask))
        {
            if (hit.transform.GetComponent<Enemy>())
            {
                hit.transform.GetComponent<Enemy>().enemyParentUI.SetActive(true);
            }
        }
        else
        {
            enemyParentUI.SetActive(false);
        }
    }
    void IsNotAttacking()
    {
        isEnemyAttacking = false;
        if (enemyAnim != null)
        {
            enemyAnim.SetBool("isAttacking", false);
        }
    }

    void DamagePlayer()
    {
        playerScript.playersHealth -= enemyDmg;
    }

}
