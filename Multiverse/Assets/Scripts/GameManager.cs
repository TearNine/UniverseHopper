using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int moves = 0;
    int par = 3;

    public GameObject movesText;
    public GameObject winText;
    public GameObject quitButton;
    void Start()
    {
        UpdateMovesPar();
    }

    void UpdateMovesPar()
    {
        if (moves > par)
        {
            movesText.GetComponent<UnityEngine.UI.Text>().color = Color.red;
        }
        movesText.GetComponent<UnityEngine.UI.Text>().text = moves + " | " + par;
    }

    public void ExtraMove()
    {
        moves++;
        UpdateMovesPar();
    }
    public void Win()
    {
        winText.SetActive(true);
        quitButton.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
