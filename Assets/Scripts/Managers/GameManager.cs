using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform[] spawns;
    
    //UI
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject startGameScreen;
    private bool _isPaused;
    private float _spawnRate = 1f;

    private void Awake()
    {
        Time.timeScale = 0f;
        EventBroker.RestartButtonHandler += RestartGame;
        EventBroker.QuitButtonHandler += QuitGame;
        EventBroker.GameOverHandler += GameOver;
        EventBroker.StartButtonHandler += StartGame;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
            Pause();
        }
    }

    private void StartGame()
    {
        Instantiate(player, player.transform.position, Quaternion.identity);
        //Instantiate(enemy, enemy.transform.position, Quaternion.identity);
        
        EventBroker.CallStartEnemyTank();
        
        startGameScreen.SetActive(false);
        Time.timeScale = 1f;
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnRate);
            Vector3 spawnEnemyPos = spawns[RollDiceForSpawnPosition()].position;

            GameObject pooledEnemy = ObjectPooler.Instance.GetPooledEnemy();
            if (pooledEnemy != null)
            {
                pooledEnemy.SetActive(true);
                pooledEnemy.transform.position = spawnEnemyPos;
            }
        }
    }

    private int RollDiceForSpawnPosition()
    {
        return Random.Range(0, 6);
    }

    private void GameOver()
    {
        StopCoroutine(SpawnEnemies());
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
    }

    private void Pause()
    {
        if (_isPaused)
        {
            Time.timeScale = 0f;
            pauseScreen.gameObject.SetActive(true);
        }
        else if(!_isPaused)
        {
            Time.timeScale = 1f;
            pauseScreen.gameObject.SetActive(false);
        }
    }

    private void TogglePause()
    {
        if (_isPaused)
            _isPaused = false;
        else
            _isPaused = true;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("TankBattleScene", LoadSceneMode.Single);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void OnDestroy()
    {
        EventBroker.RestartButtonHandler -= RestartGame;
        EventBroker.QuitButtonHandler -= QuitGame;
        EventBroker.GameOverHandler -= GameOver;
        EventBroker.StartButtonHandler -= StartGame;
    }
}
