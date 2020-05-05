using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckItem : MonoBehaviour
{
    public string itemName;
    public bool isPuzzle;
    public Vector3 Paramator;
    bool isTrue;
    [SerializeField] private Light checkDebugger;
    void Start()
    {
        isTrue = false;
    }

    public bool IsCheck()
	{
		return isTrue;
	}
    private void OnTriggerStay(Collider other)
    {
        // Debug.Log(itemName +"####" + other.gameObject.name);
        if (other.gameObject.name == itemName && !isPuzzle)
        {
            
            Debug.Log("entered");
            isTrue = true;
        }
        if(other.gameObject.name == itemName && isPuzzle)
        {
            //Debug.Log(other.gameObject.name +"   "+ other.transform.eulerAngles);
            if(other.transform.eulerAngles.x > 345 || other.transform.eulerAngles.y > 345 || other.transform.eulerAngles.z > 345)
            {
                if(other.transform.eulerAngles.x > 345)
                {
                    other.transform.eulerAngles = new Vector3(0,other.transform.eulerAngles.y,other.transform.eulerAngles.z);
                }
                if(other.transform.eulerAngles.y > 345)
                {
                    other.transform.eulerAngles = new Vector3(other.transform.eulerAngles.x,0,other.transform.eulerAngles.z);
                }
                if(other.transform.eulerAngles.z > 345)
                {
                    other.transform.eulerAngles = new Vector3(other.transform.eulerAngles.x,other.transform.eulerAngles.y,0);
                }
            }
            if((other.transform.eulerAngles.x > Paramator.x-10 && other.transform.eulerAngles.x < Paramator.x+10) 
            && (other.transform.eulerAngles.y > Paramator.y-20 && other.transform.eulerAngles.y < Paramator.y+20) 
            && (other.transform.eulerAngles.z > Paramator.z-10 && other.transform.eulerAngles.z < Paramator.z+10)) 
            {
                checkDebugger.enabled = true;
                isTrue = true;
                Debug.Log(other.gameObject.name + "    " + isTrue);
            }
        }
    }
    

    void OnTriggerExit (Collider other)
	{
		if(other.gameObject.name == itemName && !isPuzzle)
		{
			isTrue = false;
            checkDebugger.enabled = false;
		}
        if(other.gameObject.name == itemName && isPuzzle)
        {
            isTrue = false;
            checkDebugger.enabled = false;
        }
	}
}