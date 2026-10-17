using UnityEngine;

public class GirarRueda : MonoBehaviour
{
    public float velocidad = 35f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Quaternion giro = Quaternion.Euler(
            0f,
            velocidad * Time.fixedDeltaTime,
            0f
        );

        rb.MoveRotation(rb.rotation * giro);
    }
}