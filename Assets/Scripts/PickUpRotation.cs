using UnityEngine;

public class PickUpRotation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 100f) * Time.deltaTime);
    }
}
