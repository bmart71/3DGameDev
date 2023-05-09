using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, rotationSpeed;
    private static int maxCoins = 5;
    private int coins = 0;
    public GameObject coinPrefab;
    public GameObject gm;

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);     

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (other.CompareTag("Coin"))
        {
            coins++;
            Destroy(other.gameObject);
            if (coins < maxCoins) { 
                Instantiate(coinPrefab, new Vector3(UnityEngine.Random.Range(-29, 29), 1, UnityEngine.Random.Range(transform.position.y + 20, 180)), coinPrefab.transform.rotation);
            }
        }
        if (other.CompareTag("Ped"))
        {
            gm?.GetComponent<GameManager>().GameOver();
        }
    }

}
