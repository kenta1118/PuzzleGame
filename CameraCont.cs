using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCont : MonoBehaviour
{
    Vector3 targetPos = new Vector3(0f, 9.05f, -8f);
    Vector3 targetPos2 = new Vector3(0f, 7.069633f, -8f);


    // Use this for initialization
    void Start()
    {
        
}

    // Update is called once per frame
    void Update()
    {
        GameObject director = GameObject.Find("GameDirector");
        if (director.GetComponent<GameDirector>().Finish_flag == true)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 45);
            transform.position = Vector3.Slerp(transform.position, targetPos, Time.deltaTime);
            
        }
    }
}
