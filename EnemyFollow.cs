using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    [Header("Movement")]
    public NavMeshAgent enemyNavMesh;
    public Transform playerPos;
    public Transform enemyStayPos;
    public Animator enemyAnim;

    [Header("ScriptReference")]
    public Enemy enemyScript;


    private void Start()
    {
        enemyNavMesh.autoBraking = false;
        playerPos = GameObject.Find("Player").transform;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && enemyScript.isEnemyAttacking == false)
        {
            enemyNavMesh.SetDestination(playerPos.position);
            enemyAnim.SetBool("isRunning", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyNavMesh.SetDestination(enemyStayPos.position);
            enemyAnim.SetBool("isRunning", false);
        }
    }
}
