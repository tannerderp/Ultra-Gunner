using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] float bulletSpeed = -10f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject player;
    [SerializeField] GameObject bulletStart;

    int bulletFireCooldown = 0;

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

    private void Update()
    {
        bulletFireCooldown++;
        CheckCanFire();
    }

    private void CheckCanFire() //checks if it can shoot, and does if it can. I couldn't figure out a good name
    {
        Vector2 distance = transform.position - player.transform.position;
        if(Mathf.Abs(distance.x)<7 && bulletFireCooldown > 120)
        {
            FireBullet();
            bulletFireCooldown = 0;
        }
    }

    private void FireBullet()
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0);
    }
}
