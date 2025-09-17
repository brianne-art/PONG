using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float speed;
    public Vector2 direction;

    private ScoreManager scoreManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.one.normalized;
        scoreManager = FindFirstObjectByType<ScoreManager>();
        LaunchBall();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = direction * speed;
    }
    void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.gameObject.CompareTag("paddle"))
            direction.x = -direction.x;

        else if (collison.gameObject.CompareTag("sidewall"))
            direction.y = -direction.y;

        else if (collison.CompareTag("leftwall"))
        {
            scoreManager.AddScore(2);
            ResetBall();
        }
        else if (collison.CompareTag("rightwall"))
        {
            scoreManager.AddScore(1);
            ResetBall();
        }



    }

    void ResetBall()
    {
        transform.position = Vector2.zero;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        Invoke(nameof(LaunchBall), 1f);
    }
    void LaunchBall()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(-1f, 1f);
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(x, y).normalized * 5f;
    }
}

