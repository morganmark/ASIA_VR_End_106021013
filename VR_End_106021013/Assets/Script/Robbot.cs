using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Robbot : MonoBehaviour
{
    //public Transform robbot;
    public GameObject gasObject;
    public GameObject robbotObject;
    public Text scoreText;
    int scoreNum;
    Vector3 gasPosition = new Vector3(1.3f, 2.1f, 0.5f);
    Vector3 robbot1Position = new Vector3(0f, 0f, 15f);
    Vector3 robbot2Position = new Vector3(-15f, 0f, 0f);
    Vector3 robbot3Position = new Vector3(0f, 0f, -15f);
    Vector3 robbot4Position = new Vector3(15f, 0f, 0f);

    //float left = 0.0f;
    //float right = 0.0f;
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
        if(other.tag == "gas")
        {
            print("hurt");
            gasObject.transform.position = gasPosition;
            int scoreInt = 1;
            scoreNum = scoreNum + scoreInt;
            scoreText.text = "Score:"+scoreNum;
            int n = Random.Range(1, 5);
            if (n==1)
            {
                robbotObject.transform.position = robbot1Position;
            }
            else if (n==2)
            {
                robbotObject.transform.position = robbot2Position;
            }
            else if (n == 3)
            {
                robbotObject.transform.position = robbot3Position;
            }
            else
            {
                robbotObject.transform.position = robbot4Position;
            }
            //robbotObject.transform.position = robbot4Position;
            //StartCoroutine("RespwanRobbot");
            //SceneManager.LoadScene("End");
        }

        if(other.name == "Finish")
        {
            print("over");
            Application.Quit();
        }
    }
    //IEnumerator RespwanRobbot()
    //{
        //Destroy(robbotObject.gameObject);
        //robbotObject = (GameObject)Instantiate(robbotObject, robbot1Position, Quaternion.identity);
        
        //yield return null;
    //}
}
