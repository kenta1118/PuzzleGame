using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DefenseCubeController : MonoBehaviour
{
    public string DefenseCubeTag = "DefenseTag";

    void Start()
    {
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
                if (hit.collider.gameObject.CompareTag(DefenseCubeTag))
                {
                    hit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;
                    hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    GameObject director = GameObject.Find("GameDirector");
                    director.GetComponent<GameDirector>().ChangeSpriteToDefense();
                    director.GetComponent<GameDirector>().count++;
                    if (director.GetComponent<GameDirector>().count > 5)
                    {
                        hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    }
                }
            }
        }

        if(transform.position.y < 5.4f)
        {
            transform.position = new Vector3(transform.position.x, 8.0f, transform.position.z);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }
}
