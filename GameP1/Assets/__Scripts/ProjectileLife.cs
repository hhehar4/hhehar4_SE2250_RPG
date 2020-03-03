using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLife : MonoBehaviour
{
    public float timeToLive = 5f;
    private void Start()
    {
        Destroy(gameObject, timeToLive);
    }
}
