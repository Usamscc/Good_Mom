using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerAnimation playerAnimation;
    [Space]
    [Header("Dresses List")]
    [SerializeField] private List<GameObject> dressParent;
    [Space]
    [Header("Hair List")]
    [SerializeField] private List<GameObject> hairParent;
    private static string currentDress="cowboy";
    private static string currentHair="businesshair";
    

    private void OnTriggerEnter(Collider other)
    {

        switch (other.gameObject.tag)
        {
            case "Dress":
                ChangeAttire(dressParent,ref currentDress,other.gameObject);
                break;
            case "Hair":
                ChangeAttire(hairParent,ref currentHair,other.gameObject);
                break;
            case "Finish":
                print("Finished");
                break;
            case "Male":
                playerAnimation.KissAnimation();
                break;
            case "Obstacles":
                playerAnimation.StumbleAnimation();
                break;
            default:
                other.gameObject.SetActive(false);
                break;
        }
       
    }

    private void ChangeAttire(List<GameObject> objList, ref string currentObj,GameObject obj)
    {
        obj.gameObject.SetActive(false);
        foreach (GameObject child in objList )
        {
            if (child.name == currentObj)
            {
                child.gameObject.SetActive(false);
            }else if (child.name == obj.name)
            {
                child.gameObject.SetActive(true);
            }
        }
        currentObj = obj.name;
    }
}

