using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Wander,

    Follow,

    Die,

    Attack
};

public class Enemycontroller : MonoBehaviour
{
    public float Attack1; 

    GameObject player;

    public EnemyState currState = EnemyState.Wander;

    public float range;

    public float speed;

    private bool chooseDir = false;

    private bool dead = false;

    private Vector3 randomDir;

    public float attackRange; 

    private bool coolDownAttack = false;

    public float coolDown;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (currState)
        {
            case (EnemyState.Wander):
                Wander();
                break;
            case (EnemyState.Follow):
                Follow();
                break;
            case (EnemyState.Die):
                break;
                case (EnemyState.Attack):
                Attack();
                break;



        }

        if (IsPlayerInRange(range) && currState != EnemyState.Die)
        {
            currState = EnemyState.Follow;
        }
        else if (!IsPlayerInRange(range) && currState != EnemyState.Die)
        {
            currState = EnemyState.Wander;
        }
        if (Vector3.Distance(transform.position, player.transform.position) <= attackRange)
        {
            currState = EnemyState.Attack;
        }
    }






    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }

    private IEnumerator ChooseDirection()
    {
        chooseDir = true;
        yield return new WaitForSeconds(Random.Range(2f, 8f));
        randomDir = new Vector3(0, 0, Random.Range(0, 360));
        Quaternion nextRotation = Quaternion.Euler(randomDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, Random.Range(0.5f, 2.5f));
        chooseDir = false;
    }

    void Wander()
    {
        if (!chooseDir)
        {
            StartCoroutine(ChooseDirection());
        }

        transform.position += -transform.right * speed * Time.deltaTime;
        if (IsPlayerInRange(range))
        {
            currState = EnemyState.Follow;
        }
    }


    void Follow()
    {

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

    }

    void Attack()
    {
        if (!coolDownAttack)
        {
            Gamecontroller.DamagePlayer(Attack1);
            StartCoroutine(CoolDown());
        }
           

    }





    private IEnumerator CoolDown()
    {
        coolDownAttack = true;
        yield return new WaitForSeconds(coolDown);
        coolDownAttack = false;
    }

    
    


    public void Death()
    {
        Destroy(gameObject);
    }



}