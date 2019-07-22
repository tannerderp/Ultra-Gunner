using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject crosshairs;
    [SerializeField] Camera camera;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletStart;

    [SerializeField] float bulletSpeed = 60.0f;

    private Vector3 target;
    public float playerDirection = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        target = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        crosshairs.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target*playerDirection - transform.position*playerDirection;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if(Input.GetMouseButtonDown(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBullet(direction*playerDirection, rotationZ+90);
        }
    }

    void fireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
