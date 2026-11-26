using UnityEngine;

public class Ejercicio2_Altavoces : MonoBehaviour
{
private AudioSource audioSource;
    private string microfonoSeleccionado;

    void Start()
    {
        // Recuperar el componente AudioSource de los altavoces
        audioSource = GetComponent<AudioSource>();

        // 2. Comprobar qué micrófonos hay conectados
        if (Microphone.devices.Length > 0) {
            // Coger el primer micrófono disponible
            microfonoSeleccionado = Microphone.devices[0];
            Debug.Log("Micrófono detectado: " + microfonoSeleccionado);
        } else {
            Debug.Log("No se ha encontrado ningún micrófono.");
        }
    }

    void Update()
    {
        // Condición 1
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("Grabando micrófono...");
            // Grabar 10 segundos en bucle a 44100 Hz
            audioSource.clip = Microphone.Start(microfonoSeleccionado, true, 15, 44100);
        }
        // Condición 2
        if (Input.GetKeyUp(KeyCode.R)) {
            Debug.Log("Grabación detenida.");
            Microphone.End(microfonoSeleccionado);
            audioSource.Play();
        }
    }
}

