using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 脚本添加在hole，注意一下管道除了PipeCollider其余都别设置collider

public class Pipe000Entry : MonoBehaviour
{
    public GameObject pipeEntry;
    public bool stoodOn = false;
    public GameObject player;
    public GameObject mainCam;
    public GameObject secondCam;
    public GameObject fadeScreen;
    public AudioSource pipeSound;
    public Vector3 endPos = new Vector3(-2.65f, -6.0f, -4.6f);

    private void OnTriggerEnter(Collider other)
    {
        stoodOn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        stoodOn = false;
    }

    void Start()
    {
        pipeEntry.GetComponent<Animator>().enabled = false;
        fadeScreen.GetComponent<Animator>().enabled = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("GoDown"))
        {
            if(stoodOn)
            {
                //player.transform.position = new Vector3(-2.5f, -4.0f, 0.0f);
                //transform.position = new Vector3(0, -1000, 0);
                //gameObject.GetComponent<Collider>().isTrigger = true;
                WaitingForPipe();
            }
        }
    }

    void WaitingForPipe()
    {
        pipeEntry.GetComponent<Animator>().enabled = true;
        Debug.Log("start animation");
        StartCoroutine(Load(1.5f));
    }

    IEnumerator Load(float delay)
    {
        pipeSound.Play();
        fadeScreen.SetActive(true);
        yield return new WaitForSeconds(delay);
        Debug.Log("end animation");
        fadeScreen.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(0.495f);
        fadeScreen.GetComponent<Animator>().enabled = false;
        pipeEntry.GetComponent<Animator>().enabled = false;
        mainCam.SetActive(false);
        secondCam.SetActive(true);
        player.transform.position = endPos;
        fadeScreen.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(0.495f);
        fadeScreen.GetComponent<Animator>().enabled = false;
        fadeScreen.SetActive(false);
    }
}
