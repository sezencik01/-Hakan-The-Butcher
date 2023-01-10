using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroling : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float startWaitTime;
    [SerializeField] private Transform moveSpot;
    [SerializeField] private float maxX;
    [SerializeField] private float minX;
    [SerializeField] private float maxZ;
    [SerializeField] private float minZ;
    private float waitTime;

    private void Start()
    {
        waitTime = startWaitTime; // waitTime deðiþkenini componentlerinin içinde deðeriyle oynayabildiðimiz startWaitTime isimli deðiþkenimize eþitliyoruz.
        moveSpot.position = new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ)); // moveSpot pozisyonumuzu yeni bir Vector3 oluþturup içerisine rastgele alanlar oluþturup yukarýda belirlediðimiz maxX, maxZ, minX ve minZ aralarýnda yeni pozisyonlar set ediyoruz. transform.position.y komutunun amacý y ekseninde haraket etmesini istemememizden kaynaklanýyor, bu kod olmasa y üzerinde de haraket edebilir hale gelir ve havaya gidebilir.
    }

    private void Update()
    {
        SetPositionTowardsForPatroling(); // SetPositionTowardsForPatroling adlý metodunu çaðýrýyoruz.
        SetRandomMoveSpot(); // SetRandomMoveSpot adlý metodunu çaðýrýyoruz.
    }

    private void SetPositionTowardsForPatroling()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime); // Þuanki pozisyonumuzu Vector3 ileriye gitme metoduna eþitleyip içerisine þuanki pozisyonumuzu moveSpot pozisyonuna eþitlemeye çalýþýyor (gitmeye çalýþýyor). speed deðiþkenini zaman ile çarpýp daha optimize bir hýza ulaþýyoruz.
    }

    private void SetRandomMoveSpot()
    {
        if (Vector3.Distance(transform.position, moveSpot.position) < 0.2f) // eðer Vector3 uzaklýk metodu ile pozisyonumuz ile moveSpotun pozisyonu arasýnda 0.2f 'ten dah küçük gap (boþluk) ise  
        {
            if (waitTime <= 0) // eðer waitTime deðiþkeni küçük veya eþit 0 ise
            {
                moveSpot.position = new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ)); // moveSpot pozisyonumuzu yeni bir Vector3 oluþturup içerisine rastgele alanlar oluþturup yukarýda belirlediðimiz maxX, maxZ, minX ve minZ aralarýnda yeni pozisyonlar set ediyoruz. transform.position.y komutunun amacý y ekseninde haraket etmesini istemememizden kaynaklanýyor, bu kod olmasa y üzerinde de haraket edebilir hale gelir ve havaya gidebilir.
                waitTime = startWaitTime; // Tekrardan eðer waitTime deðiþkeni 0 dan küçük veya eþit ise startWaitTime a eþitle.
            }
            else
            {
                waitTime -= Time.deltaTime; // Yukarýdaki waitTime sýfýrdan büyük ise bu kod çalýþtýrýlýr burada da waitTime deðiþkenini ikide bir çýkartýp yeni bir zamana eþitliyoruz.
            }
        }
    }
}
