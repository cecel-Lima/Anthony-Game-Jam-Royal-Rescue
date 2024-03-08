using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCloWise : MonoBehaviour
{
    [SerializeField]
    int direct;
    [SerializeField]
    float speed = 2f;

    BoxCollider2D box;
    float boxOffsetX = 0f;
    float boxOffsetY = 0.59f;
    float boxSizeX = 0.75f;
    float boxSizeY = 0.025f;

    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        Move();
        ChangeBox();
        CheckDire();
    }

    private void Move()
    {
        if (direct == 0)
        {
            Vector3 north = new Vector3(0f, speed * Time.deltaTime, 0f);
            transform.position += north;
        }
        if (direct == 1)
        {
            Vector3 east = new Vector3(speed * Time.deltaTime, 0f, 0f);
            transform.position += east;
        }
        if (direct == 2)
        {
            Vector3 south = new Vector3(0f, speed * (-1f) * Time.deltaTime, 0f);
            transform.position += south;
        }
        if (direct == 3)
        {
            Vector3 west = new Vector3(speed * (-1f) * Time.deltaTime, 0f, 0f);
            transform.position += west;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Tilemap")
        {
            direct++;
        }
    }

    void CheckDire()
    {
        if (direct >= 4)
        {
            direct = 0;
        }
        if (direct <= -1)
        {
            direct = 3;
        }
    }
    void ChangeBox()
    {
        if (direct == 0)
        {
            boxOffsetX = 0f;
            boxOffsetY = 0.59f;
            box.offset = new Vector2(boxOffsetX, boxOffsetY);

            boxSizeX = 0.75f;
            boxSizeY = 0.025f;
            box.size = new Vector2(boxSizeX, boxSizeY);
        }
        if (direct == 1)
        {
            boxOffsetX = 0.59f;
            boxOffsetY = 0f;
            box.offset = new Vector2(boxOffsetX, boxOffsetY);

            boxSizeX = 0.025f;
            boxSizeY = 0.75f;
            box.size = new Vector2(boxSizeX, boxSizeY);
        }
        if (direct == 2)
        {
            boxOffsetX = 0f;
            boxOffsetY = -0.59f;
            box.offset = new Vector2(boxOffsetX, boxOffsetY);

            boxSizeX = 0.75f;
            boxSizeY = 0.025f;
            box.size = new Vector2(boxSizeX, boxSizeY);
        }
        if (direct == 3)
        {
            boxOffsetX = -0.59f;
            boxOffsetY = 0f;
            box.offset = new Vector2(boxOffsetX, boxOffsetY);

            boxSizeX = 0.025f;
            boxSizeY = 0.75f;
            box.size = new Vector2(boxSizeX, boxSizeY);
        }
    }
}
