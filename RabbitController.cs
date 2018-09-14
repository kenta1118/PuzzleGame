using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : MonoBehaviour
{

    Animator rabbitAnimator;
    GameObject player;
    GameObject director;
    public float Rabbit_time = 0f;
    public float Damage_time;
    public int PlayerDamage_count = 0;

    // Use this for initialization
    void Start()
    {
        this.rabbitAnimator = GetComponent<Animator>();
        this.player = GameObject.Find("Player");
        this.director = GameObject.Find("GameDirector");
        Rabbit_time = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RabbitDamage()
    {
        Rabbit_time += Time.deltaTime;
        if (Rabbit_time >= Damage_time)
        {
            switch (this.player.GetComponent<PlayerController>().EnemyDamage_count)
            {
                case 1:
                    rabbitAnimator.SetTrigger("RabbitDamage");
                    rabbitAnimator.SetTrigger("AfterRabbitIdle1");
                    break;

                case 2:
                    rabbitAnimator.SetTrigger("RabbitDamage");
                    rabbitAnimator.SetTrigger("RabbitDamage2");
                    rabbitAnimator.SetTrigger("AfterRabbitIdle2");
                    break;

                case 3:
                    rabbitAnimator.SetTrigger("RabbitDamage");
                    rabbitAnimator.SetTrigger("RabbitDamage2");
                    rabbitAnimator.SetTrigger("RabbitDamage3");
                    rabbitAnimator.SetTrigger("AfterRabbitIdle3");
                    break;

                case 4:
                    rabbitAnimator.SetTrigger("RabbitDamage");
                    rabbitAnimator.SetTrigger("RabbitDamage2");
                    rabbitAnimator.SetTrigger("RabbitDamage3");
                    rabbitAnimator.SetTrigger("RabbitDamage4");
                    rabbitAnimator.SetTrigger("AfterRabbitIdle4");
                    break;

                case 5:
                    rabbitAnimator.SetTrigger("RabbitDamage");
                    rabbitAnimator.SetTrigger("RabbitDamage2");
                    rabbitAnimator.SetTrigger("RabbitDamage3");
                    rabbitAnimator.SetTrigger("RabbitDamage4");
                    rabbitAnimator.SetTrigger("RabbitDamage5");
                    rabbitAnimator.SetTrigger("AfterRabbitIdle5");
                    break;
            }
        }
    }

    public void RabbitAttack()
    {
        if (director.GetComponent<GameDirector>().AllDefense_count == 5)
        {
            rabbitAnimator.SetTrigger("RabbitAttack2");
            rabbitAnimator.SetTrigger("AfterRabbitIdle6");
            PlayerDamage_count = 1;
            player.GetComponent<PlayerController>().Damage();
        }
        else
        {
            rabbitAnimator.SetTrigger("RabbitAttack");
            rabbitAnimator.SetTrigger("AfterRabbitIdle6");
            PlayerDamage_count = 1;
            player.GetComponent<PlayerController>().Damage();
        }
    }
}
