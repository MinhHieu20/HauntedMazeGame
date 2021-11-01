using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerPoints : MonoBehaviour
{
    public static PlayerPoints instance;
    public Text countText, hightScoreText;
    private int count, highScore;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        count = 0;
        SetCountText();
    }

    private void SetCountText()
    {
        countText.text ="Point: " + count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    
}
