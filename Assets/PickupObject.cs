using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PickupObjectTextures {
    // [SerializeField]
    public PickupObject.OBJECTTYPE key;
    // [SerializeField]
    public Material material;
}


public class PickupObject : MonoBehaviour
{
  public enum OBJECTTYPE {
    COIN,
    FLOWER,
    GOLD,
    FROG
  }

  public List<PickupObjectTextures> pickupObjectTextures;

  public OBJECTTYPE objectType;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start() {
    int objectTypeLength = Enum.GetNames(typeof(OBJECTTYPE)).Length;
    objectType = (OBJECTTYPE)UnityEngine.Random.Range(0, objectTypeLength);
    
    foreach (PickupObjectTextures pickupObjectTex in pickupObjectTextures) {
      if (objectType == pickupObjectTex.key) {
        GetComponent<MeshRenderer>().material = pickupObjectTex.material;
      }
    }

    
  }

  // Update is called once per frame
  void Update()
  {
      
  }
}
