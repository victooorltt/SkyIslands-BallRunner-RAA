
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlataformaMovil : MonoBehaviour
{
    public float distancia = 2f;
    public float velocidad = 1f;

    public enum EjeMovimiento { X, Z }
    public EjeMovimiento eje = EjeMovimiento.X;

    private Rigidbody rb;
    private Vector3 posicionInicial;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;

        posicionInicial = rb.position;
    }

    void FixedUpdate()
    {
        float movimiento = Mathf.Sin(
            Time.fixedTime * velocidad
        ) * distancia;

        Vector3 direccion = eje == EjeMovimiento.X
            ? Vector3.right
            : Vector3.forward;

        Vector3 nuevaPosicion =
            posicionInicial + direccion * movimiento;

        rb.MovePosition(nuevaPosicion);
    }
}
