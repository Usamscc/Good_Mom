using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name =="Finish banner")
        {
            print("Race Finished");
         
        }
        else
        {
            print(other.gameObject.name);
            other.gameObject.SetActive(false);
        }
       
    }
}
