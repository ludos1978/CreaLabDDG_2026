using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyObjectManager : MonoBehaviour
{

    List<GameObject> myObjects = new List<GameObject>();
    public GameObject dropPrefab;

    void Start() {
        StartCoroutine(DropObject());
    }

    private IEnumerator DropObject() {
        while (true) {
            yield return new WaitForSeconds(1);
            Debug.Log("Iteration "+Time.time);
            GameObject instantiatedObject = Instantiate(dropPrefab, gameObject.transform.position, Quaternion.identity);
            myObjects.Add(instantiatedObject);
            if (myObjects.Count > 5) {
                Destroy(myObjects[0]);
                myObjects.RemoveAt(0);
            }
        }
    }
}
