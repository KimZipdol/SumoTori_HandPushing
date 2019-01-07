using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIState { CHASE, ATTACK, DEAD, PLAYERDEAD }

public class EnemyAI : MonoBehaviour
{
    public GameObject target;
    public WaitForSeconds ws = new WaitForSeconds(0.1f);
    public float atkRange = 1f;
    public float moveSpd = 0.01f;
    public Animator npcAnim;

    AIState _aiState = AIState.CHASE;
    int hashAtk;
    bool isMoving = false;
    float targetDist;

    private void Start()
    {
        hashAtk = Animator.StringToHash("Atk");
    }

    void OnEnable()
    {
        StartCoroutine(StateChange());
        StartCoroutine(Action());
    }

    // Update is called once per frame
    void Update()
    {
        targetDist = (target.transform.position - transform.position).magnitude;
        if(isMoving)
        {
            transform.Translate(target.transform.position * Time.deltaTime * moveSpd, Space.World);
            transform.LookAt(target.transform);
        }
    }

    /// <summary>
    /// _aiState를 ws마다 바꿔줌.
    /// </summary>
    /// <returns></returns>
    IEnumerator StateChange()
    {
        while(_aiState!=AIState.DEAD && _aiState!=AIState.PLAYERDEAD)
        {
            yield return ws;
            if(targetDist<=atkRange)
            {
                _aiState = AIState.ATTACK;
            }
            else
            {
                _aiState = AIState.CHASE;
            }
        }
    }

    /// <summary>
    /// _aiState에 따른 행동
    /// </summary>
    /// <returns></returns>
    IEnumerator Action()
    {
        while(true)
        {
            yield return ws;
            switch (_aiState)
            {
                case AIState.CHASE:
                    isMoving = true;
                    break;
                case AIState.ATTACK:
                    isMoving = false;
                    npcAnim.SetTrigger(hashAtk);
                    yield return new WaitForSeconds(0.5f);
                    break;
                case AIState.DEAD:
                    StopCoroutine(StateChange());
                    GameSet(GameManager.Winner.PLAYER);
                    break;
                case AIState.PLAYERDEAD:
                    StopCoroutine(StateChange());
                    GameSet(GameManager.Winner.ENEMY);
                    break;
                default:
                    break;
            }
        }
    }

    void GameSet(GameManager.Winner winner)
    {
        StopCoroutine(Action());
        if (winner==GameManager.Winner.ENEMY)
        {
            GameManager.Instance._winner = GameManager.Winner.ENEMY;
        }
        else if(winner==GameManager.Winner.PLAYER)
        {
            GameManager.Instance._winner = GameManager.Winner.PLAYER;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collider" + other.gameObject.name + "enter");
        if (other.gameObject.CompareTag("GROUND"))
        {
            _aiState = AIState.DEAD;
        }
    }
}
