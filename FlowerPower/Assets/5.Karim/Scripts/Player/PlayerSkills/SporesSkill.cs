using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporesSkill : MonoBehaviour
{

    public AnnaPlayerMovement playerMovement;
    private Enemy enemy;
    public GameObject sporesPrefab;
    public GameObject intSpore;
    public GameObject playerLocation;

    public float sporeActiveDuration;
    public float throwForce;
    public float sporeDuration;
    public float distractedDuration;
    public int multiplier;
    int firePointOffset;

    void Start()
    {
        firePointOffset = 1;
        playerMovement = FindObjectOfType<AnnaPlayerMovement>();
    }
<<<<<<< HEAD:FlowerPower/Assets/Karim/Scripts/Player/PlayerSkills/SporesSkill.cs
    private void Update()
    {
        RunFunction();
    }
=======

    private void Update()
    {
        sporeActiveDuration -= Time.deltaTime;


    }

>>>>>>> 7b7854018d2c96d8615443cb8771614bdab10024:FlowerPower/Assets/5.Karim/Scripts/Player/PlayerSkills/SporesSkill.cs
    public void LaunchSpores()
    {
        Physics.IgnoreLayerCollision(10, 11);
        intSpore = Instantiate(sporesPrefab, new Vector3(playerLocation.transform.position.x,
<<<<<<< HEAD:FlowerPower/Assets/Karim/Scripts/Player/PlayerSkills/SporesSkill.cs
                   playerLocation.transform.position.y + offset, playerLocation.transform.position.z),
=======
                   playerLocation.transform.position.y + firePointOffset, playerLocation.transform.position.z),
>>>>>>> 7b7854018d2c96d8615443cb8771614bdab10024:FlowerPower/Assets/5.Karim/Scripts/Player/PlayerSkills/SporesSkill.cs
                                                                                playerMovement.transform.rotation);

        intSpore.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce * multiplier);
    }

    public void DestroySpore()
    {
        Destroy(intSpore, 5);
    }

    public void RunFunction()
    {
<<<<<<< HEAD:FlowerPower/Assets/Karim/Scripts/Player/PlayerSkills/SporesSkill.cs

        if (Input.GetKey(KeyCode.G))
        {
            LaunchSpores();
        }
        if (intSpore != null)
        {
            sporeActiveDuration -= Time.deltaTime;
        }
=======
        LaunchSpores();
        DestroySpore();
        sporeActiveDuration = sporeDuration;

>>>>>>> 7b7854018d2c96d8615443cb8771614bdab10024:FlowerPower/Assets/5.Karim/Scripts/Player/PlayerSkills/SporesSkill.cs
    }
}