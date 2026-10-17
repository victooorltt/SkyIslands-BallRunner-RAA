
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObstaculoGiratorio : MonoBehaviour
{
    public float velocidad = 90f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    void FixedUpdate()
    {
        Quaternion giro = Quaternion.AngleAxis(
            velocidad * Time.fixedDeltaTime,
            Vector3.up
        );

        rb.MoveRotation(giro * rb.rotation);
    }
}
