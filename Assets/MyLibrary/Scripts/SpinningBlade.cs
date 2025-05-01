using UnityEngine;

public class SpinningBlade : MonoBehaviour
{
   public float speed = 100f;

    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit by trap!");
        }
    }
}
