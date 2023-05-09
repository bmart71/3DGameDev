using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 3;
    public float jumpForce = 300;
    public float timeBeforeNextJump = 1.2f;
    private float canJump = 0f;
    public GameObject gm, potionPrefab, openedChest, closedChest;
    private bool PickedUpKey = false;
    public TextMeshProUGUI winText;
    Animator anim;
    Rigidbody rb;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ControllPlayer();
    }

    void ControllPlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            anim.SetInteger("Walk", 1);
        }
        else {
            anim.SetInteger("Walk", 0);
        }

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        if (Input.GetButtonDown("Jump") && Time.time > canJump)
        {
                rb.AddForce(0, jumpForce, 0);
                canJump = Time.time + timeBeforeNextJump;
                anim.SetTrigger("jump");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Potion")) {
            int lives = (int)(gm?.GetComponent<GameManager>().getLives());
            lives += 5;
            gm?.GetComponent<GameManager>().setLives(lives);
            Destroy(other.gameObject);
            Instantiate(potionPrefab, new Vector3(Random.RandomRange(-26, 26), 0.07f, Random.RandomRange(-30, 30)), potionPrefab.transform.rotation);
        } else if (other.CompareTag("Key")) {
            Destroy(other.gameObject);
            PickedUpKey = true;
        } else if (other.CompareTag("Chest")) {
            if (PickedUpKey)
            {
                closedChest.gameObject.SetActive(false);
                openedChest.gameObject.SetActive(true);
                winText.gameObject.SetActive(true);
                GetComponent<PlayerController>().enabled = false;
                gm?.GetComponent<GameManager>().StopAllCoroutines();
            }
        }
    }
}