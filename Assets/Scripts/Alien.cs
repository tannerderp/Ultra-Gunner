using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] int health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "bullet(Clone)") //take damage when hit by player bullet
        {
            health--;
            if(health < 1)
            {
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
    }
}
