using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private Rigidbody rb;
    private bool isPickedUp = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!isPickedUp && Input.GetKeyDown(KeyCode.E))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 0.5f);
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Player"))
                {
                    PickUpKey(col.transform);
                    break; 
                }
            }
        }

        if (isPickedUp && Input.GetKey(KeyCode.E))
        {
            Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            rb.velocity = moveInput * 5f;
        }

        if (isPickedUp && Input.GetKeyUp(KeyCode.E))
        {
            DropKey();
        }
    }

    private void PickUpKey(Transform playerTransform)
    {
        GameManager.Instance.PickUpKey();
        rb.isKinematic = true;
        transform.parent = playerTransform; 
        isPickedUp = true;
    }

    private void DropKey()
    {
        rb.isKinematic = false; 
        transform.parent = null; 
        isPickedUp = false;
    }
}
