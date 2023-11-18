using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BulletsSpawn : MonoBehaviour, IPointerClickHandler
{
    public GameObject BulletObject;
    public GameObject Player;
    public float BulletSpeed;

    public void OnPointerClick(PointerEventData pointerEventData) 
    {
        BulletSpawn();

    }

    private void BulletSpawn()
    {
        var Bullet = Instantiate(BulletObject, Player.transform.position, Player.transform.rotation);
        Bullet.GetComponent<Rigidbody>().velocity = Player.transform.forward * BulletSpeed;
    }
}
