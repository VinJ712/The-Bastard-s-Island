using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public Transform lastCheckpoint;
    public Animator checkpointDone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            checkpointDone.SetBool("isCheckpointDone", true);
            Invoke("CheckpointFalse", 4f);
            lastCheckpoint.position = transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            checkpointDone.SetBool("isCheckpointDone", false);
            Destroy(this.gameObject);
        }
    }

    void CheckpointFalse()
    {
        checkpointDone.SetBool("isCheckpointDone", false);
    }
}
