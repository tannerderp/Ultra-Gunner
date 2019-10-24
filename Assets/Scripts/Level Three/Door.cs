using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool donkeyIsAlive = true;

    // Update is called once per frame
    void Update()
    {
        if(donkeyIsAlive == false)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.2f);
        }
    }
}
