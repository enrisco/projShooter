using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    bool isEnemy;
    int timeToUp;
    int timeToShoot;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        isEnemy = Random.Range(0, 2) == 1 ? true : false;
        timeToUp = Random.Range(3, 6);
        timeToShoot = Random.Range(5, 11);

        animator = GetComponent<Animator>();
        animator.speed = 0;
        StartCoroutine(WaitTimeToUp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator WaitTimeToUp()
    {
        yield return new WaitForSeconds(timeToUp);
        if (isEnemy)
        {
            animator.speed = 1;
            StartCoroutine(WaitToShoot());
        }
        else Destroy(gameObject);
    }

    IEnumerator WaitToShoot()
    {
        animator.Play("down");
        yield return new WaitForSeconds(timeToShoot);
        animator.Play("enemyShoot");
        yield return new WaitForSeconds(0.3f);
        animator.Play("up");
        yield return new WaitForSeconds(0.9f);
        animator.speed = 0;
        StartCoroutine(WaitTimeToUp());
    }
}
