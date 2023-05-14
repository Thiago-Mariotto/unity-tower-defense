using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private int houseLife;
    [SerializeField] private GameObject UIController;
    private GameManager gameManager;

    private void Start()
    {
        houseLife = 1;
        gameManager = GameObject.Find("EventSystem").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (houseLife <= 0)
        {
            //Time.timeScale = 0;
            gameManager.GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            houseLife--;
            Destroy(collision.gameObject);
        }
    }
}
