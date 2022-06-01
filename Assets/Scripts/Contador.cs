using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Contador : MonoBehaviour
{
    float NumEnemyV;
    float NumEnemyT;
    float NumTotal;
    Label TextoContador;

    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        TextoContador = root.Q<Label>("TextoContador");

    }

    // Update is called once per frame
    void Update()
    {
        object[] OBEnemyV = FindObjectsOfType<EnemyV>(); //Encuentra los scripts de nombre "EnemyV" Y "EnemyT", pertenecientes a los enemigos
        object[] OBEnemyT = FindObjectsOfType<EnemyT>();
        NumEnemyT = OBEnemyT.Length;
        NumEnemyV = OBEnemyV.Length;
        NumTotal = NumEnemyV + NumEnemyT;

        TextoContador.text = "Enemigos restantes: " + NumTotal;

        if (NumTotal == 0)
        {
            SceneManager.LoadScene("Ganaste");
        }
    }
}
