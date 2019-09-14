using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public class BlockNonDestroy : MonoBehaviour
{
    public Vector3 blockPos;
    public float jitterDistance = 0.2f;
    public AudioSource blockBump;

    // this is "bobbing" script 
    private void OnTriggerEnter(Collider other)
    {
        transform.GetComponent<Collider>().isTrigger = false;
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("collison with dead block start");
            blockBump.Play();
            this.transform.Translate(Vector3.up * jitterDistance);
            StartCoroutine(Load(0.15f, BlockDown));
            StartCoroutine(Load(0.25f));

            Debug.Log("collison with dead block");
        }
    }

    public void BlockDown()
    {
        this.transform.Translate(Vector3.down * jitterDistance);
    }

    IEnumerator Load(float delay)
    {
        yield return new WaitForSeconds(delay);
        transform.GetComponent<Collider>().isTrigger = true;
    }

    IEnumerator Load(float delay, System.Action action)
    {
        yield return new WaitForSeconds(delay);
        action();
    }
}
