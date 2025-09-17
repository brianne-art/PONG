using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float speed;
    public Vector2 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb= GetComponent<Rigidbody2D>();
        direction= Vector2.one.normalized; 
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity= direction*speed;
    }
    void OnTriggerEnter2D(Collider2D collison){
     if (collison.gameObject.CompareTag("paddle"))
        direction.x = -direction.x;

    else if (collison.gameObject.CompareTag("sidewall"))
        direction.y = -direction.y;
    
    else if (collison.gameObject.CompareTag("endwall"))
    Debug.Log("Game over");
    }
}

