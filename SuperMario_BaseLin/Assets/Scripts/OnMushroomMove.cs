using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMushroomMove : MonoBehaviour
{
    public GameObject actualMushroom;
    public GameObject thisMushroom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent = null;
        transform.Translate(Vector3.up * 2 * Time.deltaTime, Space.World);
        StartCoroutine(CloseAnim());
    }
    IEnumerator CloseAnim()
    {
        yield return new WaitForSeconds(0.5f);
        thisMushroom.SetActive(false);
        actualMushroom.SetActive(true);
    }

}
