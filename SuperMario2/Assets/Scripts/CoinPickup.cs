using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public AudioSource coinSound; 
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
        coinSound.Play();
        transform.position = new Vector3(0, -1000, 0);
        GlobalCoins.coinCount += 1;
    }
}
