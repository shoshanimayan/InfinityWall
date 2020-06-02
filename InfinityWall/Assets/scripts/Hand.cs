using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

    public Climber climber = null;
    public OVRInput.Controller controller;


    public Vector3 Delta { private set; get; } = Vector3.zero;
    private Vector3 LastPosition=Vector3.zero;

    public GameObject currentPoint = null;
    public List<GameObject> contactPoints = new List<GameObject>();
    private MeshRenderer meshRenderer = null;
    // Start is called before the first frame update

    private void Start()
    {

    }
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))
        {
            GrabPoint();
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, controller))
            ReleasePoint();
    }


    private void FixedUpdate()
    {
        LastPosition = transform.position;
    }

    private void LateUpdate()
    {
        Delta = LastPosition - transform.position;
    }

    public void GrabPoint()
    {
        currentPoint = Utility.GetNearest(transform.position, contactPoints);

        if (currentPoint) {

            climber.SetHand(this);
            meshRenderer.enabled = false;
        
        }

    }

    public void ReleasePoint()
    {

        if (currentPoint)
        {
            climber.ClearHand();
            meshRenderer.enabled = true;

        }

        currentPoint = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag != "scan")
            AddPoint(other.gameObject);
        else
            other.gameObject.GetComponent<WallExtender>().spawn();
    }
    
    private void AddPoint(GameObject newObject) {

        if (newObject.CompareTag("Climbable")){
            contactPoints.Add(newObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag!="scan")
            RemovePoint(other.gameObject);
    }

    private void RemovePoint(GameObject newObject) {
        contactPoints.Remove(newObject);
    }




}
