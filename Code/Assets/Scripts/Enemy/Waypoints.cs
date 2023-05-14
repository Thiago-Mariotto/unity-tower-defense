using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    // Cria um array de transform que contém as posições dos pontos de passagem
    [SerializeField] public static Transform[] points;

    void Awake()
    {
        // Define o tamanho do array de pontos de passagem
        points = new Transform[transform.childCount];

        // Adiciona cada filho do objeto atual (cada ponto de passagem) ao array
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
