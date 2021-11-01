﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(3);
        }
    }
}
