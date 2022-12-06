using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jump_height;
    private Rigidbody2D body;
    private float horizontalInput = 0f;
    public float jumpRate = 2f;
    float nextjumpTime = 0f;
    public bool grounded;
    private bool interacting;
    public bool inventryfill = false;
    public GameObject[] plantArea = new GameObject[3];
    public string inventory;
    public TextMeshProUGUI inventext;
    public Animator playerAnim;
    private SpriteRenderer sprite;

    private enum MoveState {idle, running, jumping };
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        inventext.text = null;
        playerAnim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {

       
        if (!interacting)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (Time.time >= nextjumpTime)
            {
                if (Input.GetKey(KeyCode.Space) && grounded)
                {
                    Jump();         
                    nextjumpTime = Time.time + 6f / jumpRate;
                }

            }
        }
        UpdateAnim();
    }

    private void UpdateAnim()
    {
        MoveState state;

        if(horizontalInput > 0f)
        {
            state = MoveState.running;
            sprite.flipX = false; 
        }
        else if (horizontalInput < 0f)
        {
            state = MoveState.running;
            sprite.flipX = true; 
        }
        else
        {
            state = MoveState.idle;
        }

        if (body.velocity.y > .1f)
        {
            state = MoveState.jumping;
        }
        playerAnim.SetInteger("state", (int)state);
    }
    public void ToggleInteraction()
    {
        interacting = !interacting;
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jump_height);  
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
            inventext.text = inventory;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Metal"))
        {
            inventryfill = true;
            inventory = other.transform.tag;
            inventext.text = inventory;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Paper"))
        {
            inventryfill = true;
            inventory = other.transform.tag;
            inventext.text = inventory;
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
