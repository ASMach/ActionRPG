using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    AudioSource audioSource;
    
    [SerializeField]
    AudioClip audioClip;
    [SerializeField]
    GameObject particle;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Renderer[] renderers = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderers)
                r.enabled = false;

            audioSource.PlayOneShot(audioClip);
            Destroy(gameObject, audioClip.length);
        }
    }
}