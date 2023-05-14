using UnityEngine;

public class ShoppingController : MonoBehaviour
{
    [SerializeField] private GameObject shoppingPanel;
    [SerializeField] private GameObject objectPositionMesh;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private LayerMask groundLayer;

    private GameObject objBoxToTakePosition;
    public GameObject purchasedItem;
    private bool shoppingIsOpen = false;
    private bool objWasNotPlaced = false;

    private int itemGoldCost;
    private int itemFoodCost;
    private int itemWoodCost;

    private void Start()
    {
        shoppingPanel.SetActive(false);
    }

    private void Update()
    {
        shoppingPanel.SetActive(shoppingIsOpen);
        PlaceObject();
        CancelPurchase();
        if (shoppingIsOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseShopping();
        }
    }

    public void OpenShopping ()
    {
        if(shoppingIsOpen == false) { shoppingIsOpen = true; }
    }

    public void CloseShopping()
    {
        shoppingIsOpen = false;
        shoppingPanel.SetActive(false);
    }

    public void PlaceObject ()
    {
        if (objWasNotPlaced && Input.GetMouseButtonDown(0))
        {
            Vector3 boxPosition = objBoxToTakePosition.transform.position;
            Instantiate(purchasedItem, new Vector3(boxPosition.x, boxPosition.y + 1f, boxPosition.z), Quaternion.identity);
            Destroy(objBoxToTakePosition);
            objWasNotPlaced = false;
            gameManager.DecrementFood(itemFoodCost);
            gameManager.DecrementGold(itemGoldCost);
            gameManager.DecrementWood(itemWoodCost);
        }
    }

    public void Purchase (Item purchasedTower) 
    {
        CloseShopping();
        objWasNotPlaced = true;
        purchasedItem = purchasedTower.towerObject;
        objBoxToTakePosition = Instantiate(objectPositionMesh, new Vector3(50,7,35), Quaternion.identity);
        itemGoldCost = purchasedTower.GetGoldCost();
        itemFoodCost = purchasedTower.GetFoodCost();
        itemWoodCost = purchasedTower.GetWoodCost();
    }

    private void CancelPurchase()
    {
        if (objWasNotPlaced && Input.GetMouseButtonDown(1) || objWasNotPlaced && Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(objBoxToTakePosition);
            objWasNotPlaced = false;
        }
    }
}
