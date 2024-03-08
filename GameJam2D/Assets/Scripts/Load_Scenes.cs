using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Scenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Jogo");
    }

    public void LoadCréditos()
    {
        SceneManager.LoadScene("Jogo");
    }

    public void LoadSair()
    {
        Application.Quit();
    }
}
