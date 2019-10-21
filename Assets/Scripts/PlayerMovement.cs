using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpVel;
    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject gun;

    public float health = 100;
    float direction = 1f;

    Rigidbody2D rigidBody;
    BoxCollider2D boxCollider;
    Gun gunScript;
    Lives livesScript;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        gunScript = gun.GetComponent<Gun>();
        livesScript = FindObjectOfType<Lives>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        UpdateLivesHealth();
    }

    private void Movement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var rawHorizontal = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(horizontal * moveSpeed, rigidBody.velocity.y);

        if(IsGrounded() && (Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W)))
        {
            rigidBody.velocity = Vector2.up * jumpVel;
            animator.SetBool("IsJumping", true);
        }

        if(IsGrounded())
        {
            animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }
 
        if(rawHorizontal != 0)
        {
            direction = rawHorizontal;
        }
        gunScript.playerDirection = direction;
        var absoluteValue = Mathf.Abs(transform.localScale.x);
        var change = absoluteValue * direction;
        transform.localScale = new Vector2(change, transform.localScale.y);
        gun.transform.localScale = new Vector2(Mathf.Abs(gun.transform.localScale.x)*direction, gun.transform.localScale.y);
        animator.SetFloat("Speed", Mathf.Abs(horizontal*moveSpeed));
    }

    private bool IsGrounded()
    {
        RaycastHit2D boxCast = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 1f, layerMask);
        return boxCast.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D collision) //get hit by alien bullets
    {
        if (collision.name == "Alien Bullet(Clone)")
        {
            health -= 5;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "player alien collider thing")
        {
            health -= 5;
        }
    }

    public void UpdateLivesHealth() //update the health variable in the lives game object
    {
        livesScript.playerHealth = health;
        if(health < 1)
        {
            livesScript.lives--;
            if (livesScript.lives < 1)
            {
                FindObjectOfType<DontDestroy>().Reset();
                FindObjectOfType<LevelExit>().LoadGameOver();
                health = 100;
            }
            else
            {
                FindObjectOfType<LevelExit>().ReloadScene();
                health = 100;
            }
        }
    }

}
