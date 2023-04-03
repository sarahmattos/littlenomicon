using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{   
    public Transform bulletSpwanPoint;
    public GameObject bulletPrefab;
    public GameObject ataqueAereoPrefab;
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
    public void atirando2(){
         if(Batalha.Instance.emAtaque){
            GameObject bullet = Instantiate(ataqueAereoPrefab, new Vector3(Random.Range(-380f,-285f),-30f,Random.Range(111f,7.7f)), ataqueAereoPrefab.transform.rotation);
            //bullet.GetComponent<Rigidbody>().velocity = bulletSpwanPoint.forward * bulletSpeed;
            coroutine = WaitAndDo2(2f,bullet);
            StartCoroutine(coroutine);
        }
    }
    // Update is called once per frame
   IEnumerator WaitAndDo(float time)
    {
        yield return new WaitForSeconds(time);
        atirando();
    }
    IEnumerator WaitAndDo2(float time, GameObject area)
    {
        yield return new WaitForSeconds(time);
        GameObject areaDano = area.gameObject.transform.GetChild(0).gameObject;
        areaDano.SetActive(true);
    }
}
