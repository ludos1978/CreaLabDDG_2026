using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyObjectManager : MonoBehaviour
{

    List<GameObject> myObjects = new List<GameObject>();
    List<float> enableTime = new List<float>();
    int currentObjectIndex = 0;
    public GameObject dropPrefab;
    public GameObject breadcrumbsParent;

    void Start() {
        StartCoroutine(DropObject());
        for (int i=0; i<500; i++) {
            instantiatedObject = Instantiate(dropPrefab, gameObject.transform.position, Quaternion.identity, breadcrumbsParent.transform);
            instantiatedObject.SetActive(false);
            myObjects.Add(instantiatedObject);
            enableTime.Add(0f);
        }
    }
    GameObject instantiatedObject = null;
    private IEnumerator DropObject() {
        while (true) {
            yield return new WaitForSeconds(0.03f);
            Debug.Log("Iteration "+Time.time);
            myObjects[currentObjectIndex].SetActive(true);
            enableTime[currentObjectIndex] = Time.time;
            myObjects[currentObjectIndex].transform.position = gameObject.transform.position;
            currentObjectIndex = (currentObjectIndex + 1) % myObjects.Count;

            if ((Time.frameCount % 10) == 0) {
                for (int i=0; i<500; i++) {
                    if ((Time.time - enableTime[i]) > 3f) {
                        myObjects[i].SetActive(false);
                    }
                }
            }
        }
    }
}
