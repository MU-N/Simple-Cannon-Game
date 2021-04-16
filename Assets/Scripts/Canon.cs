using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Canon : MonoBehaviour
{
    //[SerializeReference] Transform StratPoston;
    [SerializeReference] GameObject canonHand;
    [SerializeReference] GameObject canonGrond;
    [SerializeReference] GameObject bullet;
    [SerializeReference] Transform throwLocation;
    [SerializeReference] float RSpeed;
    float inputX, inputY;
    float BRSpeed;


    [SerializeField] UnityEvent line;
    [SerializeField] UnityEvent destroy;


    float horizRotate;
    float vertRotate;
    // Start is called before the first frame update
    void Start()
    {
        //canonGrond.transform.position = StratPoston.position;
        Cursor.lockState = CursorLockMode.Locked;
        BRSpeed = RSpeed / 2;
    }
    private void Update()
    {


        horizRotate += Input.GetAxis("Mouse X") * RSpeed * Time.deltaTime;
        horizRotate = Mathf.Clamp(horizRotate, -90, 90);

        vertRotate += Input.GetAxis("Mouse Y") * RSpeed * Time.deltaTime;
        vertRotate = Mathf.Clamp(vertRotate, -45, 0);
        canonGrond.transform.rotation = Quaternion.Euler(0, horizRotate, 0);
        canonHand.transform.rotation = Quaternion.Euler(vertRotate, horizRotate, 0);

        if (Input.GetButtonUp("Fire1"))
        {
            FindObjectOfType<AudioManager>().playAudio("cannon");
            var bullt = Instantiate(bullet, throwLocation.position, canonGrond.transform.rotation);
            var rb = bullt.AddComponent<Rigidbody>();
            rb.velocity = throwLocation.transform.forward * BRSpeed;
            Destroy(bullt, 5.0f);
            destroy.Invoke();
            
        }
        if(Input.GetButton("Fire1"))
        {
            line.Invoke();
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.GetComponent<UiManager>().OnLose();
        }
    }
   

}
