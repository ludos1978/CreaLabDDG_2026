using UnityEngine; 
using System.Collections;

public class SelfDeactivate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable() {
        StartCoroutine(Deactivate());
    }

    // Update is called once per frame
    private IEnumerator Deactivate() {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
}
