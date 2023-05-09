using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public GameObject player, tree;
    private float distance, catTreeDistance;
    private bool rotated = false , isClose = false, calledFunction = false;
    private Quaternion targetRotation;
    private Vector3 initialPosition;
    private float speed = 20;
    void Start()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        targetRotation = Quaternion.Euler(0, 170, 0) * transform.rotation;
        initialPosition = transform.position;
    }
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        //Debug.Log(distance);
        if (distance < 5)
        {
            isClose = true;
        }
        if (isClose) {
            if (!rotated)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 270.0f * Time.deltaTime);
                if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
                {
                    rotated = true;
                }
            }
            else
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, initialPosition) > 5)
                {
                    speed = 0;
                    if (!calledFunction)
                    {
                        player?.GetComponent<PlayerController>().addCatHair();
                        calledFunction = true;
                    }
                }
            }
        }
    }

}
