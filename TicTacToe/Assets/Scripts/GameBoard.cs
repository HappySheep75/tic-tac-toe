using System;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;

    private int[,] _grid;

    private Player _playerOne;
    private Player _playerTwo;

    private Player _currentPlayer;

    [SerializeField] private GameObject _nought;
    [SerializeField] private GameObject _cross;

    // Start is called before the first frame update
    private void Start()
    {
        _grid = new int[3, 3];
        _boxCollider2D = GetComponent<BoxCollider2D>();

        SetupGrid();

        _playerOne = GameObject.Find("PlayerOne").GetComponent<Player>();
        _playerTwo = GameObject.Find("PlayerTwo").GetComponent<Player>();

        _currentPlayer = _playerOne;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            PlayerMove(_currentPlayer);
        }
    }

    private void SetupGrid()
    {
        int gridSizeX = 3;
        int gridSizeY = 3;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                _grid[x, y] = 0;
            }
        }
    }

    private void PlayerMove(Player player)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (_boxCollider2D.OverlapPoint(mousePosition))
        {
            Debug.Log("X: " + Math.Round(mousePosition.x).ToString() + " Y: " + Math.Round(mousePosition.y).ToString());
            Debug.Log(SquareClicked(player, mousePosition).name);
        }
    }

    private void UpdateCurrentPlayer()
    {
        if (_currentPlayer == _playerOne)
        {
            _currentPlayer = _playerTwo;
        }
        else if (_currentPlayer == _playerTwo)
        {
            _currentPlayer = _playerOne;
        }
    }

    private GameObject SquareClicked(Player player, Vector2 mousePosition)
    {
        var anchor = new GameObject();

        // TopLeft square clicked
        if (_grid[0, 0] == 0 && Math.Round(mousePosition.x) >= -4 && Math.Round(mousePosition.x) <= -2 && Math.Round(mousePosition.y) >= 2 && Math.Round(mousePosition.y) <= 4)
        {
            _grid[0, 0] = player.GamePieceValue;

            anchor = GameObject.Find("AnchorTopLeft");
            Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);

            UpdateCurrentPlayer();
        }

        // TopMiddle square clicked
        if (_grid[1, 0] == 0 && Math.Round(mousePosition.x) >= -1 && Math.Round(mousePosition.x) <= 1 && Math.Round(mousePosition.y) >= 2 && Math.Round(mousePosition.y) <= 4)
        {
            _grid[1, 0] = player.GamePieceValue;

            anchor = GameObject.Find("AnchorTopMiddle");

            Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);

            UpdateCurrentPlayer();
        }

        // TopRight square clicked
        if (_grid[2, 0] == 0 && Math.Round(mousePosition.x) >= 2 && Math.Round(mousePosition.x) <= 4 && Math.Round(mousePosition.y) >= 2 && Math.Round(mousePosition.y) <= 4)
        {
            _grid[2, 0] = player.GamePieceValue;

            anchor = GameObject.Find("AnchorTopRight");

            Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);

            UpdateCurrentPlayer();
        }

        // MiddleLeft square clicked
        if (_grid[0, 1] == 0 && Math.Round(mousePosition.x) >= -4 && Math.Round(mousePosition.x) <= -2 && Math.Round(mousePosition.y) >= -1 && Math.Round(mousePosition.y) <= 1)
        {
            _grid[0, 1] = player.GamePieceValue;

            anchor = GameObject.Find("AnchorMiddleLeft");

            Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);

            UpdateCurrentPlayer();
        }

        // Middle square clicked
        if (_grid[1, 1] == 0 && Math.Round(mousePosition.x) >= -1 && Math.Round(mousePosition.x) <= 1 && Math.Round(mousePosition.y) >= -1 && Math.Round(mousePosition.y) <= 1)
        {
            _grid[1, 1] = player.GamePieceValue;

            anchor = GameObject.Find("AnchorMiddle");

            Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);

            UpdateCurrentPlayer();
        }

        // MiddleRight square clicked
        if (_grid[2, 1] == 0 && Math.Round(mousePosition.x) >= 2 && Math.Round(mousePosition.x) <= 4 && Math.Round(mousePosition.y) >= -1 && Math.Round(mousePosition.y) <= 1)
        {
            _grid[2, 1] = player.GamePieceValue;

            anchor = GameObject.Find("AnchorMiddleRight");

            Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);

            UpdateCurrentPlayer();
        }

        // BottomLeft square clicked
        if (_grid[0, 2] == 0 && Math.Round(mousePosition.x) >= -4 && Math.Round(mousePosition.x) <= -2 && Math.Round(mousePosition.y) >= -4 && Math.Round(mousePosition.y) <= -2)
        {
            _grid[0, 2] = player.GamePieceValue;

            anchor = GameObject.Find("AnchorBottomLeft");

            Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);

            UpdateCurrentPlayer();
        }

        // BottomMiddle square clicked
        if (_grid[1, 2] == 0 && Math.Round(mousePosition.x) >= -1 && Math.Round(mousePosition.x) <= 1 && Math.Round(mousePosition.y) >= -4 && Math.Round(mousePosition.y) <= -2)
        {
            _grid[1, 2] = player.GamePieceValue;

            anchor = GameObject.Find("AnchorBottomMiddle");

            Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);

            UpdateCurrentPlayer();
        }

        // BottomRight square clicked
        if (_grid[2, 2] == 0 && Math.Round(mousePosition.x) >= 2 && Math.Round(mousePosition.x) <= 4 && Math.Round(mousePosition.y) >= -4 && Math.Round(mousePosition.y) <= -2)
        {
            _grid[2, 2] = player.GamePieceValue;

            anchor = GameObject.Find("AnchorBottomRight");

            Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);

            UpdateCurrentPlayer();
        }

        return anchor;
    }
}
