using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheKing : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] float moveSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -3.7)
        {
            FindObjectOfType<LevelExit>().LoadTheEnd();
        }
        transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "bullet(Clone)")
        {
            health--;
            Destroy(collision.gameObject);
            if(health < 50)
            {
                GetComponentInChildren<AimingAlienArm>().timeBetweenBullet = 50f;
            }
            if(health < 25)
            {
                GetComponentInChildren<AimingAlienArm>().timeBetweenBullet = 25f;
            }
        }
        if(health < 1)
        {
            Destroy(GetComponentInChildren<AimingAlienArm>());
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        if (collision.gameObject.tag == "King Flipper")
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            var gunTransform = GetComponentInChildren<Transform>();
            GetComponentInChildren<Transform>().localScale = new Vector3(gunTransform.localScale.x*-1, gunTransform.localScale.y, gunTransform.localScale.z);
            moveSpeed *= -1f;
        }
    }

}
