using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Tilemaps;

public class Player_Move : MonoBehaviour
{
    //Animator animator;
    private Rigidbody2D rb;
    public float speed = 5;
    public bool girou = false;
    public TextMeshProUGUI itensUI; //healthUI;
    public int keyTotal = 0;
    public int healthTotal = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        //animator.SetBool("Idle_Player", true);
        //animator.SetBool("Run_1", false);

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerDeath();
        itensUI.text = "x" + keyTotal.ToString();
        //healthUI.text = "x" + healthTotal.ToString();

    }

    void PlayerMove()
    {
        Vector2 position = transform.position;

        if (Input.anyKey != true)
        {
            //animator.SetBool("Idle_Player", true);
            //animator.SetBool("Run_1", false);
        }

        else
        {
            //animator.SetBool("Idle_Player", false);
        }

        if (Input.GetKey("w"))
        {
            position.y += speed * Time.deltaTime;
            //animator.SetBool("Run_1", true);

        }

        if (Input.GetKey("s"))
        {
            position.y -= speed * Time.deltaTime;
            //animator.SetBool("Run_1", true);
        }

        if (Input.GetKey("d"))
        {
            position.x += speed * Time.deltaTime;
            //animator.SetBool("Run_1", true);
        }

        if (Input.GetKey("a"))
        {
            position.x -= speed * Time.deltaTime;
            //animator.SetBool("Run_1", true);
        }

        transform.position = position;
    }

    void PlayerDeath()
    {
        if (healthTotal == 0)
        {
            SceneManager.LoadScene("Defeat_Screen", LoadSceneMode.Single);
        }
    }

    //FIM DE JOGO
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Key"))
        {
            keyTotal += 1;
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Cage") && keyTotal == 1)
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Potion"))
        {
            healthTotal += 1;
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Enemy"))
        {
            healthTotal -= 1;
        }
    }
    //FIM DE JOGO
}
