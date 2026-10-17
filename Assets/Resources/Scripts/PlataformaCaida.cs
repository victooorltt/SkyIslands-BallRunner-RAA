
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlataformaCaida : MonoBehaviour
{
    public float tiempoCaida = 0.8f;

    private Rigidbody rb;
    private bool activada = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Moveball>() != null
            && !activada)
        {
            activada = true;
            StartCoroutine(Caer());
        }
    }

    IEnumerator Caer()
    {
        yield return new WaitForSeconds(tiempoCaida);

        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
