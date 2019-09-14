using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public class BlockDestroy : MonoBehaviour
{
    public float waiting = 0.02f;

    // this is destroy script 
    private void OnTriggerEnter(Collider other)
    {
        transform.GetComponent<Collider>().isTrigger = false;
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("collison with dead block start");
            float XPos = this.transform.position.x;
            float YPos = this.transform.position.y;
            float ZPos = this.transform.position.z;
            this.transform.position = new Vector3(XPos, YPos + 0.1f, ZPos);
            StartCoroutine(Load(waiting, new Vector3(XPos, YPos + 0.2f, ZPos)));
            StartCoroutine(Load(waiting, false));
            StartCoroutine(Load(waiting, new Vector3(XPos, YPos + 0.3f, ZPos + 0.5f)));
            StartCoroutine(Load(waiting, new Vector3(XPos, YPos + 0.4f, ZPos + 1.0f)));
            StartCoroutine(Load(waiting, new Vector3(XPos, YPos - 0.1f, ZPos + 1.5f)));
            StartCoroutine(Load(waiting, new Vector3(XPos, YPos - 0.6f, ZPos + 2.0f)));
            StartCoroutine(Load(waiting, new Vector3(XPos, YPos - 1.6f, ZPos + 2.0f)));
            StartCoroutine(Load(waiting, new Vector3(XPos, YPos - 2.6f, ZPos + 2.0f)));
            StartCoroutine(Load(waiting, new Vector3(XPos, YPos - 4.0f, ZPos + 2.0f)));
            StartCoroutine(Load(0.25f, true));
            StartCoroutine(Load(0.001f, Destroy));

            Debug.Log("collison with dead block");
        }
    }

    public void BlockDown(Vector3 newPos)
    {
        this.transform.position = newPos;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    IEnumerator Load(float delay, bool isTrigger)
    {
        Debug.Log("start");
        yield return new WaitForSeconds(delay);
        transform.GetComponent<Collider>().isTrigger = isTrigger;
        Debug.Log("end");
    }

    IEnumerator Load(float delay, Vector3 newPos)
    {
        Debug.Log("start");
        yield return new WaitForSeconds(delay);
        this.transform.position = newPos;
        Debug.Log("end");
    }

    IEnumerator Load(float delay, System.Action action)
    {
        Debug.Log("start");
        yield return new WaitForSeconds(delay);
        action();
        Debug.Log("end");
    }

}
