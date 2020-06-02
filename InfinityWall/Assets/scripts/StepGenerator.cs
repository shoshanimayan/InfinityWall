using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepGenerator : MonoBehaviour { 

    public GameObject step;
    // Start is called before the first frame update
    void Start()
    {
        int steps = Random.Range(1, 3);
        while (steps > 0) {
            float place = Random.Range(-4.5f,4.5f);
            if (steps == 1)
            {
                GameObject climb1 =Instantiate(step, transform.position, transform.rotation);
                climb1.transform.parent = transform;
                climb1.transform.localPosition=new Vector3(climb1.transform.localPosition.x-place,climb1.transform.localPosition.y,climb1.transform.localPosition.z);
                steps = 0;
                break;
            }
            else { 
                float place2= Random.Range(1,4 );
                if(place + place2 > 4.5){ place2 = -(place - place2); }
                else { place2 = -(place + place2); }

                GameObject climb1= Instantiate(step, transform.position, transform.rotation);
                GameObject climb2=Instantiate(step, transform.position, transform.rotation);
                climb1.transform.parent = transform;
                climb2.transform.parent = transform;
                climb1.transform.localPosition = new Vector3(climb1.transform.localPosition.x - place, climb1.transform.localPosition.y, climb1.transform.localPosition.z);
                climb2.transform.localPosition = new Vector3(climb2.transform.localPosition.x - place2, climb2.transform.localPosition.y, climb2.transform.localPosition.z);

                steps = 0;
                break;

            }
        }
    }

  
}
