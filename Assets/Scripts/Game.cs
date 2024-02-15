using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Game : MonoBehaviour
{
    private bool p1Active;
    private bool p2Active;
    private bool winner;
    private int[] states = new int[]
    public string currentPlayerSymbol;
    private GameObject currentPlayer;
    public bool safeToProceed;
    [SerializeField] private Cell[] _cells = new Cell[9];
    [SerializeField] private string[] _itemNames = new string[5];
    [SerializeField] private Sprite[] _items = new Sprite[5];
    private Sprite currentItem;

    // Start is called before the first frame update
    void Start()
    {
        p1Active = false;
        p2Active = false;
        safeToProceed = false;
        currentPlayerSymbol = "";
        winner = false;
        currentPlayer = GameObject.FindGameObjectWithTag("Player");
        currentItem = _items[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RunTurn()
    {
        if ()
        {
            
        }
        
        Debug.Log("Game Started");
        if (safeToProceed)
        {
            if (!p1Active && !p1Active)
            {
                p1Active = true;
                currentPlayerSymbol = "X";
                Debug.Log("X Turn");
                currentPlayer.GetComponent<Image>().sprite = _items[1];
                currentItem = _items[1];
            }
            else if (p1Active)
            {
                p1Active = false;
                
                p2Active = true;
                currentPlayerSymbol = "O";
                Debug.Log("O Turn");
                currentPlayer.GetComponent<Image>().sprite = _items[2];
                currentItem = _items[2];
            }
            else if (p2Active)
            {
                p2Active = false;
                
                p1Active = true;
                currentPlayerSymbol = "X";
                Debug.Log("X Turn");
                currentPlayer.GetComponent<Image>().sprite = _items[1];
                currentItem = _items[1];
            }

            safeToProceed = false;
        }
    }

    public string GetCurrentPlayer()
    {
        return currentPlayerSymbol;
    }

    public void Quit()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    public void Proceed()
    {
        safeToProceed = true;
    }
}
