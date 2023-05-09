using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianController : MonoBehaviour
{
    private Animator pedAnimator;
    void Start()
    {
        pedAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        if (transform.position.x < 29) { 
            transform.Translate(Vector3.forward * Time.deltaTime * 2);
            pedAnimator.SetTrigger("Go_t");
        } else
        {
            pedAnimator.SetTrigger("Stop_t");
        }
    }
}
