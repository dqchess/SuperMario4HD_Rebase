using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBlock0 : MonoBehaviour
{
    public GameObject queBlock;
    public GameObject deadBlock;
    public GameObject mushroom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        queBlock.SetActive(false);
        deadBlock.SetActive(true);
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(0.2f);
        mushroom.SetActive(true);
    }
}
