using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            //collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            if (CanLand(collision))
            {
                GameManager.GetInstance().win = true;
                GameManager.GetInstance().gameOver = true;
                GameManager.GetInstance().GameOver();
            }
            else
            {
                GameManager.GetInstance().win = false;
                GameManager.GetInstance().gameOver = true;
                GameManager.GetInstance().GameOver();
            }
        }
    }
    bool CanLand(Collision2D collision)
    {
        bool isSpeed = (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y < 1f&& collision.gameObject.GetComponent<Rigidbody2D>().velocity.y > -1f)&& (collision.gameObject.GetComponent<Rigidbody2D>().velocity.x < 1f && collision.gameObject.GetComponent<Rigidbody2D>().velocity.y > -1f);
        return isSpeed;
    }

}


