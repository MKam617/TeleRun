using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainPlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject mainPlayer;

    private void Awake()
    {
        mainPlayer = Instantiate(mainPlayer, new Vector3(0,1,0), Quaternion.identity);
    }
}
