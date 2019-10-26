using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player; //transform component of the player
    [SerializeField] bool followVertical = false; //whether the camera follows the player vertically or not
    [SerializeField] float cameraYOffset = 0f; //literally just so the player has more room to see the boss in the final boss level

    private float cameraY = 0;

    // Update is called once per frame
    void Update()
    {
        if (followVertical == true && player.position.y>0)
        {
            cameraY = player.position.y+cameraYOffset;
        }
        else
        {
            cameraY = 0;
        }
        transform.position = new Vector3(player.position.x, cameraY, -10);
    }
}
