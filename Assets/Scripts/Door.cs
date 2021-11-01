using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(4);
        }
    }
}
