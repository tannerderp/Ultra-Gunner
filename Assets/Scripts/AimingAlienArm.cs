using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingAlienArm : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject player;

    [SerializeField] float timeBetweenBullet = 100f;

    private Vector3 target;
    private int bulletFireCooldown = 0;
    private float rotationZ;
    private float bulletSpeed = 2;
    private Vector2 difference;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletFireCooldown++;
        target = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        difference = target - transform.position;
        rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        CheckCanFire();
    }

    private void CheckCanFire()
    {
        Vector2 distance = transform.position - player.transform.position;
        if (Mathf.Abs(distance.x)<9&& bulletFireCooldown > timeBetweenBullet)
        {
            FireBullet(difference, rotationZ);
            bulletFireCooldown = 0;
        }
    }

    private void FireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        Debug.Log(b.transform.rotation.z);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
