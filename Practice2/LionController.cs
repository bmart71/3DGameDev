using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LionController : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI dialog;
    private float distance;
    void Start()
    {
        player = GameObject.Find("Dog");
    }
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 5) { 
            dialog.gameObject.SetActive(true);
        } else
        {
            dialog.gameObject.SetActive(false);
        }
        //Debug.Log("distance: " + distance);
    }
}
