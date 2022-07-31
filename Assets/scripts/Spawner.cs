using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameData data;

    public float minDistance = 2f;
    
    private List<Vector3> _spawnLocations = new List<Vector3>();

    public GameObject land;
    public GameObject objectToSpawn;
    
    private Quaternion _objectRotation = Quaternion.identity  ;

    private const float TreeMaxSize = 2f;

    private float _heightToUse = 7f;
    private readonly Vector3 _down = Vector3.down;

    private Vector3 _objectSize = Vector3.zero;


    private int HeightDetector(float x, float y)
    {
        
        Ray heightDetectionRay = new Ray(new Vector3(x,y,_heightToUse),transform.TransformDirection(_down));
        if (Physics.Raycast(heightDetectionRay, out RaycastHit hitData))
        {
            if (hitData.collider.CompareTag("land"))
            {
                return (int)Mathf.Ceil(hitData.point.y);
            }
        }
        return -1;
    }

    private void GenerateSpawnLocations(Vector3 landSize, Vector3 objectSize)
    {
        float x=minDistance, z=minDistance;
        
        while (x < landSize.x-minDistance)
        {
            while (z < landSize.z-minDistance)
            {
                if (Random.Range(0, 3) == 0 && !InTree(new Vector2(x,z)))
                {
                    int height = HeightDetector(x, z);
                    if ( height == -1)
                    {
                        height = 7;
                    }
                    _spawnLocations.Add(new Vector3(x,height + Mathf.Max(objectSize.x,objectSize.y,objectSize.z),z));
                }
                z += minDistance;
            }
            x += z = minDistance;
        }
    }

    private void SpawnElements(Quaternion objectRotation)
    {
        int number = _spawnLocations.Count-1;
        while (number > 0)
        {
            Instantiate(objectToSpawn, _spawnLocations[number],objectRotation);
            number--;
        }
    }
    private bool InTree (Vector2 objectPosition )
    {
        data.treePositions = GameObject.FindGameObjectsWithTag("tree");
        int number = data.treePositions.Length-1;
        while (number >= 0)
        {
            Vector3 pos = data.treePositions[number].transform.position;
            Vector2 treePosition = new Vector2(pos.x,pos.z) ;
            if (Vector2.Distance(objectPosition, treePosition) < TreeMaxSize)
            {
                return true;
            }
            number--;
        }
        return false;
    }
    
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
    
    void Awake()
    {
        if (objectToSpawn.CompareTag("meat"))
        {
            _objectRotation=Quaternion.Euler(90,0,0);
        }
        data.landSize = land.GetComponent<Renderer>().bounds.size;
        _objectSize = objectToSpawn.GetComponent<Renderer>().bounds.size;
        
        GenerateSpawnLocations(data.landSize,_objectSize);
        SpawnElements(_objectRotation);
       
    }
}