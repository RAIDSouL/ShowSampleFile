using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class testsethdr : MonoBehaviour
{
    // Start is called before the first frame update
    Material thisMat;
    float t = 0f;
    bool isEnable = false;
    GameObject player;

    void Start()
    {
        thisMat = GetComponent<Renderer>().material;
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
                    thisMat.SetColor("_EmissionColor" , new Vector4(0f,0f,0f,0f));
                    isEnable = false;
                    t = 0f;
                }
            }
            if(Input.GetKeyDown(KeyCode.LeftAlt))
            {
                thisMat.SetColor("_EmissionColor" , new Vector4(1.5f,1.5f,1.5f,1f));
                isEnable = true;
            }
            if(Input.GetKeyUp(KeyCode.LeftAlt) && t > 3.0f)
            {
                thisMat.SetColor("_EmissionColor" , new Vector4(0f,0f,0f,0f));
                isEnable = false;
                t = 0f;
            }
            // Debug.Log(isEnable);
        }
        else
        {
            thisMat.SetColor("_EmissionColor" , new Vector4(0f,0f,0f,0f));
            isEnable = false;
        }
    }
}
