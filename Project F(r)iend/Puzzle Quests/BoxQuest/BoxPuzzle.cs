using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPuzzle : MonoBehaviour
{
    public GameObject locker;
    private Animator lockerAnim;
    private AudioSource lockerSound;

    [SerializeField] private AudioClip clearSound;

    public CheckItem[] checkItems;
    private bool IsTrue;

    private bool isSoundPlay = false;
    // private bool[] Istrue;
    void Start()
    {
        lockerAnim = locker.GetComponent<Animator>();
        lockerSound = locker.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0 ; i < checkItems.Length ; i++)
        {
            if(checkItems[i].IsCheck())
            {
                IsTrue = true;
            }
            else
            {
                IsTrue = false;
                break;
            }
        }
        if(IsTrue)
        {
            if(!isSoundPlay){
                lockerSound.PlayOneShot(clearSound, 0.7F);
                isSoundPlay = true;
            }
            lockerAnim.SetBool("BoxSpinClear", true);
        }
    }
}
