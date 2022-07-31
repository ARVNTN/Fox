using UnityEngine;

public class SmellSensor : MonoBehaviour
{
    private FoxStateManager fox;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("meat"))
        {
            fox.followObject = true;
            fox.objectToFollow = other.gameObject;
        }
    }
    
    void Start()
    {
        fox = GetComponent<FoxStateManager>();
    }

    
    void Update()
    {
    }
}
