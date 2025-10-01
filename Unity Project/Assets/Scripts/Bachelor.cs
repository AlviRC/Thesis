using UnityEngine;

public class Bachelor : MonoBehaviour
{
    public GameObject Game;
    private void OnTriggerEnter(Collider other)
    {
        ItemCollector thesis = Game.GetComponent<ItemCollector>();
        thesis.GiveDegree();
    }
}
