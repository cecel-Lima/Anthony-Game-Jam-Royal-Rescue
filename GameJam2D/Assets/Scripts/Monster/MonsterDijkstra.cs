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
    private int[,] trails;

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
        //mark beholder
        mtrx[By, Bx] = 3;

        //from B to NBx(By+1)
        if (mtrx[By + 1, Bx] != 0)
        {
            //make trails as B
            //(y + 1,x)
            if (mtrx[By + 1, Bx] == 1)
            {
                trails[0, 0] = 0;
            }
            //(y,x + 1)
            if (mtrx[By, Bx + 1] == 1)
            {
                trails[1, 0] = 1;
            }
            //(y - 1,x)
            if (mtrx[By - 1, Bx] == 1)
            {
                trails[2, 0] = 2;
            }
            //(y,x - 1)
            if (mtrx[By, Bx - 1] == 1)
            {
                trails[3, 0] = 3;
            }

            //choose trail to heroine
            if ((By + 1) == Hy && Bx == Hx)
            {
                direct = trails[0, 0];
            }

            //salvando Node
            mtrx[By + 1, Bx] = 2;
        }

        //from B to N(Bx + 1)(By + 1)
        if (mtrx[By + 1, Bx + 1] != 0)
        {
            //make trails as NBx(By + 1)
            //(y + 1,x)
            if (mtrx[By + 2, Bx] == 1)
            {
                trails[4, 0] = trails[0, 0];
                trails[4, 1] = 0;
            }
            //(y,x +1)
            if (mtrx[By + 1, Bx + 1] == 1)
            {
                trails[5, 0] = trails[0, 0];
                trails[5, 1] = 1;
            }
            //(y - 1,x)
            if (mtrx[By, Bx] == 1)
            {
                //não vai rodar. Node == 3.
            }
            //(y,x - 1)
            if (mtrx[By + 1, Bx - 1] == 1)
            {
                trails[7, 0] = trails[0, 0];
                trails[7, 1] = 3;
            }


            //choose trail to heroine
            if ((By + 1) == Hy && (Bx + 1) == Hx)
            {
                float flag0 = transform.position.y + 1f;
                while (transform.position.y < flag0)
                {
                    direct = trails[5, 0];
                }
                direct = trails[5, 1];
            }

            //salvando Node
            mtrx[By + 1, Bx + 1] = 2;
        }

        //from B to N(Bx + 1)By
        if (mtrx[By, Bx + 1] != 0)
        {
            //make trails as N(Bx + 1)(By + 1)
            //(y + 1,x)
            if (mtrx[By + 2, Bx + 1] == 1)
            {
                trails[8, 0] = trails[0, 0];
                trails[8, 1] = trails[5, 1];
                trails[8, 2] = 0;
            }
            //(y,x + 1)
            if (mtrx[By + 1, Bx + 2] == 1)
            {
                trails[9, 0] = trails[0, 0];
                trails[9, 1] = trails[5, 1];
                trails[9, 2] = 1;
            }
            //(y - 1,x)
            if (mtrx[By, Bx + 1] == 1)
            {
                trails[11, 0] = trails[0, 0];
                trails[11, 1] = trails[5, 1];
                trails[11, 2] = 2;
            }
            //(y,x - 1)
            if (mtrx[By + 1, Bx] == 1)
            {
                //não vai rodar. NBx(By + 1) == 2.
            }

            //choose trail to heroine
            if ((By + 1) == Hy && (Bx + 1) == Hx)
            {
                direct = trails[1, 0];
            }

            //salvando Node
            mtrx[By, Bx + 1] = 2;
        }
    }
}
