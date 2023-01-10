using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stoppingDistance;
    private Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // target deðiþkenini sahneden OyunObjesinin etiketinin ismini bulup transformuna eþitliyoruz.
        // Kýsaca target adlý deðiþkenimiz artýk Player isimli objemizin pozisyonlarýný barýndýrýyor.
    }
    private void Update()
    {
        ChasePlayer(); // Aþaðýdaki ChasePlayer adlý metodumuzu çaðýrýyoruz.
    }

    private void ChasePlayer()
    {
        if (Vector3.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime); // Þuanki pozisyonumuzu Vector3 Sýnýfýnýn MoveTowards metodunu çaðýrarak kendi pozisyonumuzu target pozisyonuna set etmeye çalýþýyoruz.
            // speed * Time.deltaTime ise hýzýmýzý zaman ile çarpýp daha optimum bir hýza ulaþmamýzý saðlýyor.
        }
    }
}
