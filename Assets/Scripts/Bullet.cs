using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject); //despawn bullet when it's off screen. That way enemies don't die before you can see them.
    }
}
