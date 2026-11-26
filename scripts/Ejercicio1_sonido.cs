using UnityEngine;

public class Ejercicio1_sonido : MonoBehaviour
{
private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
         audioSource.Play();
    }
}
