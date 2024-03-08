using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDijkstra : MonoBehaviour
{
    [SerializeField]
    int direct;
    [SerializeField]
    float speed = 2f;

    public Transform heroine;
    public Transform scan;
    public Scanner scanMtrx;
    private int[,] mtrx;

    [SerializeField]
    private float GroZerox;
    [SerializeField]
    private float GroZeroy;
    [SerializeField]
    private int Bx;
    [SerializeField]
    private int By;
    [SerializeField]
    private int Hx;
    [SerializeField]
    private int Hy;

    void Start()
    {
        
    }


    void Update()
    {
        if (scan.position.y < -15f)
        {
            mtrx = scanMtrx.matrix;
            Move();
            MakeHAndBNode();
            Dijkstra();
        }
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

    private void MakeHAndBNode()
    {
        for (int i = 0; i < mtrx.GetLength(0); i++)
        {
            if (transform.position.y < (GroZeroy - i + 0.5f) && transform.position.y >= (GroZeroy - i - 0.5f))
            {
                for (int j = 0; j < mtrx.GetLength(1); j++)
                {
                    if (transform.position.x > (GroZerox + j - 0.5f) && transform.position.x <= (GroZerox + j + 0.5f))
                    {
                        Bx = j; By = i;
                    }
                }
            }
        }

        for (int i = 0; i < mtrx.GetLength(0); i++)
        {
            if (heroine.position.y < (GroZeroy - i + 0.5f) && heroine.position.y >= (GroZeroy - i - 0.5f))
            {
                for (int j = 0; j < mtrx.GetLength(1); j++)
                {
                    if (heroine.position.x > (GroZerox + j - 0.5f) && heroine.position.x <= (GroZerox + j + 0.5f))
                    {
                        Hx = j; Hy = i;
                    }
                }
            }
        }
    }

    private void Dijkstra()
    {
        //from B to NBx(By+1)
        if (mtrx[By + 1, Bx] == 1)
        {
            if ((By + 1) == Hy && Bx == Hx)
            {
                //choose trail to this Node

            }
            else
            {
                //make trails

            }
        }
    }
}
