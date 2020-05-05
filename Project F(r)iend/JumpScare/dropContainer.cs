using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropContainer : MonoBehaviour
{
    Animator container;
    [SerializeField] private AudioClip bang;
    private AudioSource playerS;
    
    void Start()
    {
        container = GetComponent<Animator>();
        playerS = GetComponent<AudioSource>();
    }
    public void animDrop(){
        container.SetBool("Drop", true);
        if(bang)
        {
            playerS.PlayOneShot(bang);
        } 
    }    
}
