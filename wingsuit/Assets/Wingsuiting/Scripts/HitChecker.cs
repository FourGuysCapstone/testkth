using UnityEngine;
using System.Collections;

public class HitChecker : MonoBehaviour
{
    [SerializeField]
    private AviatorController controller;
    [SerializeField]
    private JointsPoseController posController;
    private Rigidbody[] bodies;
    private Rigidbody body;
    [SerializeField]
    private Rigidbody rootBody;
    [SerializeField]
    private Rigidbody leftHand;
    [SerializeField]
    private Rigidbody rightHand;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        body.useGravity = false;
        bodies = GetComponentsInChildren<Rigidbody>();
        foreach (var item in bodies)
        {
            if(item != body)
            {
                item.isKinematic = true;
                Physics.IgnoreCollision(body.GetComponent<Collider>(), item.GetComponent<Collider>());
                item.GetComponent<Collider>().enabled = false;
            }
        }
    }

   
    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.collider.tag == "Ground")
        {
            if (controller.parachuteIsOpened)
            {
                rootBody.gameObject.AddComponent<FixedJoint>();
                leftHand.gameObject.AddComponent<FixedJoint>();
                rightHand.gameObject.AddComponent<FixedJoint>();
            }
            Destroy(body);
            Destroy(GetComponent<Collider>());
            Destroy(GetComponent<AudioSource>());
            body.useGravity = true;
            bodies = GetComponentsInChildren<Rigidbody>();
            foreach (var item in bodies)
            {
                if (item != body)
                {
                    item.isKinematic = false;
                    item.GetComponent<Collider>().enabled = true;
                }
            }
            Destroy(controller);
            Destroy(posController);
            if (!GameManager.instance.isBaseOver)
            {
                UIManager.instance.Reload();
            }
            
        }
    }
    
}
