using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                {
                    Debug.LogError("There's no active GameManager Object");
                }
            }
            return _instance;
        }
    }

    public enum GameStatus { PREGAME, SINGLE, LOCALMULTY, MULTY, GAMESET, GAMEOVER }
    public enum Winner { NONE, PLAYER, ENEMY, PLAYER1, PLAYER2 }


    public GameStatus _gameStatus = GameStatus.PREGAME;
    public Winner _winner = Winner.NONE;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
