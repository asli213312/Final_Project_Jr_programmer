using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Plane : Vehicle
{
    // POLYMORPHISM
    protected override void Move()
    {
        GameManager.Instance.SetText("Plane is moving!");

        TranslateDirection(Vector3.forward, Speed);
        if (transform.position.z >= 7.8f)
        {
            StartCoroutine(EventParticle());
            TranslateDirection((Vector3.forward + Vector3.up), Speed);            
        }
        else
            TranslateDirection(Vector3.forward, Speed);
    }
}
