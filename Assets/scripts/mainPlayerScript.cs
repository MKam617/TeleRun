using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mainPlayerScript : MonoBehaviour
{   
    public GameObject MainPlayer;  

    [SerializeField] private float controllSpeed;
    [SerializeField] private float jumpSpeed;

    private CharacterController CharacterController;
    private Vector3 dir;

    // [SerializeField, Range(5,20)] private int deadZone;
    //private Touch theTouch;

    private void Awake()
    {
        MainPlayer = Instantiate(MainPlayer, new Vector3(0,1,3.2f), Quaternion.identity);
        CharacterController = MainPlayer.GetComponent<CharacterController>();
    }

    private void Update()
    {        
        if (CharacterController.isGrounded)
        {
            dir = new Vector3(Input.GetAxis("Horizontal") * controllSpeed,0,0);
            if (Input.GetKey(KeyCode.Space))
            {
                dir.y += jumpSpeed;
            }
        } else{
            dir += Physics.gravity * Time.deltaTime;
        }
        
        CharacterController.Move(dir * Time.deltaTime);
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
