using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchhands : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] RegularHands; 
    [SerializeField] GameObject[] UIHands;
    public bool isUI = false;
    private static Switchhands instance;
    private void Awake()
    {
        instance= this;
    }
    public static Switchhands GetInstance()
    {
        return instance;
    }
    public void Switch()
    {
        if (!isUI)
        {
            UIHands[0].SetActive(false);
            UIHands[1].SetActive(false);
            RegularHands[0].SetActive(true);
            RegularHands[1].SetActive(true);
            isUI= false;
        }
        else if (isUI)
        {
            RegularHands[0].SetActive(false);
            RegularHands[1].SetActive(false);
            UIHands[0].SetActive(true);
            UIHands[1].SetActive(true);
        }
    }
}
