/*This script handles the collection of the bachelor degree at the secret location after the user has collected or mini-game*/
using UnityEngine;

public class Bachelor : MonoBehaviour
{
    public GameObject Game;
    /*When triggering the degree's collider, the function below calls the function GiveDegree() of the ItemCollector script.*/
    private void OnTriggerEnter(Collider other)
    {
        ItemCollector thesis = Game.GetComponent<ItemCollector>();
        thesis.GiveDegree();
    }
}
