using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public Transform[] spawnPoints;

    private NavMeshAgent agent = null;

    private Animator anim = null;

    private void Start()
    {
        getRef();

        SelectModel();

        int newPoint = Random.Range(0, spawnPoints.Length);
        agent.SetDestination(spawnPoints[newPoint].position);
    }

    private void Update()
    {
        if(agent.velocity.magnitude > 0.1f)
        {
            anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
        }
        else
        {
            anim.SetFloat("Speed", 0f, 0.3f, Time.deltaTime);
            int newPoint = Random.Range(0, spawnPoints.Length);
            agent.SetDestination(spawnPoints[newPoint].position);
        }
    }

    void getRef()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void SelectModel()
    {
        GameObject GFX = GameObject.Find("GFX");
        int childrenCount = GFX.transform.childCount;
        int selectedModel = Random.Range(0, childrenCount);

        for(int i = 0; i < childrenCount; i++)
        {
            if(i == selectedModel)
            {
                GFX.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                GFX.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
