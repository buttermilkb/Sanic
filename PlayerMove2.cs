using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove2 : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    private Animator anim;

    public float jumpVelocity;
    public float moveSpeed;
    public float pause;

    private bool canJump = true;
    private bool canMove = true;

    private int coinCount = 0;


    void Start()
    {
        anim = GetComponent<Animator>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            if (canJump)
            {
                jump();
            }
        }
        if (canMove)
        {
            move();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = true;
            anim.SetBool("isJumping", false);
        }
        if (collision.gameObject.CompareTag("Death"))
        {
            canMove = false;
            anim.SetBool("WaLK", false);
            Invoke("loadDeath", pause);
            SoundManagerScript.PlaySound("oof");
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Coin"))
        {
            SoundManagerScript.PlaySound("coinCollect");
            Destroy(collider.gameObject);
            coinCount++;
        }
        if (collider.gameObject.CompareTag("Win"))
        {
            if (coinCount == 50)
            {
                SceneManager.LoadScene("S2WinScreen");
            }
            else if (coinCount < 50 && coinCount >= 40)
            {
                SceneManager.LoadScene("A2WinScreen");
            }
            else if (coinCount < 40 && coinCount >= 30)
            {
                SceneManager.LoadScene("B2WinScreen");
            }
            else if (coinCount < 30 && coinCount >= 20)
            {
                SceneManager.LoadScene("C2WinScreen");
            }
            else if (coinCount < 20 && coinCount >= 10)
            {
                SceneManager.LoadScene("D2WinScreen");
            }
            else
            {
                SceneManager.LoadScene("F2WinScreen");
            }
        }
    }

    void OnGUI()
    {
        GUI.contentColor = Color.black;
        GUI.skin.label.fontSize = 50;
        GUI.Label(new Rect(25, 15, 500, 500), "Coin Counter: " + coinCount + "/50");
    }

    void flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void move()
    {
        Vector3 location = transform.position;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.localScale.x > 0)
            {
                flip();
            }
            location.x -= moveSpeed * Time.deltaTime;
            anim.SetBool("WaLK", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.localScale.x < 0)
            {
                flip();
            }
            location.x += moveSpeed * Time.deltaTime;
            anim.SetBool("WaLK", true);
        }
        else
        {
            anim.SetBool("WaLK", false);
        }
        transform.position = location;
    }

    void jump()
    {
        rigidBody.velocity = Vector2.up * jumpVelocity;
        canJump = false;
        anim.SetTrigger("takeOff");
        anim.SetBool("isJumping", true);
        SoundManagerScript.PlaySound("jump");

    }

    void loadDeath()
    {
        SceneManager.LoadScene("Death2Scene");
    }


}


