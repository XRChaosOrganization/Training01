using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonComponent : MonoBehaviour
{
    public List<GameObject> levelList;
    public Camera mainCamera;
    public List<Transform> cameraRootsList;
    public UIManager uiMan;
    public GameObject levelContainer;
    

    public void InstantiateLevel()
    {
        if (this.gameObject.name == "Level1Button")
        {
            uiMan.isGamePausable = true;
            mainCamera.transform.position = cameraRootsList[0].position;
            levelContainer = GameObject.Find("LevelContainer(Clone)");
            Instantiate(levelList[0],levelContainer.transform);
        } 
        if (this.gameObject.name == "Level2Button")
        {
            uiMan.isGamePausable = true;
            mainCamera.transform.position = cameraRootsList[1].position;
            levelContainer = GameObject.Find("LevelContainer(Clone)");
            Instantiate(levelList[1],levelContainer.transform);
        } 
        if (this.gameObject.name == "Level3Button")
        {
            uiMan.isGamePausable = true;
            mainCamera.transform.position = cameraRootsList[2].position;
            levelContainer = GameObject.Find("LevelContainer(Clone)");
            Instantiate(levelList[2],levelContainer.transform);
        }
    }
    
    public void ResetGame()
    {
        Time.timeScale = 1;
        Destroy(levelContainer);
    }
}
