using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{

    public Sprite AttackSprite;
    public Sprite DefenseSprite;
    public Sprite RecoverySprite;
    public Sprite NoImage;
    GameObject strategy1;
    GameObject strategy2;
    GameObject strategy3;
    GameObject strategy4;
    GameObject strategy5;
    GameObject AttackCube;
    GameObject FinishText;
    GameObject FightText;
    GameObject EnemyTurnText;
    GameObject ReadyText;
    GameObject GoText;
    GameObject player;
    GameObject rabbit;
    GameObject cube1;
    GameObject cube2;
    GameObject cube3;
    GameObject cube4;
    GameObject cube5;
    GameObject cube6;
    GameObject cube7;
    GameObject cube8;
    GameObject cube9;

    public int count = 0;
    public int Attack_count = 0;
    public int Defense_count = 0;
    public float show_time = 3.0f;
    public float life_time = 6.0f;
    public float show_time2 = 9.0f;
    public float life_time2 = 12.0f;
    public float show_time3 = 10.0f;
    public float life_time3 = 20.0f;
    public float show_time4 = 5.0f;
    public float life_time4 = 8.0f;
    public float show_time5 = 9.0f;
    public float life_time5 = 12.0f;
    public float time = 0f;
    public float time2 = 0f;
    public float time3 = 0f;
    public bool Finish_flag = false;
    public bool Fight_flag = false;
    public bool End_flag = false;
    public int AllDefense_count = 0;
    private ParticleSystem particle;

    void Start()
    {
        this.strategy1 = GameObject.Find("Strategy1");
        this.strategy2 = GameObject.Find("Strategy2");
        this.strategy3 = GameObject.Find("Strategy3");
        this.strategy4 = GameObject.Find("Strategy4");
        this.strategy5 = GameObject.Find("Strategy5");
        this.AttackCube = GameObject.Find("AttackCube");
        this.FinishText = GameObject.Find("FinishText");
        this.FightText = GameObject.Find("FightText");
        this.EnemyTurnText = GameObject.Find("EnemyTurnText");
        this.ReadyText = GameObject.Find("ReadyText");
        this.GoText = GameObject.Find("GoText");
        this.player = GameObject.Find("Player");
        this.rabbit = GameObject.Find("Rabbit");
        this.cube1 = GameObject.Find("Cube1");
        this.cube2 = GameObject.Find("Cube2");
        this.cube3 = GameObject.Find("Cube3");
        this.cube4 = GameObject.Find("Cube4");
        this.cube5 = GameObject.Find("Cube5");
        this.cube6 = GameObject.Find("Cube6");
        this.cube7 = GameObject.Find("Cube7");
        this.cube8 = GameObject.Find("Cube8");
        this.cube9 = GameObject.Find("Cube9");
    }

    void Update()
    {
        if (this.count >= 5)
        {
            this.count = 5;
        }

        if (this.count == 5)
        {
            ShowFinishText();
        }
    }

    public void ChangeSpriteToAttack()
    {
        switch (count)
        {
            case 0:
                this.strategy1.GetComponent<Image>().sprite = AttackSprite;
                break;

            case 1:
                this.strategy2.GetComponent<Image>().sprite = AttackSprite;
                break;

            case 2:
                this.strategy3.GetComponent<Image>().sprite = AttackSprite;
                break;

            case 3:
                this.strategy4.GetComponent<Image>().sprite = AttackSprite;
                break;

            case 4:
                this.strategy5.GetComponent<Image>().sprite = AttackSprite;
                break;

            default:
                break;
        }

    }

    public void ChangeSpriteToDefense()
    {
        switch (count)
        {
            case 0:
                this.strategy1.GetComponent<Image>().sprite = DefenseSprite;
                AllDefense_count++;
                break;

            case 1:
                this.strategy2.GetComponent<Image>().sprite = DefenseSprite;
                AllDefense_count++;
                break;

            case 2:
                this.strategy3.GetComponent<Image>().sprite = DefenseSprite;
                AllDefense_count++;
                break;

            case 3:
                this.strategy4.GetComponent<Image>().sprite = DefenseSprite;
                AllDefense_count++;
                break;

            case 4:
                this.strategy5.GetComponent<Image>().sprite = DefenseSprite;
                AllDefense_count++;
                break;

            default:
                break;
        }
    }

    public void ChangeSpriteToRecovery()
    {

    }

    public void ChangeAttackToNoImage()
    {
        if (this.strategy1.GetComponent<Image>().sprite == AttackSprite)
        {
            this.strategy1.GetComponent<Image>().sprite = NoImage;
            Attack_count++;
        }
        if (this.strategy2.GetComponent<Image>().sprite == AttackSprite)
        {
            this.strategy2.GetComponent<Image>().sprite = NoImage;
            Attack_count++;
        }
        if (this.strategy3.GetComponent<Image>().sprite == AttackSprite)
        {
            this.strategy3.GetComponent<Image>().sprite = NoImage;
            Attack_count++;
        }
        if (this.strategy4.GetComponent<Image>().sprite == AttackSprite)
        {
            this.strategy4.GetComponent<Image>().sprite = NoImage;
            Attack_count++;
        }
        if (this.strategy5.GetComponent<Image>().sprite == AttackSprite)
        {
            this.strategy5.GetComponent<Image>().sprite = NoImage;
            Attack_count++;
        }
        this.player.GetComponent<PlayerController>().Attack();
    }

    public void ChangeDefenseToNoImage()
    {
        if (this.strategy1.GetComponent<Image>().sprite == DefenseSprite)
        {
            this.strategy1.GetComponent<Image>().sprite = NoImage;
            Defense_count++;
        }
        if (this.strategy2.GetComponent<Image>().sprite == DefenseSprite)
        {
            this.strategy2.GetComponent<Image>().sprite = NoImage;
            Defense_count++;
        }
        if (this.strategy3.GetComponent<Image>().sprite == DefenseSprite)
        {
            this.strategy3.GetComponent<Image>().sprite = NoImage;
            Defense_count++;
        }
        if (this.strategy4.GetComponent<Image>().sprite == DefenseSprite)
        {
            this.strategy4.GetComponent<Image>().sprite = NoImage;
            Defense_count++;
        }
        if (this.strategy5.GetComponent<Image>().sprite == DefenseSprite)
        {
            this.strategy5.GetComponent<Image>().sprite = NoImage;
            Defense_count++;
        }
        this.player.GetComponent<PlayerController>().Defense();
    }

    public void ShowFinishText()
    {
        time += Time.deltaTime;
        if (time >= show_time)
        {
            this.FinishText.GetComponent<Text>().enabled = true;
        }

        if (time >= life_time)
        {
            this.FinishText.GetComponent<Text>().enabled = false;
            this.player.GetComponent<PlayerController>().Standby();
        }

        if (time >= show_time2)
        {
            this.FightText.GetComponent<Text>().enabled = true;
        }

        if (time >= life_time2)
        {
            this.FightText.GetComponent<Text>().enabled = false;
            if (AllDefense_count == 5)
            {
                ChangeDefenseToNoImage();
            }
            else
            {
                ChangeAttackToNoImage();
            }
        }
    }

    public void ShowEnemyTurnText()
    {
        time2 += Time.deltaTime;
        if (time2 >= show_time3)
        {
            this.EnemyTurnText.GetComponent<Text>().enabled = true;
        }

        if (time2 > life_time3)
        {
            this.EnemyTurnText.GetComponent<Text>().enabled = false;
            this.rabbit.GetComponent<RabbitController>().RabbitAttack();
        }
    }

    public void ShowReadyText()
    {
        time3 += Time.deltaTime;
        if(time3 >= show_time4)
        {
            this.ReadyText.GetComponent<Text>().enabled = true;
        }

        if (time3 > life_time4)
        {
            this.ReadyText.GetComponent<Text>().enabled = false;
        }

        if (time3 >= show_time5)
        {
            this.GoText.GetComponent<Text>().enabled = true;
        }

        if (time3 > life_time5)
        {
            this.GoText.GetComponent<Text>().enabled = false;

            count = 0;
            if (cube1.GetComponent<CubeController>().tap_flag == true)
            {
                cube1.GetComponent<CubeController>().CubeGene();
            }
            if (cube2.GetComponent<CubeController>().tap_flag == true)
            {
                cube2.GetComponent<CubeController>().CubeGene();
            }
            if (cube3.GetComponent<CubeController>().tap_flag == true)
            {
                cube3.GetComponent<CubeController>().CubeGene();
            }
            if (cube4.GetComponent<CubeController>().tap_flag == true)
            {
                cube4.GetComponent<CubeController>().CubeGene();
            }
            if (cube5.GetComponent<CubeController>().tap_flag == true)
            {
                cube5.GetComponent<CubeController>().CubeGene();
            }
            if (cube6.GetComponent<CubeController>().tap_flag == true)
            {
                cube6.GetComponent<CubeController>().CubeGene();
            }
            if (cube7.GetComponent<CubeController>().tap_flag == true)
            {
                cube7.GetComponent<CubeController>().CubeGene();
            }
            if (cube8.GetComponent<CubeController>().tap_flag == true)
            {
                cube8.GetComponent<CubeController>().CubeGene();
            }
            if (cube9.GetComponent<CubeController>().tap_flag == true)
            {
                cube9.GetComponent<CubeController>().CubeGene();
            }
        }
    }
}
