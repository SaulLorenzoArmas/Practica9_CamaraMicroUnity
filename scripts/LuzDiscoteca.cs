using UnityEngine;

public class LuzDiscoteca : MonoBehaviour
{
    public Light luz;
    public float velocidadCambio = 0.5f; 
    public float velocidadRotacion = 60f; 
    public bool cambioSuave = false;      

    private float temporizador;
    private Color colorObjetivo;

    void Start()
    {
        luz = GetComponent<Light>();
        colorObjetivo = ColorAleatorio();
    }

    void Update() {
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime, Space.World);
        temporizador += Time.deltaTime;
        if (temporizador >= velocidadCambio)
        {
            colorObjetivo = ColorAleatorio();
            temporizador = 0f;
            if (!cambioSuave) {
                luz.color = colorObjetivo;
            }
        }
        if (cambioSuave) {
            luz.color = Color.Lerp(luz.color, colorObjetivo, Time.deltaTime * 5f);
        }
    }

    Color ColorAleatorio()
    {
        return Random.ColorHSV(0f, 1f, 0.8f, 1f, 0.8f, 1f);
    }
}

