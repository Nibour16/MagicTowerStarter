using UnityEngine;
using UnityGameStarter.Gameplay.GridSystem;

public class Enemy : MonoBehaviour, IGridCollideEvent
{
    [SerializeField] private CharacterStat stat;
    
    public void OnHit(GameObject other)
    {
        Debug.Log("Hit");
    }
}
