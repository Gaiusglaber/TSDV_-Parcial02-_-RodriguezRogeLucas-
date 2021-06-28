using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    bool landed = false;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player"&&!landed)
        {
            landed = true;
            //collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            if (CanLand(collision))
            {
                GameManager.GetInstance().HighScore += 50;
                GameManager.GetInstance().win = true;
                GameManager.GetInstance().gameOver = true;
                GameManager.GetInstance().GameOver();
            }
            else
            {
                Destroy(collision.gameObject);
                GameManager.GetInstance().win = false;
                GameManager.GetInstance().gameOver = true;
                GameManager.GetInstance().GameOver();
            }
        }
    }
    bool CanLand(Collision2D collision)
    {
        bool isSpeed = (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y < 0.1f&& collision.gameObject.GetComponent<Rigidbody2D>().velocity.y > -0.1f)&& (collision.gameObject.GetComponent<Rigidbody2D>().velocity.x < 1f && collision.gameObject.GetComponent<Rigidbody2D>().velocity.y > -1f);
        return isSpeed;
    }

}


