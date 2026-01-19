using UnityEngine;

public class Sphere : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Sphere collided with " + collision.gameObject.name);
    }
}
