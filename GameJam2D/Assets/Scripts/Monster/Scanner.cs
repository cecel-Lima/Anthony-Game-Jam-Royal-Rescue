using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    private int GridHeight;
    [SerializeField]
    private int GridWidth;
    private int i = -1;
    [SerializeField]
    private float GridRightWall;

    public int[,] matrix;
    [SerializeField]
    private float line0;
    [SerializeField]
    private float line1;
    [SerializeField]
    private float colum0;
    [SerializeField]
    private float colum1;
    void Start()
    {
        matrix = new int[GridHeight, GridWidth];
    }

    
    void Update()
    {
        Movement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Node")
        {
            Debug.Log(collision.gameObject.name + " found");
            MarkNode();
        }
    }
    private void Movement()
    {
        if (i != GridHeight)
        {
            transform.position += Vector3.right * speed;
            if (transform.position.x > GridRightWall)
            {
                i++;
                transform.position = new Vector3(-12.48f, 8.5f - i, 0f);
            }
        } 
        /*else if (i == GridHeight)
        {
            WriteMatrix();
        }
        */
    }

    void MarkNode()
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (transform.position.y < (line0 - i) && transform.position.y > (line1 - i))
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (transform.position.x > (colum0 + j) && transform.position.x < (colum1 + j))
                    {
                        matrix[i, j] = 1;
                    }
                }
            }
        }
    }

    /*void WriteMatrix()
    {
        for(int i = 0;i < matrix.GetLength(0); i++)
        {
            string line = "l" + i.ToString() + ": ";

            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                line += matrix[i, j].ToString() + " ";
            }

            Debug.Log(line);
        }
    }
    */
}
