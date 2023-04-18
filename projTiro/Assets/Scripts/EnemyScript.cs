using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public bool isEnemy;
    int timeToUp;
    int timeToShoot;

    Animator animator;

    public ShootingController player;
    public GameObject camera;
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
        Vector3 direction = (camera.transform.position - transform.position).normalized;
        Quaternion spin = Quaternion.LookRotation(direction);
        spin.x = 0;
        spin.z = 0;
        transform.rotation = spin;
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
        animator.Play("up");
        yield return new WaitForSeconds(0.9f);
        animator.speed = 0;
        yield return new WaitForSeconds(timeToShoot);
        animator.Play("enemyShoot");
        animator.speed = 1;
        player.OnShooted();
        yield return new WaitForSeconds(0.4f);
        animator.Play("down");
        yield return new WaitForSeconds(0.9f);
        animator.speed = 0;
        StartCoroutine(WaitTimeToUp());
    }

    public void Die()
    {
        StartCoroutine(WaitToDie());
    }

    IEnumerator WaitToDie()
    {
        animator.Play("explosion");
        animator.speed = 1;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
