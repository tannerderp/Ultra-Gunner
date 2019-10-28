using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fall collider")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } 
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
        Cursor.visible = true;
    }

    public void LoadTheEnd()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("TheEnd");
    }
}
