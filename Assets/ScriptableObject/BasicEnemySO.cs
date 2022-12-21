using UnityEngine;

[CreateAssetMenu(fileName = "BasicEnemySO", menuName = "BasicEnemySO")]
public class BasicEnemySO : ScriptableObject
{
    public float speed;
    public float jumpSpeed;
    public float changeDirectionTimer;
    public float WaitjumpTime;
    public float jumTimeDuration;
    public float floatTime;
}