using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraTarget;

    Vector2 rotationDirection;

    public float rotationSpeed = 1f;

    public float radius = 5f;

    Vector3 sc = new Vector3();
    public float minZRotationClamp = -0.4f;
    public float maxZRotationClamp = 0.6f;

    public float smoothingFactor;

    private void Start()
    {
        this.transform.position = new Vector3(radius, 0.0f, 1.6f);
        this.transform.LookAt(cameraTarget.transform.position);

        sc = GetSphericalCoordinates(this.transform.position);
        sc = new Vector3(8f, -1.6f, 0.5f);
        smoothingFactor *= Time.deltaTime;
    }

    // change the cartesian coordinates of the camera to polar
    Vector3 GetSphericalCoordinates(Vector3 cartesian)
    {
        float radius = Mathf.Sqrt(
            Mathf.Pow(cartesian.x, 2) +
            Mathf.Pow(cartesian.y, 2) +
            Mathf.Pow(cartesian.z, 2));

        float phi = Mathf.Atan2(cartesian.z / cartesian.x, cartesian.x);
        float theta = Mathf.Acos(cartesian.y / radius);

        if (cartesian.x < 0) { phi += Mathf.PI; }

        //print(phi);

        return new Vector3(radius, phi, theta);
    }

    // change the polar coordinates to cartesian
    Vector3 GetCartesianCoordinates(Vector3 sphereical)
    {
        Vector3 ret = new Vector3();

        ret.x = sphereical.x * Mathf.Cos(sphereical.z) * Mathf.Cos(sphereical.y);
        ret.y = sphereical.x * Mathf.Sin(sphereical.z);
        ret.z = sphereical.x * Mathf.Cos(sphereical.z) * Mathf.Sin(sphereical.y);

        return ret;
    }

    void SnapCam()
    {
        if (Input.GetKey(KeyCode.Alpha4))
        {
            sc.y = Mathf.Lerp(sc.y, 0, smoothingFactor);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            sc.y = Mathf.Lerp(sc.y, 0.5f * Mathf.PI, smoothingFactor);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            sc.y = Mathf.Lerp(sc.y, Mathf.PI, smoothingFactor);
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            sc.y = Mathf.Lerp(sc.y, 1.5f * Mathf.PI, smoothingFactor);
        }
    }

    void RotateCam()
    {
        float dx = rotationDirection.x * rotationSpeed;
        float dy = rotationDirection.y * rotationSpeed;

        if (dx != 0f || dy != 0f)
        {
            sc.y += dx * Time.deltaTime;

            //Debug.Log(sc.z);
            sc.z = Mathf.Clamp(sc.z + dy * Time.deltaTime, minZRotationClamp, maxZRotationClamp);
        }
    }

    private void Update()
    {
        SnapCam();
        RotateCam();

        this.transform.position = GetCartesianCoordinates(sc) + cameraTarget.transform.position;
        this.transform.LookAt(cameraTarget.transform.position);
    }
}
