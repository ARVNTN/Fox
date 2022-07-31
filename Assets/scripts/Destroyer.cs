using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void Update()
    {
        if (gameObject.transform.position.y < -100f)
        {
            Destroy(gameObject);
        }
    }
}
