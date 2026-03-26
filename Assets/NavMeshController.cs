using UnityEngine;

public class NavMeshController : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    public GameObject targetObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void GoThere ()
    {
      // targetObject
      navMeshAgent.SetDestination(targetObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        GoThere();
    }
}
