using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disableofbullet : MonoBehaviour
{
    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
