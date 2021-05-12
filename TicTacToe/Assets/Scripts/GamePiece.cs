using UnityEngine;

public class GamePiece : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int _value;

    public int Value
    {
        get
        {
            return _value;
        }

        set
        {
            _value = value;
        }
    }

    [SerializeField] private Sprite _winnerSprite;

    public Sprite WinnerSprite
    {
        get
        {
            return _winnerSprite;
        }

        set
        {
            _winnerSprite = value;
        }
    }
}
