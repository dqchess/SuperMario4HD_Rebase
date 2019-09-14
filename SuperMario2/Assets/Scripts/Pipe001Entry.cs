using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe001Entry : MonoBehaviour
{
    public GameObject pipeEntry;
    public GameObject player;
    public GameObject mainCam;
    public GameObject secondCam;
    public GameObject fadeScreen;
    public AudioSource pipeSound;
    public Vector3 endPos = new Vector3(14.5f, 0.17f, -0.5f);


    // Start is called before the first frame update
    void Start()
    {
        pipeEntry.GetComponent<Animator>().enabled = false;
        fadeScreen.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("into collider");
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        Debug.Log("into load");
        pipeSound.Play();
        fadeScreen.SetActive(true);
        fadeScreen.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(0.495f);
        fadeScreen.GetComponent<Animator>().enabled = false;
        mainCam.SetActive(true);
        secondCam.SetActive(false);
        player.transform.position = endPos;
        pipeEntry.GetComponent<Animator>().enabled = true;
        fadeScreen.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(0.495f);
        fadeScreen.GetComponent<Animator>().enabled = false;
        yield return new WaitForSeconds(0.905f);
        pipeEntry.GetComponent<Animator>().enabled = false;
        fadeScreen.SetActive(false);
    }
}
