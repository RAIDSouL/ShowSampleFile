using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ThunderWire.Utility;

public class InstanBox : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawnposition;
    public GameObject Box;
    private JumpscareEffects effects;
    public AudioClip AnimationSound;
    GameObject Box1;
    Rigidbody boxRB;
    public bool isPlayed;
    public float SoundVolume = 0.5f;

	[Tooltip("Value sets how long will be player scared.")]
	public float ScareLevelSec = 33f;
    void Start()
	{
		effects = ScriptManager.Instance.gameObject.GetComponent<JumpscareEffects> ();
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !isPlayed)
        {
            Box1 = Instantiate(Box, spawnposition.transform.position, Quaternion.identity) as GameObject;
            boxRB = Box1.GetComponent<Rigidbody>();
            boxRB.AddForce(transform.forward * 1000);
            Box1 = Instantiate(Box, spawnposition.transform.position, Quaternion.identity) as GameObject;
            boxRB = Box1.GetComponent<Rigidbody>();
            boxRB.AddForce(transform.forward * 1000);
            if(AnimationSound){Tools.PlayOneShot2D(transform.position, AnimationSound, SoundVolume);}
            effects.Scare (ScareLevelSec);
			isPlayed = true;
        }
    }
}
