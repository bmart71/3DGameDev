using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LionController : MonoBehaviour
{
    public GameObject player;
    private float distance;
    public TextMeshProUGUI dialogText;
    void Start()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
    }

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < 3)
        {
            dialogText.gameObject.SetActive(true);
        }
        else
        {
            dialogText.gameObject.SetActive(false);
        }
    }

}
