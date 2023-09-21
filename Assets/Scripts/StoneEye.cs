using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneEye : MonoBehaviour
{
    public GameObject player;
    bool isplayerbecatched;
    public GameEndTrigger gameEndTrigger;
    void Start()
    {
        
    }

    void Update()
    {
        if(isplayerbecatched)
        {
            gameEndTrigger.GetPlayer();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            isplayerbecatched = true;
        }
    }

    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
        //Debug.Log("Get catch");
        if(other.gameObject == player)
        {
            isplayerbecatched = false;
        }
    }
}
