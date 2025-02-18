using UnityEngine;
using TMPro;
using System.Collections; // Required for coroutines

public class GameManager : MonoBehaviour
{
    [SerializeField] private BallController ball;
    [SerializeField] private Transform pinAnchor;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject pinCollection;
    private GameObject pinObjects;


    private Vector3[] initialPinPositions;
    private Quaternion[] initialPinRotations;
    private FallTrigger[] fallTriggers;
    private float score = 0;
    

    private void Start()
    {

        inputManager.OnResetPressed.AddListener(HandleReset);

        HandleReset();
    }



    private void HandleReset()
    {
       

        ball.ResetBall();
        ResetPins();
        

    }


    private void ResetPins()
    {
        if (pinObjects)
        {
            foreach (Transform child in pinObjects.transform)
            {
                Destroy(child.gameObject);
            }

            Destroy(pinObjects);
        }
        pinObjects = Instantiate(pinCollection,
 pinAnchor.transform.position,
 Quaternion.identity, transform);

        fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include,
        FindObjectsSortMode.None);
        foreach (FallTrigger pin in fallTriggers)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }

    }

 

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
        Debug.Log($"Score updated: {score}");
    }
}
