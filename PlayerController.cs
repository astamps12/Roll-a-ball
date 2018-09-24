using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text loseText;
    public Text scoreText;

    private Rigidbody rb;
    private int count;
    private int score;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        SetAllText ();
        winText.text = "";
       loseText.text = "";
       transform.position = new Vector3();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            SetAllText();
        }

        if (count == 12)
        {
            transform.position = new Vector3(14.59f,0.5f, 0f);
        }


        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            score = score - 1;
            SetAllText();
        }
    }
         
            void SetAllText ()
            {

            countText.text = "Count: " + count.ToString();
               if (count >= 24)
                {
                 winText.text = "You won the game with a score of: " + count.ToString();
                }
                {
                scoreText.text = "Score: " + score.ToString();
                }
            }
        }