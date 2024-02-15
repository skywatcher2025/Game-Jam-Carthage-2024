using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.UIElements;
using static Game;

public class Cell : MonoBehaviour
{
    private Camera mainCamera;
    private bool _clicked;
    private string _state;
    [SerializeField] Image[] _item;
    [SerializeField] GameObject _gameController;
    private Game game;
    private string currentPlayerSymbol;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        _clicked = false;
        _state = "Empty";
        _gameController = GameObject.FindGameObjectWithTag("GameController");
        game = _gameController.GetComponent<Game>();
        currentPlayerSymbol = game.GetCurrentPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 represents the left mouse button
        {
            // Handle the mouse click
            HandleMouseClick();
        }
    }

    void HandleMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Handle the cell click
            HandleCellClick(hit.collider.gameObject);
        }
    }

    void HandleCellClick(GameObject cell)
    {
        if (_state == "Empty")
        {
            // Place "X" or "O" on the cell
            //_state = GameObject.FindGameObjectWithTag("GameController").GetCurrentPlayer();

            // Update the game state (change player turn, check for win/draw, etc.)
            UpdateGameState();
        }
    }
    
    void UpdateGameState()
    {
        // Implement logic to switch turns, check for win, draw, etc.
        // This might include calling functions to check win conditions and updating UI.
    }
}
