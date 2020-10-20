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
}
