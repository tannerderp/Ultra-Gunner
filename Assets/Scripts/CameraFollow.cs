using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player; //transform component of the player

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, 0, -10);
    }
}
