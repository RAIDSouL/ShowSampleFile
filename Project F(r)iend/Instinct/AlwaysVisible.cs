using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlwaysVisible : MonoBehaviour
{
    public Material Old;
    public Material New;
    float t = 0f;
    bool isEnable = false;
    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position) < 20)
        {
            if(isEnable){
                t += Time.deltaTime;
                if(t > 3 && !Input.GetKey(KeyCode.LeftAlt))
                {
                    this.GetComponent<Renderer>().material = Old;
                    isEnable = false;
                    t = 0f;
                }
            }
            if(Input.GetKeyDown(KeyCode.LeftAlt))
            {
                this.GetComponent<Renderer>().material = New;
                isEnable = true;
            }
            if(Input.GetKeyUp(KeyCode.LeftAlt) && t > 3.0f)
            {
                this.GetComponent<Renderer>().material = Old;
                isEnable = false;
                t = 0f;
            }
        }
        else
        {
            this.GetComponent<Renderer>().material = Old;
            isEnable = false;
        }
    }

}