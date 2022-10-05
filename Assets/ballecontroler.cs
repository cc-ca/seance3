using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballecontroler : MonoBehaviour
{
     private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.layer == LayerMask.NameToLayer("cible")){
            
            Debug.Log("Collision Balle !");
            Destroy(collision.gameObject);
        }
         if (collision.gameObject.name == "balle(Clone)"){
            
            Debug.Log("Collision Balle !");
            Destroy(collision.gameObject);
        } 

    }

}