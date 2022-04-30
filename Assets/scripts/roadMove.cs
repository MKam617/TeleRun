using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadMove : MonoBehaviour
{
    public Camera MainCamera;
    public GameObject MainPlayer;

    [SerializeField] private GameObject startWayPart;
    [SerializeField] private GameObject[] wayParts;
    [SerializeField] private float roadVelocity;

    private GameObject nextWayPart1;
    private GameObject nextWayPart2;
    private GameObject nextWayPart3;
    private GameObject newWayPart;
    private GameObject[] partsInScene;

    private GameObject part;
    private float startPos;
    private float endPos;
    private float partScale;
    private float notViewPiece;
    private float cameraView;
    private float creationPos;

    private Transform lookAtPoint;

    private void Awake()
    {
        startWayPart = Instantiate(startWayPart, new Vector3(0,0,0), Quaternion.identity);
        startWayPart.tag = "wayPart";
        int rand1 = Random.Range(1, wayParts.Length);
        nextWayPart1 = Instantiate(wayParts[rand1], new Vector3(0,0,startWayPart.transform.localScale.z), Quaternion.identity);
        nextWayPart1.tag = "wayPart";
        int rand2 = Random.Range(1, wayParts.Length);
        nextWayPart2 = Instantiate(wayParts[rand2], new Vector3(0,0,startWayPart.transform.localScale.z*2), Quaternion.identity);
        nextWayPart2.tag = "wayPart";
        int rand3 = Random.Range(1, wayParts.Length);
        nextWayPart3 = Instantiate(wayParts[rand3], new Vector3(0,0,startWayPart.transform.localScale.z*3), Quaternion.identity);
        nextWayPart3.tag = "wayPart";    

        notViewPiece = (Mathf.Tan((MainCamera.fieldOfView/2 + MainCamera.transform.eulerAngles.x) * Mathf.PI/180)) * MainCamera.transform.position.y;
        cameraView = startWayPart.transform.localScale.z - notViewPiece;

        lookAtPoint = MainPlayer.transform.Find("lookAtPoint");
    }

    private void Update()
    {
        MainCamera.transform.LookAt(MainPlayer.transform.Find("lookAtPoint"));

        MainPlayer = GameObject.FindGameObjectWithTag("Player");
        partsInScene = GameObject.FindGameObjectsWithTag("wayPart");
        partScale = partsInScene[0].transform.localScale.z;       
        startPos = partsInScene[0].transform.Find("start").transform.position.z;
        endPos = partsInScene[0].transform.Find("end").transform.position.z;

        MainCamera.transform.position = new Vector3(0,3, MainPlayer.transform.position.z - 3.2f);

        if (MainPlayer.transform.position.z > endPos)
        {
            DestroyUnused(partsInScene, "start");
            CreateNewPart(partsInScene, "end", partScale);
        }  

        RoadsMove(partsInScene);
    }



    private void RoadsMove(GameObject[] roadPartsInScene)
    {
        foreach (GameObject roadPart in roadPartsInScene)
        {
            roadPart.transform.position -= new Vector3(0,0,roadVelocity);
        }
    }


    private void DestroyUnused(GameObject[] roadPartsInScene, string where)
    {
        if (where == "start")
        {
            Destroy(roadPartsInScene[0]);
        }
        else if (where == "end")
        {
            Destroy(roadPartsInScene[roadPartsInScene.Length - 1]);
        }
    }

    private void CreateNewPart(GameObject[] roadPartsInScene, string where, float scale)
    {
        newWayPart = wayParts[Random.Range(1, wayParts.Length)];
        
        startPos = roadPartsInScene[0].transform.Find("start").position.z;
        endPos = roadPartsInScene[partsInScene.Length - 1].transform.Find("end").position.z;
        if (where == "end")
        {
            creationPos = endPos + scale/2;
        }
        if (where == "start")
        {
            creationPos = startPos - scale/2;
        }
        newWayPart = Instantiate(newWayPart, new Vector3(0,0,creationPos), Quaternion.identity);
        newWayPart.tag = "wayPart";
    }
}   
