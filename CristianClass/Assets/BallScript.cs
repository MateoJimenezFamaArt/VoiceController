using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour
{


    // Serialixed fields to set the different ball properties from the Unity Editor     
    [SerializeField] private Color ballColor;
    [SerializeField] public string ballType;
    [SerializeField] private float ballMass;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AssignVlaues();
        ShootingLogic();}

    void AssignVlaues()
    {
        // Set the ball properties based on the serialized fields
        this.GetComponent<Renderer>().material.color = ballColor;
        this.GetComponent<Rigidbody>().mass = ballMass;
        this.gameObject.name = ballType;
    }

    void ShootingLogic()
    {
        // Logic for adding force to the ball when spawned
        this.GetComponent<Rigidbody>().AddForce(Vector3.forward * 500); //Which direction should the vector take as orientation?
    }
}
