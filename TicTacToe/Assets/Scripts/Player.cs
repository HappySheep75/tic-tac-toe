using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _gamePiece;

    public GameObject GamePiece
    {
        get
        {
            return _gamePiece;
        }

        set
        {
            _gamePiece = value;
        }
    }

    [SerializeField] private int _gamePieceValue;

    public int GamePieceValue
    {
        get
        {
            return _gamePieceValue;
        }

        set
        {
            _gamePieceValue = value;
        }
    }

    [SerializeField] private float _gameTime = 20.0f;

    public float GameTime
    {
        get
        {
            return _gameTime;
        }

        set
        {
            _gameTime = value;
        }
    }

    [SerializeField] private bool _isYourTurn = false;

    public bool IsYourTurn
    {
        get
        {
            return _isYourTurn;
        }

        set
        {
            _isYourTurn = value;
        }
    }

    private void Update()
    {
        if (_isYourTurn)
        {
            _gameTime -= Time.deltaTime;
        }
    }
}
