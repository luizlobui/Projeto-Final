using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mensagem : MonoBehaviour
{

    public Text texto;
    [Range(0.1f, 5.0f)]public float distancia = 2;
    private GameObject Jogador;

    void Start()
    {
        texto.enabled = false;
        Jogador = GameObject.FindWithTag("Player");
    }

    
    void Update()
    {
        if (Vector3.Distance(transform.position, Jogador.transform.position) < distancia)
        {
            texto.enabled = true;

        }
        else
        {
            texto.enabled = false;
        }
    }
}
