using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadMove : MonoBehaviour
{
    [SerializeField] private GameObject mainPlayer;
    [SerializeField] private GameObject startWayPart;
    [SerializeField] private GameObject[] wayParts;
    [SerializeField] private float roudVelocity;

    private GameObject nextWayPart1;
    private GameObject nextWayPart2;
    private GameObject nextWayPart3;
    private GameObject newWayPart;


    private void Awake()
    {
        mainPlayer = Instantiate(mainPlayer, new Vector3(0,1,0), Quaternion.identity);

        startWayPart = Instantiate(startWayPart, new Vector3(0,0,0), Quaternion.identity);
        startWayPart.tag = "wayPart";

        int rand1 = Random.Range(0, wayParts.Length);
        nextWayPart1 = Instantiate(wayParts[rand1], new Vector3(0,0,40), Quaternion.identity);
        nextWayPart1.tag = "wayPart";
        int rand2 = Random.Range(0, wayParts.Length);
        nextWayPart2 = Instantiate(wayParts[rand2], new Vector3(0,0,80), Quaternion.identity);
        nextWayPart2.tag = "wayPart";
        int rand3 = Random.Range(0, wayParts.Length);
        nextWayPart3 = Instantiate(wayParts[rand3], new Vector3(0,0,120), Quaternion.identity);
        nextWayPart3.tag = "wayPart";        
    }

    private void FixedUpdate()
    {
        foreach (GameObject roadPart in GameObject.FindGameObjectsWithTag("wayPart"))
        {
            roadPart.transform.position -= new Vector3(0,0,roudVelocity);
        }

        GameObject targetWayPart = GameObject.FindGameObjectWithTag("wayPart");
        if (targetWayPart.transform.position.z <= -20) 
        {
            Destroy(targetWayPart);
            int rand = Random.Range(0, wayParts.Length);
            newWayPart = Instantiate(wayParts[rand], new Vector3(0,0,140), Quaternion.identity);
            newWayPart.tag = "wayPart";
        }
    }
}
