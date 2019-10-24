using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonkeyNuetron : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    BoxCollider2D boxCollider;
    Rigidbody2D rigidBody;
    Door doorScript;

    private float jumpVel = 1f;
    private float horizontalVel = 0f;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        doorScript = FindObjectOfType<Door>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsGrounded())
        {
            Jump();
        }
    }

    private void Jump()
    {
        jumpVel = Random.Range(3f, 6.5f);
        horizontalVel = Random.Range(-15f, 15f);
        rigidBody.velocity = new Vector2(horizontalVel, jumpVel);

    }

    private bool IsGrounded()
    {
        RaycastHit2D boxCast = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 1f, layerMask);
        return boxCast.collider != null;
    }
}
