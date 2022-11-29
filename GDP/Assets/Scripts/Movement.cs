using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jump_height;
    private Rigidbody2D body;
    //private Animator anim;
    public float jumpRate = 2f;
    float nextjumpTime = 0f;
    public bool grounded;
    private bool interacting;
    public bool inventryfill = false;
    public GameObject[] plantArea = new GameObject[3];
    public string inventory;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(!interacting)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (horizontalInput > 0.01f)
                transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            else if (horizontalInput < -0.01f)
                transform.localScale = new Vector3(-0.15f, 0.15f, 0.15f);



            if (Time.time >= nextjumpTime)
            {
                if (Input.GetKey(KeyCode.Space) && grounded)
                {
                    Jump();
                    nextjumpTime = Time.time + 6f / jumpRate;
                }


            }
        }
    }
    public void ToggleInteraction()
    {
        interacting = !interacting;
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jump_height);
        //anim.SetTrigger("Jump");
        grounded = false;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Plastic"))
        {
            inventryfill = true;
            inventory = other.transform.tag;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Metal"))
        {
            inventryfill = true;
            inventory = other.transform.tag;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Paper"))
        {
            inventryfill = true;
            inventory = other.transform.tag;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Seed"))
        {
            Destroy(other.gameObject);
            plantArea[Random.Range(0, plantArea.Length)].SetActive(true);
        }
        if (other.gameObject.CompareTag("PlantArea"))
        {
            Destroy(other.gameObject);   
        }
    }
}
