using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerScript : MonoBehaviour
{
    public Text winText;
    public Text CountText;
    private int count;
    public float speed;
    private Rigidbody rb; //this creates a variable to hold the reference

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
       // winText.text = "";
       winText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.AddForce (movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            setCountText();
        }
    }
    void setCountText()
    {
        CountText.text = "Count: " + count.ToString();
        if(count >= 14)
        {
            //winText.text = "You Win!";
            winText.gameObject.SetActive (true);
        }
    }
}
