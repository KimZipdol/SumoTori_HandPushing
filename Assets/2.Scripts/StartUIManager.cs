using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIManager : MonoBehaviour
{
    public void VsComButton()
    {
        GameManager.Instance._gameStatus = GameManager.GameStatus.SINGLE;
        SceneManager.LoadScene("PVE", LoadSceneMode.Single);
    }

    public void VsLocalButton()
    {

    }

    public void VsOnlineButton()
    {

    }
}
