using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "playerDatabase")]
public class PlayerData : ScriptableObject
{
    private string _playerDistance;
    public string PlayerDistance
    {
        get => _playerDistance;
        set => _playerDistance = value;
    }
    public float speed;

}
