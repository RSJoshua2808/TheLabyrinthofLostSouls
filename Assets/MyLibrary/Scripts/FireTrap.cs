using System.Collections;
using UnityEngine;
using SuperPupSystems.Helper;



public class FireTrap : MonoBehaviour
{
    public ParticleSystem fireEffect;
    public float fireInterval = 3f;
    public int damage = 1;

    private bool isActive;

    void Start()
    {
        StartCoroutine(FireRoutine());
    }

    IEnumerator FireRoutine()
    {
        while (true)
        {
            isActive = true;
            fireEffect.Play();
            yield return new WaitForSeconds(1f);
            fireEffect.Stop();
            isActive = false;
            yield return new WaitForSeconds(fireInterval);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (isActive && other.CompareTag("Player"))
        {
            // Apply damage or effects to player
            other.GetComponent<Health>().Damage(damage);
        }
    }
}


