using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thornsBehav : MonoBehaviour
{
    private bool inthorns = false;
    private int damage = 1;
    private Coroutine todamageCoroutine;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "thorns")
        {
            inthorns= true;
            todamageCoroutine = StartCoroutine(ToDamage());
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("stop");
        inthorns = false;
        if (other.gameObject.tag == "thorns")
        {
            Debug.Log("stop");
            StopCoroutine("ToDamage");
        }
       
    }
    private IEnumerator ToDamage()
    {
        while (inthorns)
        {
            GameObject hero = GameObject.FindGameObjectWithTag("Player");
            hero.SendMessage("ApplyDamage1", damage);
            yield return new WaitForSeconds(2f);
            yield return new WaitForFixedUpdate();
        }
    }
}
