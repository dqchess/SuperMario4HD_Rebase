using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalLives : MonoBehaviour
{
    public GameObject lifeTag;
    public int internalLife;

    public static int lifeCount = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        internalLife = lifeCount;
        lifeTag.GetComponent<Text>().text = "Lives: " + lifeCount;
    }
}
