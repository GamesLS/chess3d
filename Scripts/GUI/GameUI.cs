using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    void Awake()
    {
        ChessBoard.OnTeamTurnChanged += UpdateTeamTurn;
    }

    void UpdateTeamTurn()
    {
        _turnLabel.text = "Now is the turn of a " +
            (ChessBoard.WhoseMove == Unit.Team.White ? "white" : "black") +
            " team";
        InvertColors(_turnLabelBG, _turnLabel);
    }

    static void InvertColors(Image image, TMP_Text text)
    {
        if(image.color == Color.black)
        {
            image.color = Color.white;
            text.color = Color.black;
        }
        else
        {
            image.color = Color.black;
            text.color = Color.white;
        }
    }



    [SerializeField] TMP_Text _turnLabel;
    [SerializeField] Image _turnLabelBG;
}
