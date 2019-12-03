using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written in C# for Unity 5.6
public class Projectile : MonoBehaviour {

    //angle at which projectile is launched, in degrees
    public float launchAngle = 45;
    //speed at which the projectile is launched
    public float launchVelocity;   //units: m/s

    //velocity: m/s
    public float xVelocity;
    public float yInitialVelocity;
    private float yVelocity;

    //Start is called upon initialization
    void Start()
    {
        //launch angle is converted to radians as unity trig functions are in radians
        float launchRads = Mathf.Deg2Rad * launchAngle;
        xVelocity = launchVelocity * (Mathf.Cos(launchRads));
        yInitialVelocity = launchVelocity * (Mathf.Sin(launchRads));
    }

    //Update is called every frame
    void Update()
    {
         /* Projectile Simulation with no air resistance
         * x  = Vx(initial) * time
         * Vx = V(initial) * cosine(launch angle)
         * 
         * y  = Vy(initial) - [1/2 * (gravity * time^2)]
         * Vy = [V(initial) * sine(launch angle)] - [gravity * time]
         */
         Vector3 oldPos = transform.position;
         Vector3 newPos = new Vector3(oldPos.x + (xVelocity * Time.deltaTime), oldPos.y + (yVelocity * Time.deltaTime));
         yVelocity = yInitialVelocity - (9.8f * Time.time);
         transform.position = newPos;
    }
}
