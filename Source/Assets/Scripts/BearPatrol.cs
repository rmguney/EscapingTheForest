using System.Collections;
using UnityEngine;

public class BearPatrol : MonoBehaviour
{
    public Transform[] points;
    int current;
    public float speed;
    public float movementInterval; 
    private Animator animator;
    private Vector3 direction;

    void Start()
    {
        current = 0;
        animator = GetComponent<Animator>();
        StartCoroutine(Patrol());
    }

    IEnumerator Patrol()
    {
        while (true)
        {
            yield return StartCoroutine(MoveToNextPoint());
            if (current == 4 || current == points.Length -1) 
                yield return new WaitForSeconds(movementInterval);
            current = (current + 1) % points.Length;
        }
    }

    IEnumerator MoveToNextPoint()
    {
        direction = (points[current].position - transform.position).normalized;
        while (transform.position != points[current].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed * Time.deltaTime);
            RotateModel();
            yield return null;
        }
    }

    void RotateModel()
    {
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
        }
    }
}
