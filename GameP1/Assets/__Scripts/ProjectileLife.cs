using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLife : MonoBehaviour
{
    public float timeToLive = 5f;
    private void Start()
    {
        //Destroys the projectile after a certain amount of time after launched
        Destroy(gameObject, timeToLive);
    }
}
