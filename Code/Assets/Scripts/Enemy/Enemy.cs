using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] private int enemyLife;
    private GameManager gameManager;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ammo"))
        {
            enemyLife--;
        }
    }

    private void Update()
    {
        IsAlive();
        
    }

    private void Start()
    {
        gameManager = GameObject.Find("EventSystem").GetComponent<GameManager>();
        enemyLife = Random.Range(7, 15);
    }

    private void IsAlive ()
    {
        if (enemyLife <= 0)
        {
            gameManager.IncrementGold(5);
            gameManager.IncrementFood(2);
            gameManager.IncrementWood(2);
            Destroy(gameObject);
        }
    }
}
