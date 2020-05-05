using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollADice : MonoBehaviour
{
    public Camera cam;
    Rigidbody rb;
    int diceCount;
    Vector3 initPos;
    Vector3 initRo;
    public GameObject rollADiceUI;
    public TurnManager turnManagerSystem;

    public delegate void DiceHandler(int value);
    public DiceHandler onFinishDice;
    // Update is called once per frame
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ResetDice();
    }
    void OnEnable()
    {
        turnManagerSystem.onStartPhase += onStartPhase;
        turnManagerSystem.onEndPhase += onEndPhase;
    }
    void OnDisable()
    {
        turnManagerSystem.onStartPhase -= onStartPhase;
        turnManagerSystem.onEndPhase -= onEndPhase;
    }
    public void RollTheDice()
    {
        rollADiceUI.SetActive(false);
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.AddForce(transform.forward * 150);
        GetDiceCount();
        StartCoroutine(HideDice());
        if (onFinishDice != null) onFinishDice(diceCount);
    }

    IEnumerator HideDice()
    {
        yield return new WaitForSeconds(1f);
        ResetDice();
    }

    void GetDiceCount()
    {
        diceCount = Random.Range(1, 7);
        // Debug.Log (diceCount);
    }

    void onStartPhase()
    {
        initRo = cam.transform.localEulerAngles;
        ResetDice();
        rollADiceUI.SetActive(true);
    }

    void ResetDice()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
        this.transform.localEulerAngles = initRo;
        this.transform.position = cam.transform.position;
    }

    void onEndPhase()
    {
        ResetPosition();
    }
    void ResetPosition()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
    }
}
