using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienHealthManager : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] bool destroyParent;
    [SerializeField] GameObject parentObject;

    AudioSource hitSound;

    private void Start()
    {
        hitSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "bullet(Clone)") //take damage when hit by player bullet
        {
            health--;
            if(gameObject.tag != "Donkey Nuetron")
            {
                hitSound.Play();
            }
            if (health < 1)
            {
                if (destroyParent == true)
                {
                    Destroy(parentObject);
                }
                else
                {
                    if(gameObject.tag == "Donkey Nuetron")
                    {
                        FindObjectOfType<Door>().donkeyIsAlive = false;
                    }
                    Destroy(gameObject);
                }
            }
            Destroy(collision.gameObject);
        }
    }
}
