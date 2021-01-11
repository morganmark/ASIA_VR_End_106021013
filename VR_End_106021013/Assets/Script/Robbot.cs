using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Robbot : MonoBehaviour
{
    public Transform robbot;
    float left = 0.0f;
    float right = 0.0f;
    public Transform target;
    public float speed = 2.00f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        Vector3 targetDir = target.position - transform.position;
        Vector3 forward = transform.forward;

        Vector3 pos = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(new Vector3(pos.x, 0, pos.z));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "gas")
        {
            print("hurt");
            SceneManager.LoadScene("End");
        }

        if(other.name == "Finish")
        {
            print("over");
            Application.Quit();
        }
    }
}
