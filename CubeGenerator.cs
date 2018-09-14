using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject AttackCubePrefab;
    public GameObject DefenseCubePrefab;
    GameObject director;

    // Use this for initialization
    void Start()
    {
        director = GameObject.Find("GameDirector");
        int number = Random.Range(0, 2);
        if (number == 0)
        {
            Instantiate(AttackCubePrefab, transform.position, transform.rotation);
        }
        else if (number == 1)
        {
            Instantiate(DefenseCubePrefab, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CubeGene()
    {
        int number = Random.Range(0, 2);
        if (number == 0)
        {
            Instantiate(AttackCubePrefab, transform.position, transform.rotation);
        }
        else if (number == 1)
        {
            Instantiate(DefenseCubePrefab, transform.position, transform.rotation);
        }
    }
}
