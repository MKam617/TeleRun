using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerController : MonoBehaviour
{   
    public GameObject MainPlayer; 

    [SerializeField] private float controllSpeed;
    [SerializeField] private float jumpSpeed;
    private CharacterController CharacterController;
    private Vector3 dir;

    [SerializeField, Range(5,20)] private int deadZone;
    private Touch theTouch;


    public AudioSource EmbientSound;
    public AudioSource GameOverSound;
    private bool playerRIP = false;
    private float deathTimer = 3f;


    private void Awake()
    {
        MainPlayer = Instantiate(MainPlayer, new Vector3(0,1,3.2f), Quaternion.identity);
        CharacterController = MainPlayer.GetComponent<CharacterController>();   
    }

    private void Update()
    {        
        PCcontrol();

        //SwipeControl();


        if (MainPlayer.transform.position.y < 0 || MainPlayer.transform.position.z < -8) EmbientSound.Stop();
        //game over
        if (MainPlayer.transform.position.y < -1 || MainPlayer.transform.position.z < -17)
        {
            if (playerRIP == false)
            {
                GameOverSound.Play();
                playerRIP = true;
            }

            if (deathTimer > 0) deathTimer -= Time.deltaTime;
            if (deathTimer <= 0) SceneManager.LoadScene(1);
        }
    }
    
    private void FixedUpdate()
    {
        CharacterController.Move(dir * Time.deltaTime);
    }

    private Vector3 SwipeControl()
    {
        if (CharacterController.isGrounded)
        {
            if (Input.touchCount > 0)
            {
                theTouch = Input.GetTouch(0);
                if (theTouch.deltaPosition.y > deadZone) dir.y += jumpSpeed;
                if (theTouch.position.x > 540 + deadZone) dir += new Vector3(controllSpeed * Time.deltaTime,0,0);
                if (theTouch.position.x < 540 - deadZone) dir += new Vector3(-controllSpeed * Time.deltaTime,0,0);                
            } else {
                dir = Vector3.zero;
            }
        } else {
            dir += Physics.gravity * Time.deltaTime;
        }
        return dir;
    }

    private Vector3 PCcontrol()
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
        return dir;
    }
}
