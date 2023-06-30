using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddlescripts : MonoBehaviour
{
    public float speed;
    public float rightposition ;
    public float leftposition;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }

        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * Vector2.right* Time.deltaTime * speed);

        if (transform.position.x > 7)
        {
            transform.position = new Vector2(rightposition,transform.position.y);
        }
        if (transform.position.x < -7)
        {
            transform.position = new Vector2(leftposition, transform.position.y);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("extra life")) {
            gm.UpdateLives(1);
            Destroy(other.gameObject);
            }
    }
}
