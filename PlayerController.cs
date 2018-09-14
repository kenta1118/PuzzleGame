using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    GameObject director;
    GameObject rabbit;
    public int EnemyDamage_count = 0;
    public float DefenseTurn_time = 0f;
    public bool Defense_flag = false;
    public bool End_flag = false;
    public float Player_time = 0f;
    public float Hit_time;
    public AnimatorStateInfo stateInfo;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        director = GameObject.Find("GameDirector");
        rabbit = GameObject.Find("Rabbit");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Standby()
    {
        animator.SetTrigger("IsStandby");
        if(stateInfo.normalizedTime <= 1)
        {
            animator.SetTrigger("IsIdle2");
        }
    }

    public void Attack()
    {
        animator.ResetTrigger("IsStandby");
        animator.ResetTrigger("IsIdle2");
        DefenseTurn_time += Time.deltaTime;
        switch (this.director.GetComponent<GameDirector>().Attack_count)
        {
            case 1:
                animator.SetTrigger("IsAttack1");
                animator.SetBool("Idle2", true);
                Observable.NextFrame().Subscribe(_ => animator.ResetTrigger("IsAttack1"));
                EnemyDamage_count = 1;
                if (DefenseTurn_time >= 3.0f)
                {
                    director.GetComponent<GameDirector>().ChangeDefenseToNoImage();
                }
                break;

            case 2:
                animator.SetTrigger("IsAttack1");
                animator.SetTrigger("IsAttack2");
                animator.SetBool("Idle2", true);
                EnemyDamage_count = 2;
                if (DefenseTurn_time >= 4.0f)
                {
                    director.GetComponent<GameDirector>().ChangeDefenseToNoImage();
                }
                break;

            case 3:
                animator.SetTrigger("IsAttack1");
                animator.SetTrigger("IsAttack2");
                animator.SetBool("Idle2", true);
                animator.SetTrigger("IsAttack3");
                EnemyDamage_count = 3;
                if (DefenseTurn_time >= 6.0f)
                {
                    director.GetComponent<GameDirector>().ChangeDefenseToNoImage();
                }
                break;

            case 4:
                animator.SetTrigger("IsAttack1");
                animator.SetTrigger("IsAttack2");
                animator.SetTrigger("IsAttack3");
                animator.SetTrigger("IsAttack4");
                animator.SetBool("Idle2", true);
                EnemyDamage_count = 4;
                if (DefenseTurn_time >= 7.5f)
                {
                    director.GetComponent<GameDirector>().ChangeDefenseToNoImage();
                }
                break;

            case 5:
                animator.SetTrigger("IsAttack1");
                animator.SetTrigger("IsAttack2");
                animator.SetTrigger("IsAttack3");
                animator.SetTrigger("IsAttack4");
                animator.SetTrigger("IsAttack5");
                animator.SetBool("Idle2", true);
                EnemyDamage_count = 5;
                if (DefenseTurn_time >= 10f)
                {
                    director.GetComponent<GameDirector>().ShowEnemyTurnText();
                }
                break;

            default:
                break;
        }
        this.rabbit.GetComponent<RabbitController>().RabbitDamage();
    }

    public void Damage()
    {
        Player_time += Time.deltaTime;
        if (Player_time >= Hit_time)
        {
            if (Defense_flag == true)
            {
                switch (this.rabbit.GetComponent<RabbitController>().PlayerDamage_count)
                {
                    case 1:
                        animator.SetTrigger("IsDefenseDamage1");
                        animator.SetTrigger("IsDefense");
                        animator.SetBool("Idle2", true);
                        director.GetComponent<GameDirector>().ShowReadyText();
                        break;

                    default:
                        break;
                }
            }
            else
            {
                switch (this.rabbit.GetComponent<RabbitController>().PlayerDamage_count)
                {
                    case 1:
                        animator.SetTrigger("IsDamage");
                        animator.SetBool("Idle2", true);
                        director.GetComponent<GameDirector>().ShowReadyText();
                        break;
                }
            }
        }
    }

    public void Defense()
    {
        if (director.GetComponent<GameDirector>().AllDefense_count == 5)
        {
            animator.SetTrigger("IsDefense2");
            Defense_flag = true;
            director.GetComponent<GameDirector>().ShowEnemyTurnText();
        }
        else
        {
            animator.SetTrigger("IsDefense");
            animator.SetBool("Idle2", false);
            Defense_flag = true;
            director.GetComponent<GameDirector>().ShowEnemyTurnText();
        }
    }
}
