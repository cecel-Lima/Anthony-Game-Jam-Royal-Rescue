using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Enemy_Move : MonoBehaviour
{
    public float speed = 3;
    public bool girou = false;
    public float destinoPositivoX;
    public float destinoNegativoX;
    public float destinoPositivoY;
    public float destinoNegativoY;
    public bool atingiuDestino = false;
    public GameObject Target;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 position = transform.position;

        if (position.y < destinoPositivoY && atingiuDestino == false)
        {
            position.y += speed * Time.deltaTime;
        }

        else
        {
            atingiuDestino = true;
        }

        transform.position = position;

        if (position.y > destinoNegativoY && atingiuDestino == true)
        {
            position.y -= speed * Time.deltaTime;
        }

        else
        {
            atingiuDestino = false;
        }

        transform.position = position;

    }
}
