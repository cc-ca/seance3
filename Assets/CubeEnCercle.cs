using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnCercle : MonoBehaviour
{
    public GameObject monCube;
    private int TamponNbCube;
    private float TamponRayCube;
    private Vector3 TamponPosiCentre = new Vector3();
    List<GameObject> IteCube = new List<GameObject>(); //important
    [SerializeField] private int nbCube;
    [SerializeField] private float rayon;
    [SerializeField] private Vector3 position = new Vector3();

    void CubeInstance()
    {
        TamponPosiCentre = position;
        TamponRayCube = rayon;
        TamponNbCube = nbCube;
        for(int i = 0; i < nbCube; i++)
            {
                float angle = i * Mathf.PI * 2 / nbCube;
                float x = Mathf.Cos(angle) * rayon;
                float z = Mathf.Sin(angle) * rayon;
                float degAngle = -angle * Mathf.Rad2Deg;
                Vector3 positionCube = transform.position + new Vector3(0, 0, 0);
                Quaternion rotationCube = Quaternion.Euler(0, degAngle, 0);
                var repCube = Instantiate(monCube, positionCube + position, rotationCube);
                IteCube.Add(repCube);

            }
    }

    // Start is called before the first frame update
    void Start()
    {

        CubeInstance();

    }

    // Update is called once per frame
    void Update()
    {
       if(TamponNbCube != nbCube || TamponRayCube != rayon || TamponPosiCentre != position)
       {
        foreach (var obj in IteCube)
        {
            Destroy(obj);
        }
         CubeInstance();
       }

    }


}