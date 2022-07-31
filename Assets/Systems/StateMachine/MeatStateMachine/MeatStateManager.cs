using UnityEngine;

public class MeatStateManager : MonoBehaviour
{
    public MeatBaseState CurrentState;

    public MeatEatenState eaten = new MeatEatenState();
    public MeatRottenState rotten = new MeatRottenState();
    public MeatInitialState initial = new MeatInitialState();
    
    public float timeTorot;
    public GameObject bones;

    public void SpawnBones()
    {
        Instantiate(bones, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("fox"))
        {
            CurrentState.Eat(other,this);
        }
    }

    void Start()
    {

        CurrentState = initial;
        CurrentState.EnterState(this);
    }
    
    void Update()
    {
        CurrentState.UpdateState(this);
    }

    public void TransitionState(MeatBaseState state)
    {
        CurrentState = state;
        CurrentState.EnterState(this);
    }
}
