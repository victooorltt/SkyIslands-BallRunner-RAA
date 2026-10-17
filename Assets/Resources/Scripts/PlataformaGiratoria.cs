
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlataformaGiratoria : MonoBehaviour
{
    public float velocidad = 45f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        Quaternion giro = Quaternion.Euler(
            0f,
            0f,
            velocidad * Time.fixedDeltaTime
        );

        rb.MoveRotation(rb.rotation * giro);
    }
}
