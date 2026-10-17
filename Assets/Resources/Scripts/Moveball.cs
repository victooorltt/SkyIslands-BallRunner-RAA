
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Moveball : MonoBehaviour
{
    private Rigidbody rigidBody;
    public int ballSpeed = 100;
    public int jumpSpeed = 5;
    private bool ballistouching = false;

    // Sonidos
    public AudioSource audioSource = null;
    public AudioClip audioClip = null;
    public AudioClip sonidoSalto = null;

    // Monedas y tiempo
    public int score = 11;
    public Text scoreText = null;
    public float timeLeft = 60f;
    public Text timerText;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        updateScore();
    }

    void FixedUpdate()
    {
        float hmove = Input.GetAxis("Horizontal");
        float vmove = Input.GetAxis("Vertical");

        Vector3 ballmove = new Vector3(hmove, 0.0f, vmove);

        rigidBody.AddForce(ballmove * Time.deltaTime * ballSpeed);

        if (Input.GetKey(KeyCode.Space) && ballistouching)
        {
            Vector3 balljump = new Vector3(0.0f, jumpSpeed, 0.0f);
            rigidBody.AddForce(balljump);

            audioSource.PlayOneShot(sonidoSalto, 0.45f);

            ballistouching = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        ballistouching = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CoinTag"))
        {
            other.gameObject.SetActive(false);
            audioSource.PlayOneShot(audioClip);
            score--;
            updateScore();
        }
    }

    private void updateScore()
    {
        scoreText.text = "Coins left: " + score;
    }

    void Update()
    {
        timeLeft = Mathf.Max(0f, timeLeft - Time.deltaTime);
        timerText.text = "Time left: " + Mathf.CeilToInt(timeLeft);

        if (timeLeft <= 0)
        {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex
            );
        }
    }
}
