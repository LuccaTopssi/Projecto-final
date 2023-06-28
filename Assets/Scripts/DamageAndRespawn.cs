using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageAndRespawn : MonoBehaviour
{
    public int lives = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            lives = 0;
        }
    }
    private void Update()
    {
        if (lives == 0)
        {
            die();
        }
    }
    void die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
