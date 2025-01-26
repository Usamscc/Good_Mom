using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerAnimation playerAnimation;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private GameObject crown;
    [Space]
    
    [Header("Dresses List")]
    [SerializeField] private List<GameObject> dressParent;
    [Space]
    
    [Header("Hair List")]
    [SerializeField] private List<GameObject> hairParent;


   
    
    private string _currentDress="cowboy";
    private string _currentHair="businesshair";
   

  
    private void OnTriggerEnter(Collider other)
    {
        CollisionType collisionType = GetCollisionType(other.gameObject.tag);

        switch (collisionType)
        {
            case CollisionType.GoodDress:
                ChangeAttire(dressParent, ref _currentDress, other.gameObject);
                print("Good Dress");
                break;

            case CollisionType.BadDress:
                ChangeAttire(dressParent, ref _currentDress, other.gameObject);
                print("Bad Dress");
                break;

            case CollisionType.GoodHairs:
                ChangeAttire(hairParent, ref _currentHair, other.gameObject);
                print("Good Hair");
                break;

            case CollisionType.BadHairs:
                ChangeAttire(hairParent, ref _currentHair, other.gameObject);
                print("Bad Hair");
                break;

            case CollisionType.Finish:
            case CollisionType.Male:
            case CollisionType.Obstacles:
                playerManager.HandleCollisionAnimation(collisionType); // Notify PlayerManager
                break;

            case CollisionType.Coins:
                GameManager.instance.CoinCollected();
                other.gameObject.SetActive(false);
                Debug.Log("Coin Collected");
                break;

            case CollisionType.Crown:
                crown.SetActive(true);
                break;

            case CollisionType.Unknown:
            default:
                other.gameObject.SetActive(false);
                Debug.LogWarning($"Unknown collision with tag: {other.gameObject.tag}");
                break;
        }
    }

    private CollisionType GetCollisionType(string tag)
    {
        if (Enum.TryParse(tag, out CollisionType collisionType))
        {
            return collisionType;
        }

        return CollisionType.Unknown; // Fallback for unhandled tags
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

public enum CollisionType
{
    GoodDress,
    BadDress,
    GoodHairs,
    BadHairs,
    Finish,
    Male,
    Obstacles,
    Coins,
    Crown,
    Unknown
}

