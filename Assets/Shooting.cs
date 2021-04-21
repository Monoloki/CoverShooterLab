using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject fireball;
    public GameObject monsterHead;
    public Camera fpsCamera;
    private CharacterController _characterController; 
    private float _fireballSpeed = 10f;

    private void Awake()                                           
    {                                                              
        _characterController = GetComponent<CharacterController>();
    }                                                              

    private void Update()
    {
        CreateFireBall();
    }

    private void CreateFireBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(fireball, monsterHead.transform.position, fpsCamera.transform.rotation);
        }
    }
}
