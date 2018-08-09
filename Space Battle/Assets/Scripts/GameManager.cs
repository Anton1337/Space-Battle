using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour {

    private int _diffIncreaseVal = 100;
    private int _diffIncreaseHeight = 100;

    public GameObject diffIncreaseText;

    public EnemyShip _ship;
    public EnemyUfo _ufo;

    public Player player;

    public static int diamondCount;

    void Start () {
        _ship._health = 5;
        ZPlayerPrefs.Initialize("agoodpassword", "whatisthislol");
        diamondCount = ZPlayerPrefs.GetInt("Diamonds", 0);
        diffIncreaseText.SetActive(false);
	}
	
	void Update ()
    {
        if( ScoreText.scoreValue >= _diffIncreaseVal)
        {
            IncreaseDifficulty();
            _diffIncreaseVal += _diffIncreaseHeight;
        }

        if(Advertisement.isShowing)
        {
            Time.timeScale = 0;
        }
        else
        {
            if(player.health > 0)
            {
                Time.timeScale = 1;
            }
        }
	}

    private void IncreaseDifficulty()
    {
        Debug.Log("Increase Difficulty!");
        StartCoroutine(DiffTextAnimation());

        int choice = Random.Range(0, 3);

        if(choice == 0)
        {
            _ufo._health++;
            _ship._health++;
            Debug.Log("health diff increase");
        }
        else if(choice == 1)
        {
            _ship._speed += 1f;
            Debug.Log("speed diff increase");
        }
        else if(choice == 2)
        {
            _ship._shotTimerMin -= 0.05f;
            _ship._shotTimerMax -= 0.05f;
            Debug.Log("shot speed diff increase");
        }
    }

    public static void AddDiamonds(int amount)
    {
        amount = Mathf.Abs(amount);
        diamondCount += amount;
        ZPlayerPrefs.SetInt("Diamonds", diamondCount);
    }

    public static void RemoveDiamonds(int amount)
    {
        if(diamondCount >= amount)
        {
            diamondCount -= amount;
            ZPlayerPrefs.SetInt("Diamonds", diamondCount);
        }
        else
        {
            Debug.Log("Not enough diamonds br0");
        }

    }

    IEnumerator DiffTextAnimation()
    {
        diffIncreaseText.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        diffIncreaseText.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        diffIncreaseText.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        diffIncreaseText.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        diffIncreaseText.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        diffIncreaseText.SetActive(false);
    }

    public void LoadSceneWithAdChance(string sceneName)
    {
        int adChance = Random.Range(0, 3);
        Debug.Log(adChance);

        SceneManager.LoadScene(sceneName);

        if (Advertisement.IsReady("rewardedVideo") && adChance == 0)
        {
            Advertisement.Show("rewardedVideo");
            Debug.Log("Playing ad!");
        }

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
