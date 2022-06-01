using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Final_UIController : MonoBehaviour
{
    Button BotonVolver;

    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        BotonVolver = root.Q<Button>("BotonVolver");
        BotonVolver.clicked += Inicio;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Inicio()
    {
        SceneManager.LoadScene("MenuInicial");
    }


}
