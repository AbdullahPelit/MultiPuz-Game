using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSetUp : MonoBehaviourPunCallbacks
{
    
    void Start()
    {
        if (photonView.IsMine)
        {
            transform.GetComponent<DragAndDrop>().enabled = true;
            

        }
        else
        {
            transform.GetComponent<DragAndDrop>().enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
