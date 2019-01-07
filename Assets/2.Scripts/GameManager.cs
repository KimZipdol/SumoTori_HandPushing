using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        DontDestroyOnLoad(this);
        StartCoroutine(GameStatusChk());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GameStatusChk()
    {
        while (_gameStatus == GameStatus.PREGAME)
        {
            yield return new WaitForSeconds(0.3f);
            switch (_gameStatus)
            {
                case GameStatus.PREGAME:
                    break;
                case GameStatus.SINGLE:
                case GameStatus.LOCALMULTY:
                    StartCoroutine(WinnerChk());
                    break;
                case GameStatus.MULTY:
                    break;
                case GameStatus.GAMESET:
                    break;
                case GameStatus.GAMEOVER:
                    GameOver();
                    break;
                default:
                    break;
            }
        }
    }

    IEnumerator WinnerChk()
    {
        yield return new WaitForSeconds(0.3f);
        switch (_winner)
        {
            case Winner.NONE:
                break;
            case Winner.PLAYER:
                Debug.Log("PlayerWin");
                _gameStatus = GameStatus.GAMESET;
                break;
            case Winner.ENEMY:
                Debug.Log("PlayerLose");
                _gameStatus = GameStatus.GAMEOVER;
                break;
            case Winner.PLAYER1:
                Debug.Log("Player1Win");
                _gameStatus = GameStatus.GAMESET;
                break;
            case Winner.PLAYER2:
                Debug.Log("Player2Win");
                _gameStatus = GameStatus.GAMESET;
                break;
            default:
                break;
        }
    }

    void GameOver()
    {

    }
}
