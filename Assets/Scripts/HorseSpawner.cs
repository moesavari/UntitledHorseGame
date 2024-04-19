using UnityEngine;

public class HorseSpawner : MonoBehaviour
{
    public bool IsOccupied = false;
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(1, 1, 1));
    }
}
