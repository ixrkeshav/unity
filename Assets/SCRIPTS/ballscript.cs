using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ballscript : MonoBehaviour
{

    public Rigidbody2D rb;
    public float initialforce;
    public Transform paddle;
    public bool inPlay;
    public GameManager gm;
    //public int count;
    //public Transform explosion;
    public Transform powerup;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {

       /* if (count == gm.numberOfBricks)
        {

        }
*/
        if (gm.gameOver)
        {
            
            rb.velocity = Vector2.zero;
            return;
        }
        if (!inPlay)
        {
             transform.position = paddle.position;
        }


        if (Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * initialforce);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("bottom"))
        {

            gm.UpdateLives(-1);

            print("ball hits the bottom");
            rb.velocity = Vector2.zero;
            inPlay = false;

        }
    }


    private void OnCollisionEnter2D(Collision2D collis)
    {
        brickscript brickScript = collis.gameObject.GetComponent<brickscript>();
        if (collis.transform.CompareTag("brick"))
        {
            if (brickScript.hitsToBreak > 1)
            {
                brickScript.BreakBrick();
            }
            else
            {

                int randomchance = Random.Range(1, 101);
                if (randomchance < 20)
                {
                    Instantiate(powerup, collis.transform.position, collis.transform.rotation);
                }
                Destroy(collis.gameObject);
                gm.UpdateNumberOfBricks();
                //count++;
                gm.UpdateScore(+1);
            }
        } if (collis.transform.CompareTag("brickLevel2"))
        {
            if (brickScript.hitsToBreak > 1)
            {
                brickScript.BreakBrick();
            }
            else
            {

                int randomchance = Random.Range(1, 101);
                if (randomchance < 20)
                {
                    Instantiate(powerup, collis.transform.position, collis.transform.rotation);
                }
                Destroy(collis.gameObject);
                gm.UpdateNumberOfBricks();
                //count++;
                gm.UpdateScore(+1);
            }
        }
    }
}
