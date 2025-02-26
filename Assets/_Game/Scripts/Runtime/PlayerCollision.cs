using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private PlayerAnimation playerAnimation;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private GameObject crown;
    [SerializeField] private ParticleSystem collisionEffect;
    [Space]
    
    [Header("Dresses List")]
    [SerializeField] private List<GameObject> dressParent;
    [Space]
    
    [Header("Hair List")]
    [SerializeField] private List<GameObject> hairParent;

    [Header("Flowers List")] [SerializeField]
    private List<GameObject> flowersParent;

    [Space]
    [Header("Collectable Items Effect on Beauty Bar")]
    [SerializeField] private int dressEffectBeauty = 10;
    [SerializeField] private int hairEffectBeauty = 10;
    [SerializeField] private int flowersEffectBeauty = 10;
    [SerializeField] private int obstacleEffectBeauty = 10;
    [SerializeField] private int crownEffectBeauty = 10;
    [SerializeField] private int coinEffectBeauty = 2;

   
    
    private string _currentDress="cowboy";
    private string _currentHair="businesshair";
   

  
    private void OnTriggerEnter(Collider other)
    {
        CollisionType collisionType = GetCollisionType(other.gameObject.tag);

        switch (collisionType)
        {
            case CollisionType.GoodDress:
                AudioManager.instance.Play("Positive");
                ChangeAttire(dressParent, ref _currentDress, other.gameObject);
                GameManager.instance.BeautyScore(dressEffectBeauty); 
                break;

            case CollisionType.BadDress:
                AudioManager.instance.Play("Negative");
                ChangeAttire(dressParent, ref _currentDress, other.gameObject);
                GameManager.instance.BeautyScore(-dressEffectBeauty); 
                break;

            case CollisionType.GoodHairs:
                AudioManager.instance.Play("Positive");
                ChangeAttire(hairParent, ref _currentHair, other.gameObject);
                GameManager.instance.BeautyScore(hairEffectBeauty); 
                break;

            case CollisionType.BadHairs:
                AudioManager.instance.Play("Negative");
                ChangeAttire(hairParent, ref _currentHair, other.gameObject);
                GameManager.instance.BeautyScore(-hairEffectBeauty); 
                break;
            
            case CollisionType.GoodFlower:
                collisionEffect.Play();
                AudioManager.instance.Play("Positive");
                HandleFlowerCollision(other.gameObject, flowersParent[0], flowersParent[1], flowersEffectBeauty);
                break;
            
            case CollisionType.BadFlower:
                collisionEffect.Play();
                AudioManager.instance.Play("Negative");
                HandleFlowerCollision(other.gameObject, flowersParent[1], flowersParent[0], -flowersEffectBeauty);
                break;
            
            case CollisionType.Obstacles:
                AudioManager.instance.Play("Negative");
                other.gameObject.SetActive(false);
                GameManager.instance.BeautyScore(-obstacleEffectBeauty); 
                playerManager.HandleCollisionAnimation(collisionType);
                break;
            
            case CollisionType.Finish:
            case CollisionType.Male:
                playerManager.HandleCollisionAnimation(collisionType); // Notify PlayerManager
                break;

            case CollisionType.Coins:
                GameManager.instance.CoinCollected();
                GameManager.instance.BeautyScore(coinEffectBeauty);
                other.gameObject.SetActive(false);
                Debug.Log("Coin Collected");
                break;

            case CollisionType.Crown:
                collisionEffect.Play();
                AudioManager.instance.Play("Positive");
                GameManager.instance.BeautyScore(crownEffectBeauty);
                other.gameObject.SetActive(false);
                crown.SetActive(true);
                break;

            case CollisionType.Unknown:
            default:
                other.gameObject.SetActive(false);
                Debug.LogWarning($"Unknown collision with tag: {other.gameObject.tag}");
                break;
        }
    }

    private void HandleFlowerCollision(GameObject other,GameObject badFlower,GameObject goodFlower, int score )
    {
        other.gameObject.SetActive(false);
        badFlower.SetActive(false);
        goodFlower.SetActive(true);
        GameManager.instance.BeautyScore(score); 
       
    }
    private CollisionType GetCollisionType(string tag)
    {
        if (Enum.TryParse(tag, out CollisionType collisionType))
        {
            return collisionType;
        }

        return CollisionType.Unknown; // unhandled tags
    }



    private void ChangeAttire(List<GameObject> objList, ref string currentObj, GameObject obj)
    {
        obj.gameObject.SetActive(false);
        collisionEffect.Play();
        if (currentObj != obj.name)
        {
         
            foreach (GameObject child in objList)
            {
                if (child.name == currentObj)
                {
                    child.gameObject.SetActive(false);
                }
                else if (child.name == obj.name)
                {
                    child.gameObject.SetActive(true);
                }
            }

            currentObj = obj.name;
        }
    }



}

public enum CollisionType
{
    GoodDress,
    BadDress,
    GoodHairs,
    BadHairs,
    GoodFlower,
    BadFlower,
    Finish,
    Male,
    Obstacles,
    Coins,
    Crown,
    Unknown
}

