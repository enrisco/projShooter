using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingController : MonoBehaviour
{
    public int life = 100;
    public int kills = 0;

    [SerializeField] Text textLife;
    [SerializeField] Text textKills;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();     
    }

    public void OnShooted()
    {
        life--;
        textLife.text = "Vida: " + life;
    }

    private void Shoot()
    {
        animator.Play("shoot");

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            var obj = hit.transform.gameObject;
            if (obj.CompareTag("Soldier"))
            {
                var e = obj.GetComponent<EnemyScript>();
                if (e.isEnemy)
                {
                    kills++;
                    textKills.text = $"Mortes: {kills}";
                }
                e.Die();
                //Instantiate(Smoke, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Shoot();
    }
}
