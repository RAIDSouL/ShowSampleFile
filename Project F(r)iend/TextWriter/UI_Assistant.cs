using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_Assistant : MonoBehaviour
{
    [SerializeField] private TextWriter textWriter;
    private TextMeshProUGUI messageText;
    public testloadscene loadscene;
    float thisTime = 0;
    // Start is called before the first frame update
    void Awake()
    {
        messageText = transform.Find("Message").Find("MessageText").GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {   
        messageText.text = "";
        textWriter.AddWriter(messageText, "LOADING CASE . . . \n\nCase : Lost Kid \n\nLocation : WCLK-Hospital\n\nStatus : Case Close.\n\nDetails : . . . . ", .075f , true);
        
    }

    void Update()
    {
        thisTime += Time.deltaTime;
        if(thisTime > 10f)
        {
            loadscene.LoadLevel();
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
}
