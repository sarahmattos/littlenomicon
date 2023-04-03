using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{   
    public Transform bulletSpwanPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed =0.000001f;
    private IEnumerator coroutine;
    void Start()
    {
        
    }
    public void atirando(){
         if(Batalha.Instance.emAtaque){
            var bullet = Instantiate(bulletPrefab, bulletSpwanPoint.position, bulletSpwanPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpwanPoint.forward * bulletSpeed;
            coroutine = WaitAndDo(0.7f);
            StartCoroutine(coroutine);
        }
    }
    // Update is called once per frame
   IEnumerator WaitAndDo(float time)
    {
        yield return new WaitForSeconds(time);
        atirando();
    }
}
