using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Car : Vehicle
{
    // POLYMORPHISM
    protected override void Move()
    {
        GameManager.Instance.SetText("Car is moving!");
        TranslateDirection(Vector3.forward, Speed);

        if (transform.position.z >= 7.8f)
        {
            StartCoroutine(EventParticle());
            TranslateDirection(Vector3.forward, Speed * 1.1f);
            GameManager.Instance.SetText("Car is thrusting!");
        }
        else
            TranslateDirection(Vector3.forward, Speed);
        
    }
}
