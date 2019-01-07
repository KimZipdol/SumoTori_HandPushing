using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpd;
    public Animator _anim;
    public GameObject opponent;

    int hashAtk;
    float h;
    float v;
    Transform tr;

    private void Start()
    {
        tr = transform;
        hashAtk = Animator.StringToHash("Atk");
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 moveDir = (Vector3.forward * h) * -1 + (Vector3.right * v);

        tr.Translate(moveDir.normalized * moveSpd * Time.deltaTime, Space.Self);
        tr.LookAt(opponent.transform);

        if (Input.GetButtonDown("Jump"))
        {
            _anim.SetTrigger(hashAtk);
        }
        //if (GameManager.Instance._gameStatus != GameManager.GameStatus.PREGAME && GameManager.Instance._gameStatus != GameManager.GameStatus.GAMEOVER)
        //{

        //}
    }
    
    //TODO: 승패판정. 게임매니저에 전달.
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
