using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameObject instance;

    [SerializeField] GameObject playerA1;
    [SerializeField] GameObject playerA2;
    [SerializeField] GameObject playerA3;

    [SerializeField] GameObject area1;
    [SerializeField] GameObject area2;
    [SerializeField] GameObject area3;
    [SerializeField] GameObject area4;

    [SerializeField] GameObject boss;

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
    void Start()
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

    public void areaTrigger(int box){
        switch(box){
            case 1:
                //leaveArea1
                area2.SetActive(true);
                break;
            case 2:
                //enterArea2
                currentStage = 2;
                area1.SetActive(false);
                break;
            case 3:
                //leaveArea2
                area3.SetActive(true);
                break;
            case 4:
                //enterArea3
                currentStage = 3;
                area2.SetActive(false);
                boss.SetActive(true);
                break;
            case 5:
                //leaveArea3
                area3.SetActive(false);
                area4.SetActive(true);
                break;
            default:
                Debug.Log("Unknow area value: " + box);
                break;
        }
    }
}
