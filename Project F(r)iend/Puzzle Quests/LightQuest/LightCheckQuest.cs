using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCheckQuest : MonoBehaviour
{
    // Start is called before the first frame update
    public InteractiveLight[] lights;
    public Light[] lightBulbs;
    private List<int> LightQueue = new List<int>();
    // string sad;
    [SerializeField] private GameObject fuseBox;
    private Animator clearAnim;

    // Update is called once per frame

    void Start()
    {
        clearAnim = fuseBox.GetComponent<Animator>();
    }

    void Update()
    {
        LightQueue = new List<int>();
        // sad = "" ;
        foreach (var light in lights)
        {
            if (light.isPoweredOn)
            {

                this.LightQueue.Add(light.lightNumber);
                // Debug.Log(LightQueue.Count);
                // sad += " " + LightQueue[LightQueue.Count-1];

                if (LightQueue.Count > 1)
                {
                    Debug.Log(LightQueue[LightQueue.Count - 2] - LightQueue[LightQueue.Count - 1]);
                    if (LightQueue[LightQueue.Count - 2] - LightQueue[LightQueue.Count - 1] == -1 || LightQueue[LightQueue.Count - 2] - LightQueue[LightQueue.Count - 1] == 5)
                    {

                    }
                    else
                    {
                        foreach (var item in lights)
                        {
                            if (item.isPoweredOn)
                            {
                                item.SwitchLight();
                            }
                        }
                        Debug.Log("false");
                        break;
                    }
                }

                if (LightQueue.Count == 6)
                {
                    foreach (var lightColor in lightBulbs)
                    {
                        lightColor.color = Color.red;
                    }
                    clearAnim.SetBool("clear", true);
                }
            }
        }
        // Debug.Log(sad);
        // Debug.Log("End");
    }
}
