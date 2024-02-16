using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _title;
    [SerializeField] private GameObject _itemSelection;
    [SerializeField] private GameObject _game;
    [SerializeField] private GameObject _win;
    private GameObject test;
    private bool p1Active;
    private bool p2Active;
    private Sprite[] p1Items = new Sprite[2];
    private Sprite[] p2Items = new Sprite[2];
    private bool winner;
    private string winnerSymbol;
    private int[] states = new int[4];
    private int state;
    public string currentPlayerSymbol;
    private GameObject currentPlayer;
    public bool safeToProceed;
    [SerializeField] private Cell[] _cells = new Cell[9];
    [SerializeField] private GameObject[] _cellItems = new GameObject[9];
    [SerializeField] private string[] _itemNames = new string[5];
    [SerializeField] private Sprite[] _items = new Sprite[5];
    private Sprite currentItem;

    // Start is called before the first frame update
    void Start()
    {
        state = states[0];
        p1Active = true;
        p1Items[0] = _items[1];
        p2Active = false;
        p2Items[0] = _items[2];
        
        safeToProceed = false;
        currentPlayerSymbol = "";
        winner = false;
        winnerSymbol = "";
        currentPlayer = GameObject.FindGameObjectWithTag("Player");
        currentItem = _items[0];
        _title.SetActive(true);
        _itemSelection.SetActive(false);
        _game.SetActive(false);
        _win.SetActive(false);

        GenerateRandomItems();
        GameObject.Find("ItemX").GetComponent<SpriteRenderer>().sprite = p1Items[0];
        GameObject.Find("ItemO").GetComponent<Image>().sprite = p2Items[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckForWinner()
    {
        if(_cellItems[0] == _cellItems[1] && _cellItems[0] == _cellItems[2]) //012
        {
            winner = true;
            winnerSymbol = currentPlayerSymbol;
        }
        else if(_cellItems[3] == _cellItems[4] && _cellItems[3] == _cellItems[5]) //345
        {
            winner = true;
            winnerSymbol = currentPlayerSymbol;
        }
        else if(_cellItems[6] == _cellItems[7] && _cellItems[6] == _cellItems[8]) //678
        {
            winner = true;
            winnerSymbol = currentPlayerSymbol;
        }
        else if(_cellItems[0] == _cellItems[3] && _cellItems[0] == _cellItems[6]) //036
        {
            winner = true;
            winnerSymbol = currentPlayerSymbol;
        }
        else if(_cellItems[1] == _cellItems[4] && _cellItems[1] == _cellItems[7]) //147
        {
            winner = true;
            winnerSymbol = currentPlayerSymbol;
        }
        else if(_cellItems[2] == _cellItems[5] && _cellItems[2] == _cellItems[8]) //258
        {
            winner = true;
            winnerSymbol = currentPlayerSymbol;
        }
        else if(_cellItems[0] == _cellItems[4] && _cellItems[0] == _cellItems[8]) //048
        {
            winner = true;
            winnerSymbol = currentPlayerSymbol;
        }
        else if(_cellItems[2] == _cellItems[4] && _cellItems[2] == _cellItems[6]) //246
        {
            winner = true;
            winnerSymbol = currentPlayerSymbol;
        }
    }

    public void RunTurn()
    {
        Debug.Log("New Turn Attempted");
        CheckForWinner();

        // Default Item
        if (currentPlayerSymbol == "X")
        {
            currentItem = p1Items[0];
        }
        else if (currentPlayerSymbol == "O")
        {
            currentItem = p2Items[0];
        }
        
        if (state == 0) //Goes to item screen
        {
            _title.SetActive(false);
            _itemSelection.SetActive(true);
            state = 1;
            Debug.Log("Item Selection");
            safeToProceed = true;
            return;
        }

        if (state == 1) //Goes to game screen
        {
            _itemSelection.SetActive(false);
            _game.SetActive(true);
            state = 2;
            Debug.Log("Game Started");
            return;
        }

        if (state == 2 && winner)
        {
            _game.SetActive(false);
            _win.SetActive(true);
            state = 3;
            Debug.Log("Game Won");
            return;
        }

        if (state == 3 && winner)
        {
            _win.SetActive(false);
            _title.SetActive(true);
            state = 0;
            Debug.Log("Game Finished");
            return;
        }
        
        if (safeToProceed)
        {
            if (p1Active)
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
            
            Debug.Log("Waiting for player to make move.");
            safeToProceed = false;
        }
    }

    void PlaceItem()
    {
        GameObject currentCell = EventSystem.current.currentSelectedGameObject;
        currentCell.GetComponent<Image>().sprite = currentItem;
    }

    void GenerateRandomItems()
    {
        int index1 = Random.Range(0, 5);
        p1Items[1] = _items[index1];
        
        int index2 = Random.Range(0, 5);
        p2Items[1] = _items[index2];
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

    public void ButtonTest()
    {
        Debug.Log("Button Test Successful");
        Debug.Log(EventSystem.current.currentSelectedGameObject.name + " was Clicked");
    }
}
