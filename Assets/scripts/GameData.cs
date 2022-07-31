using UnityEngine;

[CreateAssetMenu(fileName = "GameDataScriptableObject",menuName = "ScriptableObjects/GameData")]
public class GameData : ScriptableObject
{
    public GameObject[] treePositions;

    public Vector3 landSize;

    public float foxSpeed = 1f;
    public float changeDirectionTimer = 5f;
    public float smellRange = 4f;

    public float timeToRot = 7f;

}
