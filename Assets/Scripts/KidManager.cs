using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidManager : ActivityManager
{
    public Animator anim;
    public float speed;
    public GameObject camera;
    public GameObject cube;
    public GameObject ground1;
    public GameObject ground2;
    public GameObject wave1;
    public GameObject wave2;
    public float disKidGround = 67.5F;
    public float disKidwave = 700F;
    private float score;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    protected override void UpdateBehaviour(bool state)
    {
        anim.SetBool("isPushing", state);

        if (anim.GetBool("isPushing"))
        {
            score += Time.deltaTime;
            transform.position += transform.forward * Time.deltaTime * speed;
            camera.transform.position += transform.forward * Time.deltaTime * speed;
            cube.transform.position += transform.forward * Time.deltaTime * speed;

            if (transform.position.z >= ground1.transform.position.z + disKidGround)
            {
                ground1.transform.position = new Vector3(ground1.transform.position.x, ground1.transform.position.y, ground1.transform.position.z + disKidGround*2);
            }
            if (transform.position.z >= ground2.transform.position.z + disKidGround)
            {
                ground2.transform.position = new Vector3(ground2.transform.position.x, ground2.transform.position.y, ground2.transform.position.z + disKidGround*2);
            }
            if (transform.position.z >= wave1.transform.position.z)
            {
                wave1.transform.position = new Vector3(wave1.transform.position.x, wave1.transform.position.y, wave1.transform.position.z + disKidwave);
            }
            if (transform.position.z >= wave2.transform.position.z)
            {
                wave2.transform.position = new Vector3(wave2.transform.position.x, wave2.transform.position.y, wave2.transform.position.z + disKidwave);
            }
        }
     
    }

    public float getScore()
    {
        float minutes = Mathf.FloorToInt(score / 60);
        float seconds = Mathf.FloorToInt(score % 60);
        return (seconds+minutes*60);
    }
}
