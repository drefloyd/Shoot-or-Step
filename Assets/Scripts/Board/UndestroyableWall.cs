using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndestroyableWall : MonoBehaviour
{
    // Start is called before the first frame update
    void OnDestroy()
    {
        Debug.Log("The wall cannot be destroyed.");
    }
}
