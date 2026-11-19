using UnityEngine;
using UnityGameStarter.Gameplay.GridSystem;

public class Enemy : MonoBehaviour, IGridCollideEvent
{
    public void OnHit(GameObject other)
    {
        Debug.Log("Hit");
    }
}
