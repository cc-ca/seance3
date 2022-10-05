using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sript : MonoBehaviour
{        
    
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform cameraTransform;
    private float timeleft;

//private void Start(){

  //  StartCoroutine(SpawnBalles()); //methode pour appeler la routine
//}

    // Start is called before the first frame update
   private void SpawnBalle()
    {


        GameObject balle = Instantiate(prefab,cameraTransform.position, Quaternion.identity);

        //on recupère son rigide body
        Rigidbody balleRigidbody = balle.GetComponent<Rigidbody>();

        //on applique une impulsion
        balleRigidbody.AddForce(cameraTransform.forward * 1000); //*la puissance
        
    }

    private IEnumerator SpawnBalles(){

        while(true){
        //faire spawn une balle toutes les secondes
            SpawnBalle();
            yield return new WaitForSeconds(1f); //attendre 2 sec

            }

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetButtonDown("Fire1")){
            timeleft -= Time.deltaTime;
            if (timeleft<0){
            SpawnBalle();
            timeleft= 1 ;
            }
        }
        else {
            timeleft= 0 ;
            
        }
        cameraTransform.position += new Vector3(Input.GetAxis("Horizontal")*Time.deltaTime *30f,0f,0f);
        cameraTransform.position += new Vector3(0f,0f,Input.GetAxis("Vertical")*Time.deltaTime *30f);

        //Random.Range(0,2) rand entre 0 et 2
    }
}
