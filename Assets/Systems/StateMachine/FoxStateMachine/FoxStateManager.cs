using UnityEngine;

public class FoxStateManager : MonoBehaviour
{
    public FoxBaseState currentState;
    public FoxWanderingState wandering = new FoxWanderingState();
    public FoxDeadState dead = new FoxDeadState();
    public FoxFollowingState following = new FoxFollowingState();
    public FoxSleepingState sleeping = new FoxSleepingState();

    public GameObject bones;
    
    public SmellSensor smell;
    public FoxController controller;
    public Stomach stomach;

    public GameObject objectToFollow;

    public bool followObject;

    public void TransitionState(FoxBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
    
    public void SpawnBones(Vector3 position)
    {
        Instantiate(bones, position, Quaternion.identity);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        smell = GetComponent<SmellSensor>();
        controller = GetComponent<FoxController>();
        stomach = GetComponent<Stomach>();
    }

    void Start()
    {
        currentState = wandering;
        currentState.EnterState(this);
    }
    
    void Update()
    {
        currentState.UpdateState(this);
    }
}
