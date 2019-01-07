using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public float height;
    public float moveDamping;
    public float rotDamping;
    public GameObject Player1;
    public GameObject Player2;

    
    float distance;

    private void Update()
    {
        Vector3 center = (Player2.transform.position + Player1.transform.position) * 0.5f;
        //Vector3 base1 = (new Vector3(center.x, 3f, center.z) - center);
        Vector3 base2 = Player1.transform.position - center;
        Vector3 norm = Vector3.Cross(Vector3.up, base2);

        norm.Normalize();
        distance = base2.magnitude * 2.8f;
        norm *= distance;

        transform.position = new Vector3(norm.x, height, norm.z) + center;

        Quaternion rot = Quaternion.LookRotation((center + Vector3.up) - transform.position);
        transform.rotation = Quaternion.Lerp(Quaternion.identity, rot, rotDamping);
    }
}
