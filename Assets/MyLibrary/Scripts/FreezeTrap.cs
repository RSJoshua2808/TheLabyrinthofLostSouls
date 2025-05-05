//FreezeTrap

using StarterAssets;
using UnityEngine;

public class IceFreezeTrap : MonoBehaviour
{
    [Tooltip("Seconds")]
    public float freezeDuration = 3f; // Seconds
    public ParticleSystem iceEffect;  // Assign in Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FreezePlayer(other));
        }
    }

    private System.Collections.IEnumerator FreezePlayer(Collider player)
    {
        // Optional: Play ice VFX
        if (iceEffect != null)
            iceEffect.Play();

        // Disable player movement
        ThirdPersonController movement = player.GetComponent<ThirdPersonController>();
        if (movement != null)
            movement.enabled = false;

        // Optional: play sound or animation here

        yield return new WaitForSeconds(freezeDuration);

        // Re-enable movement
        if (movement != null)
            movement.enabled = true;
    }
}
