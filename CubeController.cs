using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeController : MonoBehaviour
{

    public Material[] mate;
    public bool at_flag = false;
    public bool df_flag = false;
    public bool tap_flag = false;
    GameObject director;

    void Start()
    {
        this.director = GameObject.Find("GameDirector");
        int number = Random.Range(0, 2);
        if (number == 0)
        {
            this.GetComponent<Renderer>().material = mate[0];
            this.GetComponent<CubeController>().at_flag = true;
        }
        else if (number == 1)
        {
            this.GetComponent<Renderer>().material = mate[1];
            this.GetComponent<CubeController>().df_flag = true;
        }
        this.GetComponent<Rigidbody>().isKinematic = false;
        transform.position = Vector3.Slerp(new Vector3(transform.position.x, transform.position.y, transform.position.z),
            new Vector3(transform.position.x, 5.75f, transform.position.z), Time.deltaTime);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.GetComponent<CubeController>().at_flag == true
                   && hit.collider.gameObject.GetComponent<CubeController>().tap_flag == false)
                {
                    hit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;
                    hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    hit.collider.gameObject.GetComponent<CubeController>().tap_flag = true;
                    GameObject director = GameObject.Find("GameDirector");
                    director.GetComponent<GameDirector>().ChangeSpriteToAttack();
                    director.GetComponent<GameDirector>().count++;
                    if (director.GetComponent<GameDirector>().count > 5)
                    {
                        hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        hit.collider.gameObject.GetComponent<CubeController>().tap_flag = false; ;
                    }
                }
                else if (hit.collider.gameObject.GetComponent<CubeController>().df_flag == true
                    && hit.collider.gameObject.GetComponent<CubeController>().tap_flag == false)
                {
                    hit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;
                    hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    hit.collider.gameObject.GetComponent<CubeController>().tap_flag = true;
                    GameObject director = GameObject.Find("GameDirector");
                    director.GetComponent<GameDirector>().ChangeSpriteToDefense();
                    director.GetComponent<GameDirector>().count++;
                    if (director.GetComponent<GameDirector>().count > 5)
                    {
                        hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        hit.collider.gameObject.GetComponent<CubeController>().tap_flag = false;
                    }
                }
            }
        }

        if (transform.position.y < 5.4f)
        {
            transform.position = new Vector3(transform.position.x, 8.0f, transform.position.z);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            at_flag = false;
            df_flag = false;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void CubeGene()
    {
        int number = Random.Range(0, 2);
        if (number == 0)
        {
            this.GetComponent<Renderer>().material = mate[0];
            this.GetComponent<CubeController>().at_flag = true;
        }
        else if (number == 1)
        {
            this.GetComponent<Renderer>().material = mate[1];
            this.GetComponent<CubeController>().df_flag = true;
        }
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<BoxCollider>().enabled = true;
        transform.position = Vector3.Slerp(new Vector3(transform.position.x, transform.position.y, transform.position.z),
            new Vector3(transform.position.x, 5.75f, transform.position.z), Time.deltaTime);
        tap_flag = false;
        director.GetComponent<GameDirector>().time = 0f;
        director.GetComponent<GameDirector>().time2 = 0f;
        director.GetComponent<GameDirector>().time3 = 0f;
        director.GetComponent<GameDirector>().Attack_count = 0;
        director.GetComponent<GameDirector>().Defense_count = 0;
        director.GetComponent<GameDirector>().AllDefense_count = 0;
    }
}
