using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscene : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isPlayed;
    public PlayerController playerController;
    public MouseLook playerMouse;
    public GameObject ghost;

    // Update is called once per frame

    void OnTriggerEnter(Collider other)
	{
        ghost.SetActive(true);
		if (other.tag == "Player" && !isPlayed) {
            StartCoroutine(disable());
        }
        isPlayed = true;
    }

    IEnumerator disable()
    {
        playerController.enabled = false;
        playerMouse.enabled = false;
        yield return new WaitForSeconds(5f);
        playerController.enabled = true;
        playerMouse.enabled = true;
    }
}