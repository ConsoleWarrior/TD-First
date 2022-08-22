using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    public Transform target;
    public UnityEngine.AI.NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        
    }


    void Update()
    {
        agent.SetDestination(target.position);
        if(target.gameObject.name == "Ship")
        transform.up = agent.velocity.normalized; //ОНО СМОТРИТ КУДА НАДО!!!

        //transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (0, 0, 90), 5 * Time.deltaTime);//плавный поворот!!!
        //transform.up = new Vector2(target.position.x-transform.position.x,target.position.y-transform.position.y); // всегда смотрю на цель, как турель
        //transform.rotation *= Quaternion.Euler(0f, 0f, -90f); бесконечно вращается
        //float angle = Vector3.Angle(transform.up, agent.velocity.normalized); //угол между двумя векторами


        //angle *= -1;

        //transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (0, 0, angle), 5 * Time.deltaTime);

    }
}
