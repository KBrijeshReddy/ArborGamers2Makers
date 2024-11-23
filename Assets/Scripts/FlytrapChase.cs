using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class FlytrapChase : MonoBehaviour
{
    public float speed = 10f;
    public float rotSpeed = 5f;
    private bool chase = false;
    private bool turn = false;
    private Quaternion targetRot;
    private Vector3 dir;
    private float angle;

    void FixedUpdate()
    {
        if (chase)
        {
            transform.Translate(dir.normalized * Time.deltaTime * -speed);
        }
    }

    public async void Chase(GameObject player)
    {
        dir = player.transform.position - transform.position;
        angle = Vector3.Angle(transform.forward, dir);
        transform.Rotate(Vector3.forward, angle);

        await Task.Delay(1000);

        chase = true;

        await Task.Delay(4000);

        Destroy(gameObject);
    }
}
