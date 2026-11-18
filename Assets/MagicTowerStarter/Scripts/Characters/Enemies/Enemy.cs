using UnityEngine;
using UnityGameStarter.Gameplay.GridSystem;

public class Enemy : MonoBehaviour, IGridSnappable
{
    // TODO: requires the grid system to offer a grid event interaction interface

    public void OnSnapped(string snappedLayer, Vector3Int gridID, Vector3Int coord) { }
}
