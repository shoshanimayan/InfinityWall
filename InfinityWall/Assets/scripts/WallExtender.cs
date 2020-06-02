using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallExtender : MonoBehaviour
{
    public GameObject wall1;
    public GameObject reference;
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawn()
    {
        Vector3 pos = new Vector3(reference.transform.position.x, transform.position.y + 9.2f, reference.transform.position.z);
        Instantiate(wall1, pos, reference.transform.rotation);
        Vector3 pos2 = new Vector3(reference.transform.position.x, transform.position.y + 15.3f, reference.transform.position.z);
        Instantiate(wall1, pos2, reference.transform.rotation);
        transform.position = new Vector3(transform.position.x, transform.position.y*3,transform.position.z);
    }
}
