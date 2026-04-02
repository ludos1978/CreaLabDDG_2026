using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyObjectManager : MonoBehaviour
{

    List<GameObject> myObjects = new List<GameObject>();
    int currentObjectIndex = 0;
    public GameObject dropPrefab;

    void Start() {
        StartCoroutine(DropObject());
        for (int i=0; i<500; i++) {
            instantiatedObject = Instantiate(dropPrefab, gameObject.transform.position, Quaternion.identity);
            instantiatedObject.SetActive(false);
            myObjects.Add(instantiatedObject);
        }
    }
    GameObject instantiatedObject = null;
    private IEnumerator DropObject() {
        while (true) {
            yield return new WaitForSeconds(0.03f);
            Debug.Log("Iteration "+Time.time);
            myObjects[currentObjectIndex].SetActive(true);
            myObjects[currentObjectIndex].transform.position = gameObject.transform.position;
            currentObjectIndex = (currentObjectIndex + 1) % myObjects.Count;
        }
    }
}
