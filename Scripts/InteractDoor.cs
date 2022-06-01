using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoor : MonoBehaviour
{
    public float interactDiastance = 10f;

    private Animator m_Animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            Debug.DrawRay(transform.position, transform.forward * interactDiastance, Color.blue, 0.3f);
            if (Physics.Raycast(transform.position, transform.forward, out hit, interactDiastance))
            {
                if (hit.collider.CompareTag("Door") || hit.collider.CompareTag("Gate"))
                {
                    m_Animator = hit.collider.gameObject.GetComponent<Animator>();
                    m_Animator.SetBool("IsOpening", true);
                }

                if(hit.collider.CompareTag("Gate"))
                {
                    hit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;
                }
            }
        }

    }
}
