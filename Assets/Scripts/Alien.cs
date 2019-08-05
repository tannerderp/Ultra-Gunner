﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] float bulletSpeed = -10f;
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject player;
    [SerializeField] GameObject bulletStart;

    int bulletFireCooldown = 100;

    Animator animator;
    Rigidbody2D rigidBody;

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

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bulletFireCooldown++;
        CheckCanFire();
        if(bulletFireCooldown >= 100)
        {
            HandleMovement();
        }
        else
        {
            animator.SetFloat("speed", 0);
        }
    }

    private void HandleMovement()
    {
        float direction = transform.localScale.x / Mathf.Abs(transform.localScale.x);
        rigidBody.velocity = new Vector2(direction * moveSpeed, rigidBody.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(rigidBody.velocity.x));
    }

    private void CheckCanFire() //checks if it can shoot, and does if it can. I couldn't figure out a good name
    {
        Vector2 distance = transform.position - player.transform.position;
        if(Mathf.Abs(distance.x)<7 && bulletFireCooldown > 100)
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
