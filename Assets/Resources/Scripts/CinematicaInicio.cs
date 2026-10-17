
using UnityEngine;

public class CinematicaInicio : MonoBehaviour
{
    public Camera camaraJuego;
    public Camera camaraCinematica;
    public Moveball jugador;

    public Transform inicio;
    public Transform final;

    public float duracion = 5f;

    private float tiempo = 0f;
    private Rigidbody rigidBody;
    private bool eraKinematic;

    private static bool yaVista = false;
    private bool reproduciendo = false;

    void Start()
    {
        rigidBody = jugador.GetComponent<Rigidbody>();

        if (yaVista)
        {
            camaraJuego.gameObject.SetActive(true);
            camaraJuego.enabled = true;
            camaraCinematica.enabled = false;
            return;
        }

        // Detenemos el movimiento y la gravedad de la esfera
        jugador.enabled = false;
        eraKinematic = rigidBody.isKinematic;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        rigidBody.isKinematic = true;

        // Desactivamos solo la imagen de Main Camera
        // Su script de seguimiento sigue funcionando
        camaraJuego.gameObject.SetActive(true);
        camaraJuego.enabled = false;

        camaraCinematica.gameObject.SetActive(true);
        camaraCinematica.enabled = true;

        camaraCinematica.transform.position = inicio.position;
        camaraCinematica.transform.rotation = inicio.rotation;

        reproduciendo = true;
    }

    void Update()
    {
        if (!reproduciendo)
            return;

        tiempo += Time.deltaTime;

        float t = Mathf.Clamp01(tiempo / duracion);
        t = Mathf.SmoothStep(0f, 1f, t);

        camaraCinematica.transform.position =
            Vector3.Lerp(inicio.position, final.position, t);

        camaraCinematica.transform.rotation =
            Quaternion.Slerp(inicio.rotation, final.rotation, t);

        if (tiempo >= duracion)
        {
            TerminarCinematica();
        }
    }

    void TerminarCinematica()
    {
        reproduciendo = false;
        yaVista = true;

        // Volvemos a activar el movimiento y la gravedad
        rigidBody.isKinematic = eraKinematic;
        jugador.enabled = true;

        // Volvemos a la cámara normal
        camaraCinematica.enabled = false;
        camaraJuego.enabled = true;
    }
}
