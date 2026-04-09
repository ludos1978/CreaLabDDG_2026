using UnityEngine;
using UnityEngine.Events;

public class MyEventHandler : MonoBehaviour {

  public GameObject otherObject;

  public UnityEvent onAKeyPress;
  public UnityEvent onBKeyPress;
  public UnityEvent onCKeyPress;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start() {
    
  }

  // Update is called once per frame
  void Update() {
    if (UnityEngine.InputSystem.Keyboard.current.aKey.wasPressedThisFrame) {
      onAKeyPress.Invoke();
    }
    if (UnityEngine.InputSystem.Keyboard.current.bKey.wasPressedThisFrame) {
      onBKeyPress.Invoke();
    }
    if (UnityEngine.InputSystem.Keyboard.current.cKey.wasPressedThisFrame) {
      onCKeyPress.Invoke();
    }
  }
}
