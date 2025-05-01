using UnityEngine;

public class ExitPortal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Congratulations! You Escaped the Labyrinth of Lost Souls!");
        }
    }
}
