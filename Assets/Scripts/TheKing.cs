using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheKing : MonoBehaviour
{
    [SerializeField] int health = 100;

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "bullet(Clone)")
        {
            health--;
            Destroy(collision.gameObject);
            if(health < 50)
            {
                GetComponentInChildren<AimingAlienArm>().timeBetweenBullet = 75f;
            }
            if(health < 25)
            {
                GetComponentInChildren<AimingAlienArm>().timeBetweenBullet = 50f;
            }
        }
        if(health < 1)
        {
            Destroy(GetComponentInChildren<AimingAlienArm>());
            gameObject.AddComponent<Rigidbody2D>();
        }
    }
}
