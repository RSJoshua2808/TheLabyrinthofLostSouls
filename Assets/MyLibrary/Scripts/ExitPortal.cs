using UnityEngine;

public class ExitPortal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hark and Rejoice! You Have Escaped the Labyrinth of Lost Souls!");
        }
    }
}
