using System.Collections.Generic;
using UnityEngine;

public class NavMeshController : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    // public GameObject targetObject;
    public List<GameObject> targetObjects;
    public int targetIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      navMeshAgent.SetDestination(targetObjects[targetIndex].transform.position);

    }

    void GoThere ()
    {
      // targetObject

      if (navMeshAgent.remainingDistance < 0.1f)
      {
        Debug.Log("Reached");
        targetIndex = (targetIndex + 1) % targetObjects.Count;
        navMeshAgent.SetDestination(targetObjects[targetIndex].transform.position);
      }
    }

    // Update is called once per frame
    void Update()
    {
        GoThere();
    }
}
