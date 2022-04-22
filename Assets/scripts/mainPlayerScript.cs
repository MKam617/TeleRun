using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mainPlayerScript : MonoBehaviour
{   
    public GameObject MainPlayer;  

    CharacterController CharacterController;

    // [SerializeField, Range(5,20)] private int deadZone;
    //private Touch theTouch;

    private void Awake()
    {
        MainPlayer = Instantiate(MainPlayer, new Vector3(0,1,3.2f), Quaternion.identity);
        CharacterController = MainPlayer.GetComponent<CharacterController>();
    }

    private void Update()
    {
        CharacterController.SimpleMove(Vector3.zero);
    }

    // private void SwipeControl(Touch touch)
    // {
    //     if (touch.phase == TouchPhase.Ended)
    //     {
    //         if (touch.deltaPosition.x > deadZone)
    //         {
    //             print("RIGHT");
    //         }
    //         if (touch.deltaPosition.x < -deadZone)
    //         {
    //             print("LEFT");
    //         }
    //     }
    // }
}
