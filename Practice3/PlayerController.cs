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
    public GameObject gm, potion;
    private int flowers = 0, catHair = 0;
    private bool canCraft = false, potionVisible = false;
    public TextMeshProUGUI winText;
    public ParticleSystem explosionParticle;
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
        if (transform.position.y < -1)
        {
            gm?.GetComponent<GameManager>().GameOver();
        }
        if (flowers == 3 && catHair == 1) {
            Debug.Log("Can Craft Potion" + catHair);
            canCraft = true;            
        }
        if (Input.GetKeyDown(KeyCode.C) && canCraft)
        {
            potion.gameObject.SetActive(true);
            potionVisible = true;
        }
        if (Input.GetKeyDown(KeyCode.X) && potionVisible) {
            winText.gameObject.SetActive(true);
            explosionParticle.Play();
        }
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
        if (other.CompareTag("Flower") && flowers < 3)
        {
            flowers++;
            Destroy(other.gameObject);
        }
    }

    public void addCatHair()
    {
        catHair++;
    }
}