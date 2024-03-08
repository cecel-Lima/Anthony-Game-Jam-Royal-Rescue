using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Iniciar : MonoBehaviour
{
    public Button Comecar;
    // Start is called before the first frame update
    void Start()
    {
        Comecar.onClick.AddListener(LoadC);
    }
    void LoadC()
    {
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {

    }
}

