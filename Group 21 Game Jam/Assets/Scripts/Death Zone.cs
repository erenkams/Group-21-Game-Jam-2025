using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class DeathZone : MonoBehaviour
{
    private Scene _scene;



    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
        Debug.Log(_scene.name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Score.lives--;
            SceneManager.LoadScene(_scene.name);
        }




    }
}
