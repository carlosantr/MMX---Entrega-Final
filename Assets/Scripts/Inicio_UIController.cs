using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Inicio_UIController : MonoBehaviour
{
    Button BotonInicio;

    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        BotonInicio = root.Q<Button>("BotonInicio");
        BotonInicio.clicked += InicioJuego;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InicioJuego()
    {
        SceneManager.LoadScene("Juego");
    }


}
