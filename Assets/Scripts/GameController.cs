using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public enum GameStates
    {
        GamePlaying,
        GameWon,
        GameLost
    };
    
    private GameView gameView;
    private GameStates gameState;
    private int maxCollectiblesCount;
    private GameObject[] inventory;
    
    // SCREEN EFFECTS MANAGER PACKAGE
    private ScreenEffectsManager effects;
    public float duration = .5f; 
    public float magnitude = 1; 
    public Color flashColor;

    private void Start()
    {
        gameView = GetComponentInChildren<GameView>();
        gameState = GameStates.GamePlaying;
        
        effects = FindObjectOfType<ScreenEffectsManager>(); 
        
        // find the NUMBER of objects with "PICK UP" tag
        // maxCollectiblesCount = GameObject.FindGameObjectsWithTag("Collectable").Length;
        
        // RESIZE your list to match maxCollectiblesCount
        // Array.Resize(ref inventory, maxCollectiblesCount);
    }
    
    private void OnGameWon()
    {
        gameState = GameStates.GameWon;
        
        // SET the text value of our result text
        gameView.resultText.text = "You Win!";
        
        // HIDE count and timer text
        gameView.countText.gameObject.SetActive(false);
        gameView.timerText.gameObject.SetActive(false);
        
        // play win sfx
        AudioManager.Instance.PlayWinSFX();
        
        // enable main menu button
        gameView.mainMenuButton.SetActive(true);
        
    }

    private void OnGameLost()
    {
        gameState = GameStates.GameLost;
        
        // SET the text value of our result text
        gameView.resultText.text = "You Lose.";
        
        // HIDE count and timer text
        gameView.countText.gameObject.SetActive(false);
        gameView.timerText.gameObject.SetActive(false);
        
        // play "Lose" SFX
        AudioManager.Instance.PlayLoseSFX();
        
        // enable main menu button
        gameView.mainMenuButton.SetActive(true);
    }

    public void StateUpdate(GameStates newState)
    {
        // EXIT CONDITION
        // if the game is not in play, we cannot advance to win or lose
        if (gameState != GameStates.GamePlaying)
        {
            return;
        }
        
        switch (newState)
        {
            case GameStates.GamePlaying:
                break;
            case GameStates.GameWon:
                gameState = GameStates.GameWon;
                OnGameWon();
                break;
            case GameStates.GameLost:
                gameState = GameStates.GameLost;
                OnGameLost();
                break;
        }
    }

    /* public void OnPickUpCollectible(int playerCollectibleCount)
    {
        // PLAY "collect" SFX
        AudioManager.Instance.PlayCollectSFX();

        // set the UI text counter
        // gameView.SetCountText(playerCollectibleCount);

        // Check if our 'count' is equal to or exceeded our maxCollectibles count
        if (playerCollectibleCount >= maxCollectiblesCount)
        {
            StateUpdate(GameStates.GameWon);
        }
    } */

    public void UpdateGameTimer(int timerCount)
    {
        gameView.SetTimerText(timerCount);
    }
}
