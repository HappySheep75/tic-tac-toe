using System;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;

    private int[,] _grid;

    private Player _playerOne;
    private Player _playerTwo;

    private int _playerTurn;

    [SerializeField] private GameObject _nought;
    [SerializeField] private GameObject _cross;

    // Start is called before the first frame update
    private void Start()
    {
        _grid = new int[3, 3];
        _boxCollider2D = GetComponent<BoxCollider2D>();

        _playerOne = GameObject.Find("PlayerOne").GetComponent<Player>();
        _playerTwo = GameObject.Find("PlayerTwo").GetComponent<Player>();

        _playerTurn = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && _playerTurn == 1)
        {
            PlayerMove(_playerOne);
            _playerTurn = 2;
        }
        else if (Input.GetMouseButtonUp(0) && _playerTurn == 2)
        {
            PlayerMove(_playerTwo);
            _playerTurn = 1;
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

    private GameObject SquareClicked(Player player, Vector2 mousePosition)
    {
        var anchor = new GameObject();

        // TopLeft square clicked
        if (Math.Round(mousePosition.x) >= -4 && Math.Round(mousePosition.x) <= -2 && Math.Round(mousePosition.y) >= 2 && Math.Round(mousePosition.y) <= 4)
        {
            anchor = GameObject.Find("AnchorTopLeft");

            Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);
        }

        // TopMiddle square clicked
        if (Math.Round(mousePosition.x) >= -1 && Math.Round(mousePosition.x) <= 1 && Math.Round(mousePosition.y) >= 2 && Math.Round(mousePosition.y) <= 4)
        {
            anchor = GameObject.Find("AnchorTopMiddle");

            Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);
        }

        // TopRight square clicked
        if (Math.Round(mousePosition.x) >= 2 && Math.Round(mousePosition.x) <= 4 && Math.Round(mousePosition.y) >= 2 && Math.Round(mousePosition.y) <= 4)
        {
            anchor = GameObject.Find("AnchorTopRight");

            Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);
        }

        // MiddleLeft square clicked
        if (Math.Round(mousePosition.x) >= -4 && Math.Round(mousePosition.x) <= -2 && Math.Round(mousePosition.y) >= -1 && Math.Round(mousePosition.y) <= 1)
        {
            anchor = GameObject.Find("AnchorMiddleLeft");

            Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);
        }

        // Middle square clicked
        if (Math.Round(mousePosition.x) >= -1 && Math.Round(mousePosition.x) <= 1 && Math.Round(mousePosition.y) >= -1 && Math.Round(mousePosition.y) <= 1)
        {
            anchor = GameObject.Find("AnchorMiddle");

            Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);
        }

        // MiddleRight square clicked
        if (Math.Round(mousePosition.x) >= 2 && Math.Round(mousePosition.x) <= 4 && Math.Round(mousePosition.y) >= -1 && Math.Round(mousePosition.y) <= 1)
        {
            anchor = GameObject.Find("AnchorMiddleRight");

            Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);
        }

        // BottomRight square clicked
        if (Math.Round(mousePosition.x) >= -4 && Math.Round(mousePosition.x) <= -2 && Math.Round(mousePosition.y) >= -4 && Math.Round(mousePosition.y) <= -2)
        {
            anchor = GameObject.Find("AnchorBottomLeft");

            Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);
        }

        // BottomMiddle square clicked
        if (Math.Round(mousePosition.x) >= -1 && Math.Round(mousePosition.x) <= 1 && Math.Round(mousePosition.y) >= -4 && Math.Round(mousePosition.y) <= -2)
        {
            anchor = GameObject.Find("AnchorBottomMiddle");

            Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);
        }

        // BottomRight square clicked
        if (Math.Round(mousePosition.x) >= 2 && Math.Round(mousePosition.x) <= 4 && Math.Round(mousePosition.y) >= -4 && Math.Round(mousePosition.y) <= -2)
        {
            anchor = GameObject.Find("AnchorBottomRight");

            Instantiate(player.GamePiece, anchor.transform.position, anchor.transform.rotation);
        }

        return anchor;
    }
}
