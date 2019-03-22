using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [Header("Figure Params")]
    [SerializeField]
    private GameObject spherePrefab;
    [SerializeField]
    private float sphereSpeed;
    [SerializeField]
    private int numberOfSpheres;

    [SerializeField]
    private GameObject cubePrefab;
    [SerializeField]
    private float cubeSpeed;
    [SerializeField]
    private int numberOfCubes;

    private List<FigureController> spawnedFigures;

    [Header("Position Constraints")]
    [SerializeField]
    private float xConstraint;
    [SerializeField]
    private float yConstraint;
    [SerializeField]
    private float zConstraint;

    [Header("Movement direction params")]
    [SerializeField]
    private int numberOfFiguresMovingUp;
    [SerializeField]
    private int numberOfFiguresMovingDown;
    [SerializeField]
    private int numberOfFiguresMovingRight;
    [SerializeField]
    private int numberOfFiguresMovingLeft;

    private void Awake()
    {
        HideOnButtonInputWrapper hideOnButtonInputwrapper = new HideOnButtonInputWrapper();
        NeverHideInputWrapper neverHideInputWrapper = new NeverHideInputWrapper(); 

        spawnedFigures = new List<FigureController>();
        spawnedFigures.AddRange(SpawnFigures(cubePrefab, numberOfCubes, cubeSpeed, hideOnButtonInputwrapper));
        spawnedFigures.AddRange(SpawnFigures(spherePrefab, numberOfSpheres, sphereSpeed, neverHideInputWrapper));
        List<IDirectionGetter> directionGetters = CreateDirectionGetters();
        RandomizeList(directionGetters);
        AssignDirectionGettersToFigures(spawnedFigures, directionGetters);

    }

    private List<FigureController> SpawnFigures(GameObject figurePrefab, int figureNumber, float speed, IHideInputWrapper hideInputWrapper)
    {
        List<FigureController> figures = new List<FigureController>();

        for (int i = 0; i < figureNumber; i++)
        {
            GameObject spawnedFigureObject = Instantiate(figurePrefab);
            FigureController figureController = spawnedFigureObject.GetComponent<FigureController>();
            figures.Add(figureController);
            figureController.Initialize(speed, hideInputWrapper);
            spawnedFigureObject.transform.position = GetRandomPositionWithinConstraints();
        }

        return figures;
    }

    private Vector3 GetRandomPositionWithinConstraints()
    {
        float randomX = Random.Range(-xConstraint, xConstraint);
        float randomY = Random.Range(-yConstraint, yConstraint);
        float randomZ = Random.Range(-zConstraint, zConstraint);

        return new Vector3(randomX, randomY, randomZ);
    }

    private void RandomizeList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    private List<IDirectionGetter> CreateDirectionGetters()
    {
        List<IDirectionGetter> directionGetters = new List<IDirectionGetter>();

        for (int i = 0; i < numberOfFiguresMovingUp; i++)
        {
            directionGetters.Add(new UpDirectionGetter());
        }

        for (int i = 0; i < numberOfFiguresMovingDown; i++)
        {
            directionGetters.Add(new DownDirectionGetter());
        }

        for (int i = 0; i < numberOfFiguresMovingRight; i++)
        {
            directionGetters.Add(new RightDirectionGetter());
        }

        for (int i = 0; i < numberOfFiguresMovingLeft; i++)
        {
            directionGetters.Add(new LeftDirectionGetter());
        }

        return directionGetters;
    }

    private void AssignDirectionGettersToFigures(List<FigureController> figures, List<IDirectionGetter> directionGetters)
    {
        for (int i = 0; i < figures.Count; i++)
        {
            if (i < directionGetters.Count)
            {
                figures[i].SetDirectionGetter(directionGetters[i]);
            }
            else
                return;
        }
    }
}
