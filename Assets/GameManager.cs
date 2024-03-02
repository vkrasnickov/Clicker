using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{[SerializeField] private int score;
[SerializeField] private int clickGain = 1;
[SerializeField] private int autoClickGain = 0;
[SerializeField] private int upgradeAutoClickCost = 100;
[SerializeField] private Text scoreText;
[SerializeField] private int upgradeClickCost = 50;
[SerializeField] private Text upgradeClickCostText;
[SerializeField] private Text upgradeAutoClickCostText;
[SerializeField] private float timer;
    public Text timerText;
    // Start is called before the first frame update
   public void Start()
    {
        StartCoroutine(AutoClickCoroutine());
     timer = 30;
    }

    // Update is called once per frame
    IEnumerator AutoClickCoroutine()
    {
        while(true)
        {
            score += autoClickGain;
            yield return new WaitForSeconds(1);
        }
    }
  private  void Update()
    {
        scoreText.text = score.ToString();
        upgradeClickCostText.text = upgradeClickCost.ToString();
        upgradeAutoClickCostText.text = upgradeAutoClickCost.ToString();
        if(timer<0&&score<130)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        else if(timer>0)
        {
         timer -= Time.deltaTime;
            timerText.text = "Время: "+Mathf.Round(timer);
        }
        if(score>130)
        {
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);
        }
    }
    public void Click()
    {
        score += clickGain;
    }
    public void UpgradeClick()
    {
        if(score>upgradeClickCost)
        {
            score -= upgradeClickCost;
            upgradeClickCost += 50;
            clickGain ++;
        }
        else
        {
            Debug.Log("Not Enough Clicks");
        }
    }
    public void UpgradeAutoClick()
    {
        if(score>=upgradeAutoClickCost)
        {
            score -= upgradeAutoClickCost;
            upgradeAutoClickCost += 100;
            autoClickGain ++;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Clicker");
    }
     public void ExitGame()
  {
    Debug.Log("Игра окончена");
    Application.Quit();
  }
}
