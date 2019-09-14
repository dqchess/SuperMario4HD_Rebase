using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level01_Preload : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Preload());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Preload()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(1);
    }
}
