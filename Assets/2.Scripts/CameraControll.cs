using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public float height;
    public float distance;
    public float moveDamping;
    public float rotDamping;
    public GameObject Player1;
    public GameObject Player2;

    Vector3 center;
    Vector3 xzPos;

    private void Update()
    {

        Vector3 base1 = Player2.transform.position - Player1.transform.position;
        center = (Player2.transform.position + Player1.transform.position) * 0.5f;
        Vector3 norm = Vector3.Cross(base1, Vector3.up);
        norm.Normalize();
        norm *= base1.magnitude * 1.4f;
        distance = base1.magnitude * 1.4f;

        transform.position = Vector3.Slerp(transform.position, new Vector3(norm.x, height, norm.z), moveDamping);

        Quaternion rot = Quaternion.LookRotation(center - transform.position + Vector3.up);
        transform.rotation = Quaternion.Slerp(Quaternion.identity, rot, rotDamping);
    }
}
