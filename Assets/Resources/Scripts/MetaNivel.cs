using UnityEngine;
using UnityEngine.SceneManagement;

public class MetaNivel : MonoBehaviour
{
    public string siguienteEscena = "FinalScene";

    private void OnTriggerEnter(Collider otro)
    {
        Moveball jugador = otro.GetComponent<Moveball>();

        if (jugador == null)
            return;

        if (jugador.score == 0)
        {
            SceneManager.LoadScene(siguienteEscena);
        }
    }
}