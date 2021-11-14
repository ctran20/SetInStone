using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameObject instance;

    [SerializeField] GameObject playerA1;
    [SerializeField] GameObject playerA2;
    [SerializeField] GameObject playerA3;

    int currentStage = 1;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        if(currentStage == 1){
            playerA1.SetActive(true);
        }
        else if (currentStage == 1)
        {
            playerA2.SetActive(true);
        }
        else{
            playerA3.SetActive(true);
        }
    }

    public void inArea2(){
        currentStage = 2;
    }

    public void inArea3()
    {
        currentStage = 3;
    }
}
