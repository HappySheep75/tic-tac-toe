﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBoard : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;

    private int[,] _grid;

    private Player _playerOne;
    private Player _playerTwo;

    private Player _currentPlayer;

    private List<GameObject> _boardPieces;

    private bool _waitForStart;
    private bool _countDown;

    private float _count = 5;

    [SerializeField] private GameObject _nought;
    [SerializeField] private GameObject _cross;

    // Start is called before the first frame update
    private void Start()
    {
        _grid = new int[3, 3];
        _boxCollider2D = GetComponent<BoxCollider2D>();

        _boardPieces = new List<GameObject>();

        SetupGrid();

        _playerOne = GameObject.Find("PlayerOne").GetComponent<Player>();
        _playerTwo = GameObject.Find("PlayerTwo").GetComponent<Player>();

        _currentPlayer = _playerOne;

        _waitForStart = true;

        _count += 1;

        NewGame();
    }

    private void NewGame()
    {
        GameObject.Find("UIGameBoard").transform.Find("InfoText").GetComponent<Text>().text = "Press\r\nany\r\nkey...";

        GameObject.Find("UIPlayerOne").transform.Find("PlayerOneStatusText").GetComponent<Text>().text = "Waiting...";
        GameObject.Find("UIPlayerOne").transform.Find("PlayerOneTimerText").GetComponent<Text>().text = "20:00 s";

        GameObject.Find("UIPlayerTwo").transform.Find("PlayerTwoStatusText").GetComponent<Text>().text = "Waiting...";
        GameObject.Find("UIPlayerTwo").transform.Find("PlayerTwoTimerText").GetComponent<Text>().text = "20:00 s";
    }

    // Update is called once per frame
    private void Update()
    {
        if (_waitForStart)
        {
            if (Input.anyKey)
            {
                _countDown = true;
                _waitForStart = false;

                GameObject.Find("UIPlayerOne").transform.Find("PlayerOneStatusText").GetComponent<Text>().text = "Get ready...";
                GameObject.Find("UIPlayerTwo").transform.Find("PlayerTwoStatusText").GetComponent<Text>().text = "Wait...";
            }

            return;
        }

        if (_countDown)
        {
            CountDown();

            return;
        }

        if (Input.GetMouseButtonUp(0))
        {
            PlayerMove(_currentPlayer);
        }
    }

    private void CountDown()
    {
        GameObject.Find("UIGameBoard").transform.Find("InfoText").GetComponent<Text>().text = Mathf.FloorToInt(_count % 60).ToString();
        _count -= Time.deltaTime;

        if (_count < 1)
        {
            GameObject.Find("UIPlayerOne").transform.Find("PlayerOneStatusText").GetComponent<Text>().text = "Your turn!";
            GameObject.Find("UIPlayerTwo").transform.Find("PlayerTwoStatusText").GetComponent<Text>().text = "Wait...";
            GameObject.Find("UIGameBoard").transform.Find("InfoText").GetComponent<Text>().text = "";
            _countDown = false;
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

    private void ClearBoard()
    {
        for (int i = 0; i < _boardPieces.Count; i++)
        {
            Destroy(_boardPieces[i]);
        }

        _boardPieces.Clear();
    }

    private void PlayerMove(Player player)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (_boxCollider2D.OverlapPoint(mousePosition))
        {
            Debug.Log("X: " + Math.Round(mousePosition.x).ToString() + " Y: " + Math.Round(mousePosition.y).ToString());
            Debug.Log(SquareClicked(player, mousePosition).name);
            Debug.Log("Winner:" + EvaluateBoardCondition());

            if (EvaluateBoardCondition() > 0)
            {
                ResetBoard();
            }
        }
    }

    private void ResetBoard()
    {
        ClearBoard();
        SetupGrid();
    }

    private void UpdateCurrentPlayer()
    {
        if (_currentPlayer == _playerOne)
        {
            _currentPlayer = _playerTwo;

            GameObject.Find("UIPlayerOne").transform.Find("PlayerOneStatusText").GetComponent<Text>().text = "Wait...";
            GameObject.Find("UIPlayerTwo").transform.Find("PlayerTwoStatusText").GetComponent<Text>().text = "Your turn!";
        }
        else if (_currentPlayer == _playerTwo)
        {
            _currentPlayer = _playerOne;

            GameObject.Find("UIPlayerOne").transform.Find("PlayerOneStatusText").GetComponent<Text>().text = "Your turn!";
            GameObject.Find("UIPlayerTwo").transform.Find("PlayerTwoStatusText").GetComponent<Text>().text = "Wait...";
        }
    }

    private int EvaluateBoardCondition()
    {
        int boardCondition = 0;

        if (_grid[0, 0] != 0 && _grid[0, 0] == _grid[1, 0] && _grid[1, 0] == _grid[2, 0])
        {
            boardCondition = _grid[0, 0];
        }

        if (_grid[0, 1] != 0 && _grid[0, 1] == _grid[1, 1] && _grid[1, 1] == _grid[2, 1])
        {
            boardCondition = _grid[0, 1];
        }

        if (_grid[0, 2] != 0 && _grid[0, 2] == _grid[1, 2] && _grid[1, 2] == _grid[2, 2])
        {
            boardCondition = _grid[0, 2];
        }

        if (_grid[0, 0] != 0 && _grid[0, 0] == _grid[0, 1] && _grid[0, 1] == _grid[0, 2])
        {
            boardCondition = _grid[0, 0];
        }

        if (_grid[1, 0] != 0 && _grid[1, 0] == _grid[1, 1] && _grid[1, 1] == _grid[1, 2])
        {
            boardCondition = _grid[1, 0];
        }

        if (_grid[2, 0] != 0 && _grid[2, 0] == _grid[2, 1] && _grid[2, 1] == _grid[2, 2])
        {
            boardCondition = _grid[2, 0];
        }

        if (_grid[0, 0] != 0 && _grid[0, 0] == _grid[1, 1] && _grid[1, 1] == _grid[2, 2])
        {
            boardCondition = _grid[0, 0];
        }

        if (_grid[0, 2] != 0 && _grid[0, 2] == _grid[1, 1] && _grid[1, 1] == _grid[2, 0])
        {
            boardCondition = _grid[0, 0];
        }

        if (boardCondition == 0 && _boardPieces.Count >= 9)
        {
            boardCondition = 3;
        }

        if (boardCondition == 1)
        {
            GameObject.Find("UIPlayerOne").transform.Find("PlayerOneStatusText").GetComponent<Text>().text = "Winner!";
            GameObject.Find("UIPlayerTwo").transform.Find("PlayerTwoStatusText").GetComponent<Text>().text = "You loose!";
        }

        if (boardCondition == 2)
        {
            GameObject.Find("UIPlayerOne").transform.Find("PlayerOneStatusText").GetComponent<Text>().text = "You loose!";
            GameObject.Find("UIPlayerTwo").transform.Find("PlayerTwoStatusText").GetComponent<Text>().text = "Winner!";
        }

        if (boardCondition == 3)
        {
            GameObject.Find("UIPlayerOne").transform.Find("PlayerOneStatusText").GetComponent<Text>().text = "Draw!";
            GameObject.Find("UIPlayerTwo").transform.Find("PlayerTwoStatusText").GetComponent<Text>().text = "Draw!";
        }

        return boardCondition;
    }

    private GameObject SquareClicked(Player player, Vector2 mousePosition)
    {
        var anchor = new GameObject();

        // TopLeft square clicked
        if (_grid[0, 0] == 0 && Math.Round(mousePosition.x) >= -4 && Math.Round(mousePosition.x) <= -2 && Math.Round(mousePosition.y) >= 2 && Math.Round(mousePosition.y) <= 4)
        {
            _grid[0, 0] = player.GamePieceValue;

            anchor = GameObject.Find("AnchorTopLeft");

            var boardPieace = Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);

            _boardPieces.Add(boardPieace);

            UpdateCurrentPlayer();
        }

        // TopMiddle square clicked
        if (_grid[1, 0] == 0 && Math.Round(mousePosition.x) >= -1 && Math.Round(mousePosition.x) <= 1 && Math.Round(mousePosition.y) >= 2 && Math.Round(mousePosition.y) <= 4)
        {
            _grid[1, 0] = player.GamePieceValue;

            anchor = GameObject.Find("AnchorTopMiddle");

            var boardPieace = Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);

            _boardPieces.Add(boardPieace);

            UpdateCurrentPlayer();
        }

        // TopRight square clicked
        if (_grid[2, 0] == 0 && Math.Round(mousePosition.x) >= 2 && Math.Round(mousePosition.x) <= 4 && Math.Round(mousePosition.y) >= 2 && Math.Round(mousePosition.y) <= 4)
        {
            _grid[2, 0] = player.GamePieceValue;

            anchor = GameObject.Find("AnchorTopRight");

            var boardPieace = Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);

            _boardPieces.Add(boardPieace);

            UpdateCurrentPlayer();
        }

        // MiddleLeft square clicked
        if (_grid[0, 1] == 0 && Math.Round(mousePosition.x) >= -4 && Math.Round(mousePosition.x) <= -2 && Math.Round(mousePosition.y) >= -1 && Math.Round(mousePosition.y) <= 1)
        {
            _grid[0, 1] = player.GamePieceValue;

            anchor = GameObject.Find("AnchorMiddleLeft");

            var boardPieace = Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);

            _boardPieces.Add(boardPieace);

            UpdateCurrentPlayer();
        }

        // Middle square clicked
        if (_grid[1, 1] == 0 && Math.Round(mousePosition.x) >= -1 && Math.Round(mousePosition.x) <= 1 && Math.Round(mousePosition.y) >= -1 && Math.Round(mousePosition.y) <= 1)
        {
            _grid[1, 1] = player.GamePieceValue;

            anchor = GameObject.Find("AnchorMiddle");

            var boardPieace = Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);

            _boardPieces.Add(boardPieace);

            UpdateCurrentPlayer();
        }

        // MiddleRight square clicked
        if (_grid[2, 1] == 0 && Math.Round(mousePosition.x) >= 2 && Math.Round(mousePosition.x) <= 4 && Math.Round(mousePosition.y) >= -1 && Math.Round(mousePosition.y) <= 1)
        {
            _grid[2, 1] = player.GamePieceValue;

            anchor = GameObject.Find("AnchorMiddleRight");

            var boardPieace = Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);

            _boardPieces.Add(boardPieace);

            UpdateCurrentPlayer();
        }

        // BottomLeft square clicked
        if (_grid[0, 2] == 0 && Math.Round(mousePosition.x) >= -4 && Math.Round(mousePosition.x) <= -2 && Math.Round(mousePosition.y) >= -4 && Math.Round(mousePosition.y) <= -2)
        {
            _grid[0, 2] = player.GamePieceValue;

            anchor = GameObject.Find("AnchorBottomLeft");

            var boardPieace = Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);

            _boardPieces.Add(boardPieace);

            UpdateCurrentPlayer();
        }

        // BottomMiddle square clicked
        if (_grid[1, 2] == 0 && Math.Round(mousePosition.x) >= -1 && Math.Round(mousePosition.x) <= 1 && Math.Round(mousePosition.y) >= -4 && Math.Round(mousePosition.y) <= -2)
        {
            _grid[1, 2] = player.GamePieceValue;

            anchor = GameObject.Find("AnchorBottomMiddle");

            var boardPieace = Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);

            _boardPieces.Add(boardPieace);

            UpdateCurrentPlayer();
        }

        // BottomRight square clicked
        if (_grid[2, 2] == 0 && Math.Round(mousePosition.x) >= 2 && Math.Round(mousePosition.x) <= 4 && Math.Round(mousePosition.y) >= -4 && Math.Round(mousePosition.y) <= -2)
        {
            _grid[2, 2] = player.GamePieceValue;

            anchor = GameObject.Find("AnchorBottomRight");

            var boardPieace = Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);

            _boardPieces.Add(boardPieace);

            UpdateCurrentPlayer();
        }

        return anchor;
    }
}