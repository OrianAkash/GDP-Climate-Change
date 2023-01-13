using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Movement : MonoBehaviour
{
    public AudioSource collectsound;
    public AudioSource dashsound;
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
    int itemValue = 1;

    public bool canDash = true;
    public bool isDashing;
    public float dashingPower = 24f;
    private float dashingTime = 0.2f;
    public float dashingCooldown = 5f;
    public TrailRenderer tr;

    public bool facingright;


    private bool moveLeft;
    private bool moveRight;
    private float horizontalMove;


    private enum MoveState {idle, running, jumping };
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        inventext.text = null;
        playerAnim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        moveLeft = false;
        moveRight = false;
        facingright = true;
    }

    

    public IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = body.gravityScale;
        body.gravityScale = 0f;
        if (facingright==true)
        {
            
            body.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        }

        if (facingright==false)
        {
            body.velocity = new Vector2(transform.localScale.x * -dashingPower, 0f);
        }

        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        body.gravityScale = 2f;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    public void PointerDownLeft()
    {
        moveLeft = true;
        facingright = false;
    }

    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    public void PointerDownRight()
    {
        moveRight = true;
        facingright = true;
    }

    public void PointerUpRight()
    {
        moveRight = false;
    }
    private void Update()
    {
        if(isDashing)
        {
            return;
        }

        if (!interacting)
        {
            MovePlayer();
        }
        UpdateAnim();

        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }
    private void MovePlayer()
    {
        if (moveLeft)
        {
            horizontalMove = -speed;
        }
        else if (moveRight)
        {
            horizontalMove = speed;
        }
        else
        {
            horizontalMove = 0;
        }
    }
    public void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        body.velocity = new Vector2(horizontalMove, body.velocity.y);
    }

    private void UpdateAnim()
    {
        MoveState state;

        if(horizontalMove > 0f)
        {
            state = MoveState.running;
            sprite.flipX = false; 
        }
        else if (horizontalMove < 0f)
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

    public void Jump()
    {
        if (Time.time >= nextjumpTime)
        {
                body.velocity = new Vector2(body.velocity.x, jump_height);
                grounded = false;
                nextjumpTime = Time.time + 6f / jumpRate;
        }

    }

    public void dashMove()
    {
        if (isDashing)
        {
            return;
        }
        if (canDash)
        {
            dashsound.Play();
            StartCoroutine(Dash());
        }
        
    }

    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (inventryfill == false && other.gameObject.CompareTag("Plastic"))
        {
            collectsound.Play();
            inventryfill = true;
            inventory = other.transform.tag;
            inventext.text = inventory;
            Destroy(other.gameObject);
        }
        if (inventryfill == false && other.gameObject.CompareTag("Metal"))
        {
            collectsound.Play();
            inventryfill = true;
            inventory = other.transform.tag;
            inventext.text = inventory;
            Destroy(other.gameObject);
        }
        if (inventryfill == false && other.gameObject.CompareTag("Paper"))
        {
            collectsound.Play();
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
