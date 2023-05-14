using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameControllerUI : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField]
    public TextMeshProUGUI woodTMP;
    [SerializeField]
    public TextMeshProUGUI foodTMP;
    [SerializeField]
    public TextMeshProUGUI goldTMP;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Update()
    {
        UpdateResourcesUI();
    }

    private void UpdateResourcesUI() {
        goldTMP.text = "Gold: " + gameManager.GetGold().ToString();
        foodTMP.text = "Food:" + gameManager.GetFood().ToString();
        woodTMP.text = "Wood: " + gameManager.GetWood().ToString();
    }
}
