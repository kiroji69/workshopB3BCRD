using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] public JumpPoint[] jumpPoints;

    
}

[System.Serializable]
public struct JumpPoint
{
    public Transform endPoint;
    public Vector2 force;

}

