using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MySceneManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
        StartCoroutine(LoadLevel(1));
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
      yield return new WaitForSeconds(5);

      SceneManager.LoadScene(levelIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
