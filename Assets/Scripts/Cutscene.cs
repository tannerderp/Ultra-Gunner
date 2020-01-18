using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public double time;
    public double currentTime;

    private int wait = 0;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        wait++;
        if(wait == 80)
        {
            time = GetComponent<VideoPlayer>().frameCount/30 + 0.7;
            Debug.Log(time);
        }
        if (wait > 80)
        {
            currentTime = GetComponent<VideoPlayer>().time;
            if (currentTime > time - 0.7)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
