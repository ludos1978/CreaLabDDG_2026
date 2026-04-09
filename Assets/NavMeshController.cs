using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class StateEvent {
  public NavMeshController.CHARACTERSTATE state;
  public UnityEvent evnt;
}

public class NavMeshController : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    // public GameObject targetObject;
    public List<GameObject> targetObjects;
    public int targetIndex = 0;
    public GameObject chaseTargetObject;

    public float startChase = 0.0f;

    public List<StateEvent> stateMachineEvents;

    public enum CHARACTERSTATE {
      PATROLLING_LOOP,
      CHASING_ENTER,
      CHASING_LOOP
    }
    public CHARACTERSTATE characterState;

    void Start() {
      navMeshAgent.SetDestination(targetObjects[targetIndex].transform.position);
      characterState = CHARACTERSTATE.PATROLLING_LOOP;
    }

    void Update() {
      foreach (StateEvent stateEvent in stateMachineEvents) {
        if (characterState == stateEvent.state) {
          stateEvent.evnt.Invoke();
        }
      }
      
      switch (characterState) {
        case CHARACTERSTATE.PATROLLING_LOOP:
          // Debug.Log("Patrolling");
          
          GameObject foundPlayer = FindPlayer();
          if (foundPlayer != null) {
            characterState = CHARACTERSTATE.CHASING_ENTER;
            chaseTargetObject = foundPlayer;
          }
          GoThere();
          break;
        case CHARACTERSTATE.CHASING_ENTER:
          navMeshAgent.SetDestination(chaseTargetObject.transform.position);
          startChase = Time.time;
          characterState = CHARACTERSTATE.CHASING_LOOP;
          break;
        case CHARACTERSTATE.CHASING_LOOP:
          // Debug.Log("Chasing");
          if ((Time.time - startChase) > 10f) {
            characterState = CHARACTERSTATE.PATROLLING_LOOP;
          }
          navMeshAgent.SetDestination(chaseTargetObject.transform.position);
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
