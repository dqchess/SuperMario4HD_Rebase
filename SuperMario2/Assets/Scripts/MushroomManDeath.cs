using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomManDeath : MonoBehaviour
{
    public GameObject mushroomMan;
    public GameObject mushroomKillPlayCollider;

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
        this.GetComponent<BoxCollider>().enabled = false;
        mushroomKillPlayCollider.GetComponent<Level01_Death>().enabled = false;
        mushroomMan.GetComponent<MushroomManMove>().enabled = false;
        mushroomMan.transform.localScale -= new Vector3(0, 0.7f, 0.01f);
        mushroomMan.transform.localPosition -= new Vector3(0, 0.6f, 0);
        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        yield return new WaitForSeconds(1.0f);
        mushroomMan.transform.position = new Vector3(0, -1000, 0);
    }
}
