using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player; //transform component of the player
    [SerializeField] bool followVertical = false; //whether the camera follows the player vertically or not

    private float cameraY = 0;

    // Update is called once per frame
    void Update()
    {
        if (followVertical == true && player.position.y>0)
        {
            cameraY = player.position.y;
        }
        else
        {
            cameraY = 0;
        }
        transform.position = new Vector3(player.position.x, cameraY, -10);
    }
}
