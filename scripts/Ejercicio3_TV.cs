using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Ejercicio3_TV : MonoBehaviour
{
    private Material tvMaterial;
    private WebCamTexture webcamTexture;
    private string savePath;
    private int captureCounter = 1;

    void Start()
    {
        tvMaterial = GetComponent<Renderer>().material;
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length > 0) {
            webcamTexture = new WebCamTexture(devices[0].name);
            Debug.Log("Cámara seleccionada: " + webcamTexture.deviceName);
        } else {
            Debug.LogWarning("No se encontró ninguna cámara conectada.");
        }
        savePath = Application.dataPath + "/Capturas/";
        if (!Directory.Exists(savePath)) {
            Directory.CreateDirectory(savePath);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) {
            tvMaterial.mainTexture = webcamTexture;
            webcamTexture.Play();
            Debug.Log("Cámara iniciada.");
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            webcamTexture.Pause(); 
            Debug.Log("Cámara pausada.");
        }
        
        if (Input.GetKeyDown(KeyCode.X)) {
            if (webcamTexture.isPlaying) {
                Texture2D snapshot = new Texture2D(webcamTexture.width, webcamTexture.height);
                snapshot.SetPixels(webcamTexture.GetPixels());
                snapshot.Apply();

                string fullPath = savePath + "captura_" + captureCounter.ToString() + ".png";
                File.WriteAllBytes(fullPath, snapshot.EncodeToPNG());
    
                Debug.Log("Fotograma guardado en: " + fullPath);
                captureCounter++;
            }
        }
    }
}
