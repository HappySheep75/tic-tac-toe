using System;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;

    private int[,] _grid;

    [SerializeField] private GameObject _nought;
    [SerializeField] private GameObject _cross;

    // Start is called before the first frame update
    private void Start()
    {
        _grid = new int[3, 3];
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (_boxCollider2D.OverlapPoint(mousePosition))
            {
                Debug.Log("X: " + Math.Round(mousePosition.x).ToString() + " Y: " + Math.Round(mousePosition.y).ToString());
                Debug.Log(SquareClicked(mousePosition).name);
            }
        }
    }

    private GameObject SquareClicked(Vector2 mousePosition)
    {
        var anchor = new GameObject();

        // TopLeft square clicked
        if (Math.Round(mousePosition.x) >= -4 && Math.Round(mousePosition.x) <= -2 && Math.Round(mousePosition.y) >= 2 && Math.Round(mousePosition.y) <= 4)
        {
            anchor = GameObject.Find("AnchorTopLeft");

            Instantiate(_nought, anchor.transform.position, anchor.transform.rotation);
        }

        // TopMiddle square clicked
        if (Math.Round(mousePosition.x) >= -1 && Math.Round(mousePosition.x) <= 1 && Math.Round(mousePosition.y) >= 2 && Math.Round(mousePosition.y) <= 4)
        {
            anchor = GameObject.Find("AnchorTopMiddle");

            Instantiate(_cross, anchor.transform.position, anchor.transform.rotation);
        }

        // TopRight square clicked
        if (Math.Round(mousePosition.x) >= 2 && Math.Round(mousePosition.x) <= 4 && Math.Round(mousePosition.y) >= 2 && Math.Round(mousePosition.y) <= 4)
        {
            anchor = GameObject.Find("AnchorTopRight");

            Instantiate(_nought, anchor.transform.position, anchor.transform.rotation);
        }

        // MiddleLeft square clicked
        if (Math.Round(mousePosition.x) >= -4 && Math.Round(mousePosition.x) <= -2 && Math.Round(mousePosition.y) >= -1 && Math.Round(mousePosition.y) <= 1)
        {
            anchor = GameObject.Find("AnchorMiddleLeft");

            Instantiate(_cross, anchor.transform.position, anchor.transform.rotation);
        }

        // Middle square clicked
        if (Math.Round(mousePosition.x) >= -1 && Math.Round(mousePosition.x) <= 1 && Math.Round(mousePosition.y) >= -1 && Math.Round(mousePosition.y) <= 1)
        {
            anchor = GameObject.Find("AnchorMiddle");

            Instantiate(_nought, anchor.transform.position, anchor.transform.rotation);
        }

        // MiddleRight square clicked
        if (Math.Round(mousePosition.x) >= 2 && Math.Round(mousePosition.x) <= 4 && Math.Round(mousePosition.y) >= -1 && Math.Round(mousePosition.y) <= 1)
        {
            anchor = GameObject.Find("AnchorMiddleRight");

            Instantiate(_cross, anchor.transform.position, anchor.transform.rotation);
        }

        // BottomRight square clicked
        if (Math.Round(mousePosition.x) >= -4 && Math.Round(mousePosition.x) <= -2 && Math.Round(mousePosition.y) >= -4 && Math.Round(mousePosition.y) <= -2)
        {
            anchor = GameObject.Find("AnchorBottomLeft");

            Instantiate(_nought, anchor.transform.position, anchor.transform.rotation);
        }

        // BottomMiddle square clicked
        if (Math.Round(mousePosition.x) >= -1 && Math.Round(mousePosition.x) <= 1 && Math.Round(mousePosition.y) >= -4 && Math.Round(mousePosition.y) <= -2)
        {
            anchor = GameObject.Find("AnchorBottomMiddle");

            Instantiate(_cross, anchor.transform.position, anchor.transform.rotation);
        }

        // BottomRight square clicked
        if (Math.Round(mousePosition.x) >= 2 && Math.Round(mousePosition.x) <= 4 && Math.Round(mousePosition.y) >= -4 && Math.Round(mousePosition.y) <= -2)
        {
            anchor = GameObject.Find("AnchorBottomRight");

            Instantiate(_nought, anchor.transform.position, anchor.transform.rotation);
        }

        return anchor;
    }
}