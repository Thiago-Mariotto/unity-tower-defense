using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _gold = 60;
    private int _wood = 60;
    private int _food = 40;

    [SerializeField] GameObject gameOverPanel;

    private static GameManager _instance;
    public static GameManager Instance 
    { 
        get {
            if (_instance == null)
                Debug.Log("No GameManager");

            return _instance;
        } 
    }

    public void RestartGame ()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // unpause the game
    }

    public void GameOver ()
    {
        gameOverPanel.SetActive(true);
    }

    private void Awake()
    {
        _instance = this;
        gameOverPanel.SetActive(false);
    }

    public void IncrementWood (int wood) {
        if (wood <= 0) { return; }
        _wood += wood;
    }

    public void DecrementWood(int wood)
    {
        if (wood <= 0) { return; }
        _wood -= wood;
        if (_wood < 0) { _wood = 0; }
    }

    public int GetWood() { return _wood; }

    public void IncrementGold (int gold) {
        if(gold <= 0 ) { return; }
        _gold += gold;
    }

    public void DecrementGold (int gold)
    {
        if (gold <= 0) { return; }
        _gold -= gold;
        if(_gold < 0) { _gold = 0; }
    }

    public int GetGold(){ return _gold; }
    

    public void IncrementFood(int food)
    {
        if (food <= 0) { return; }
        _food += food;
    }

    public void DecrementFood (int food) 
    {
        if (food <= 0) { return; }
        _food -= food;
        if(_food < 0) { _food = 0; }
    }

    public int GetFood() { return _food; }

}
