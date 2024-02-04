using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (this.gameObject.tag == "Coin1")
            {
                Destroy(this.gameObject);
                //_points++;
            }
            if (this.gameObject.tag == "Coin2")
            {
                Destroy(this.gameObject);
                //_points = _points + 2;
            }
            if (this.gameObject.tag == "Coin3")
            {
                Destroy(this.gameObject);
                //_points = _points + 5;
            }
        }
    }
}
