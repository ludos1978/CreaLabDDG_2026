using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class NavMeshController : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    // public GameObject targetObject;
    public List<GameObject> targetObjects;
    public int targetIndex = 0;
    public GameObject chaseTargetObject;

    public float startChase = 0.0f;

    public enum CHARACTERSTATE {
      PATROLLING,
      CHASING,
      RETURNING
    }
    public CHARACTERSTATE characterState;

    void Start() {
      navMeshAgent.SetDestination(targetObjects[targetIndex].transform.position);
      characterState = CHARACTERSTATE.PATROLLING;
    }

    void Update() {
      switch (characterState) {
        case CHARACTERSTATE.PATROLLING:
          Debug.Log("Patrolling");
          
          GameObject foundPlayer = FindPlayer();
          if (foundPlayer != null) {
            characterState = CHARACTERSTATE.CHASING;
            chaseTargetObject = foundPlayer;
            navMeshAgent.SetDestination(chaseTargetObject.transform.position);
            startChase = Time.time;
          }
          GoThere();
          break;

        case CHARACTERSTATE.CHASING:
          Debug.Log("Chasing");
          if ((Time.time - startChase) > 10f) {
            characterState = CHARACTERSTATE.PATROLLING;
          }
          navMeshAgent.SetDestination(chaseTargetObject.transform.position);
          break;

        case CHARACTERSTATE.RETURNING:
          break;
      }
    }

    GameObject FindPlayer () {
      RaycastHit[] hits = Physics.SphereCastAll(this.transform.position, 2f, this.transform.forward, 3f);
      foreach (RaycastHit hit in hits) {
        if (hit.collider.gameObject.tag == "Player") {
          return hit.collider.gameObject;
        }
      }
      return null;
    }

    void GoThere () {
      if (navMeshAgent.remainingDistance < 0.1f) {
        Debug.Log("Reached");
        targetIndex = (targetIndex + 1) % targetObjects.Count;
        navMeshAgent.SetDestination(targetObjects[targetIndex].transform.position);
      }
    }

}
