/*using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    [SerializeField] private Collider _colliderPlayer, _colliderFloorForQuestion1, continueColliderForQuestion1;
    [SerializeField] private Canvas popup;

    [SerializeField] private Collider[] colidersToShowQuestions;
    [SerializeField] private Collider[] colidersToContinue;
    [SerializeField] private Canvas[] Questions;
    
    public static int index;

    //public ShowFirstQuestion showFirstQuestion;



    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        popup.gameObject.SetActive(false);

        continueColliderForQuestion1.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_colliderPlayer.bounds.Intersects(_colliderFloorForQuestion1.bounds))
        {
            OnObjectsTriggered(popup);
        }
        if (ShowFirstQuestion.hasButtonBeenClicked)
            continueColliderForQuestion1.GetComponent<Collider>().enabled = true;
    }

    public void OnObjectsTriggered(Canvas _canvas)
    {
        _canvas.gameObject.SetActive(true);
    }
}*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    [SerializeField] private Collider _colliderPlayer;

    [SerializeField] private Collider[] collidersToShowQuestions;
    [SerializeField] private Collider[] collidersToContinue;
    [SerializeField] private Canvas[] questions;

    public GameObject cube1, cube2, cube3;

    public static int index;

    //public ShowFirstQuestion showFirstQuestion;



    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        //cube.gameObject.SetActive(false);

        for (int i = 0; i < collidersToContinue.Length; i++)
        {
            collidersToContinue[i].enabled= false;
            collidersToShowQuestions[i].enabled = true;
            questions[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (index)
        {
            case 0:
                cube1.gameObject.SetActive(true);
                break;
            case 1:
                cube1.gameObject.SetActive(false);
                cube2.gameObject.SetActive(true);
                break;
            case 2:
                cube2.gameObject.SetActive(false);
                cube3.gameObject.SetActive(true);

                break;
            case 3:
                cube2.gameObject.SetActive(false);
                cube3.gameObject.SetActive(false);
                break;
        }

        if (index <= 3)
        {
            if (_colliderPlayer.bounds.Intersects(collidersToShowQuestions[index].bounds))
            {
                collidersToContinue[index].enabled = false;
                OnObjectsTriggered(questions[index]);


            }
            if (ShowFirstQuestion.hasButtonBeenClicked)
            {
                collidersToContinue[index].enabled = true;
            }
        }

        

    }

    public void OnObjectsTriggered(Canvas _canvas)
    {
        _canvas.gameObject.SetActive(true);
        Switchhands.GetInstance().isUI = true;
        Switchhands.GetInstance().Switch();
    }
}