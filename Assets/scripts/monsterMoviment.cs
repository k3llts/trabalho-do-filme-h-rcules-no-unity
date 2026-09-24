using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class monsterMoviment : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    private Animator animInimigo;

    public float speedInimigo = 3.5f;
    public GameObject monster;    
    public GameObject corpoMonster;

    private bool isDead = false;
    private bool isAttacking = false; 

    public int lifeMonster = 20;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animInimigo = GetComponent<Animator>();

        player = GameObject.FindWithTag("Player");

        if (agent != null)
        {
            agent.speed = speedInimigo;
        }

       
        if (monster != null)
        {
            monster.SetActive(false);
        }
    }

    private void Update()
    {
    
        if (isDead) return;

   
        if (player != null && agent != null && agent.enabled)
        {
            agent.destination = player.transform.position;
            if (animInimigo != null)
            {
                animInimigo.SetBool("walk", true);
            }
        }

        if (player != null && Vector3.Distance(transform.position, player.transform.position) < 1.5f)
        {
            if (!isAttacking)
            {
                StartCoroutine(Ataque());
            }
        }


        if (lifeMonster <= 0 && !isDead)
        {
            Morrer();
        }
    }

    private void Morrer()
    {
        isDead = true;
        StopAllCoroutines(); 

        if (agent != null)
        {
            agent.isStopped = true;
            agent.enabled = false;
        }

        if (animInimigo != null)
        {
            animInimigo.SetBool("walk", false);
            animInimigo.SetBool("attack", false);
            animInimigo.SetBool("deth", true);
        }

        if (monster != null)
        {
            monster.SetActive(false);
        }

        StartCoroutine(Deth());
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        lifeMonster -= Mathf.RoundToInt(damage);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (isDead) return;

        if (collider.CompareTag("attack"))
        {
            TakeDamage(10);
        }
    }

    IEnumerator Ataque()
    {
        isAttacking = true;

        if (agent != null) agent.speed = 0;
        if (monster != null) monster.SetActive(true);
        if (animInimigo != null) animInimigo.SetBool("attack", true);

        yield return new WaitForSeconds(2.8f);

 
        if (!isDead)
        {
            if (animInimigo != null) animInimigo.SetBool("attack", false);
            if (agent != null) agent.speed = speedInimigo;
            if (monster != null) monster.SetActive(false);
        }

        isAttacking = false;
    }

    IEnumerator Deth()
    {
        yield return new WaitForSeconds(4.0f);

        if (corpoMonster != null)
        {
            Destroy(corpoMonster);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}