﻿using System.ComponentModel;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DN.LevelSelect.SceneManagment
{
    /// <summary>
    /// This is the actual scene loader where you load thge selected scene
    /// </summary>
    public class LevelLoader : MonoBehaviour
    {
        [HideInInspector] public bool isInBetweenFinished;

        public GameObject LevelObject => levelObject;
        public LevelData.SelectedPuzzle SelectedPuzzle => selectedPuzzle;
        public LevelData.SelectedAnimal SelectedAnimal => selectedAnimal;
        public bool IsLevelLocked => isLevelLocked;

        private GameObject levelObject;
        private LevelData.SelectedPuzzle selectedPuzzle;
        private LevelData.SelectedAnimal selectedAnimal;
        private bool isLevelLocked;

        private const string LEVEL_SELECT_NAME = "LevelSelect";
        private const string DOG_IBS_NAME = "DogIBS";
        private const string OWL_IBS_NAME = "OwlIBS";

        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        public void LoadInBetweenScene()
        {
            switch (selectedAnimal)
            {
                case LevelData.SelectedAnimal.Dog:
                    SceneManager.LoadScene(DOG_IBS_NAME, LoadSceneMode.Single);
                    break;

                case LevelData.SelectedAnimal.Owl:
                    SceneManager.LoadScene(OWL_IBS_NAME, LoadSceneMode.Single);
                    break;
            }
        }

        public void LoadPuzzleScene()
        {
            if (levelObject.GetComponent<LevelData>().PuzzleSelected == selectedPuzzle && !isLevelLocked)
            {
                SceneManager.LoadScene(selectedPuzzle.ToString(), LoadSceneMode.Single);
                isInBetweenFinished = false;
            }
            else
            {
                Debug.Log("Error mismatch scenes");
            }
        }

        public void SetLoadingLevelData(GameObject other, LevelData.SelectedPuzzle puzzle, LevelData.SelectedAnimal animal, bool locked)
        {
            levelObject = other;
            selectedPuzzle = puzzle;
            selectedAnimal = animal;
            isLevelLocked = locked;
        }

        public void LoadLevelSelect()
        {
            SceneManager.LoadScene(LEVEL_SELECT_NAME);
        }
    }
}
