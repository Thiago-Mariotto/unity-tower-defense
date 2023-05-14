using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] int goldCost;
    [SerializeField] int woodCost;
    [SerializeField] int foodCost;
    [SerializeField] Button purchasedButton;
    [SerializeField] GameManager gameManager;
    [SerializeField] ShoppingController shoppingController;
    [SerializeField] public GameObject towerObject;

    private void Update()
    {
        ShowCostUI();
        HasResources();
        Debug.Log(gameManager.GetWood());
        Debug.Log(gameManager.GetFood());
    }

    private void HasResources ()
    {
        if (woodCost > gameManager.GetWood() || foodCost > gameManager.GetFood() || goldCost > gameManager.GetGold())
        {
            purchasedButton.interactable = false;
        }
    }

    private void ShowCostUI ()
    {
        string textCost = "G " + goldCost + "\nW " + woodCost + "\nF " + foodCost;
        this.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = towerObject.name;
        purchasedButton.GetComponentInChildren<TextMeshProUGUI>().text = textCost;
    }

    public int GetGoldCost ()
    { return goldCost;  }

    public int GetWoodCost()
    { return woodCost; }

    public int GetFoodCost()
    { return foodCost; }
}
