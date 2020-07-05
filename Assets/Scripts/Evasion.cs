using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evasion : MonoBehaviour
{
    public float dodge;
    public float smoothing;
    public float tilt;

    public Vector2 startWait;
    public Vector2 evasionTime;
    public Vector2 evasionWait;
    public Boundary boundary;

    private float currentSpeed;
    private float evasionEndPoint;
    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = rb.velocity.z;
        StartCoroutine (Evade());
	}
	
    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true)
        {
            evasionEndPoint = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(evasionTime.x, evasionTime.y));
            evasionEndPoint = 0;
            yield return new WaitForSeconds(Random.Range(evasionWait.x, evasionWait.y));
        }
    }

	void FixedUpdate ()
    {
        float newMove = Mathf.MoveTowards(rb.velocity.x, evasionEndPoint, Time.deltaTime * smoothing);
        rb.velocity = new Vector3(newMove, 0.0f, currentSpeed);
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}
