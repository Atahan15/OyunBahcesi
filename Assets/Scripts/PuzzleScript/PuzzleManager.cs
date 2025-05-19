using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine;



public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    [SerializeField] private Transform blankTransform;
    private Vector3 blankCorrectPosition;
    [SerializeField] private GameObject[] pieces;
    [SerializeField] private TMPro.TextMeshProUGUI Counter;
    [SerializeField] private GameObject WinPanel;

    public int moveCount = 0;

    private UnityEngine.Camera mCamera;
    private Dictionary<Transform, Vector2> correctPositions = new Dictionary<Transform, Vector2>();


    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
        //

        mCamera = UnityEngine.Camera.main;
    }

    private void Start()
    {
        Init();

    }

    private void Init()
    {
        foreach (GameObject piece in pieces)
        {
            correctPositions[piece.transform] = piece.transform.position;

        }

        blankCorrectPosition = blankTransform.position;
        Shuffle();
        moveCount = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsMouseOverUI())
        {
            Ray ray = mCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {

                if (Vector2.Distance(blankTransform.position, hit.transform.position) <= 3)
                {
                    StartCoroutine(Swap(hit.transform));
                    //ChangeColor(hit.collider.gameObject); IsInCorrectPosition returns before swap because of 1 frame wait
                }
            }
        }

    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private IEnumerator Swap(Transform clickedPiece)
    {
        Vector2 firstPosition = clickedPiece.position;
        Vector2 lastPosition = blankTransform.position;
        float duration = 0.10f;
        float t = 0f;

        while (t < duration)
        {
            clickedPiece.position = Vector2.Lerp(firstPosition, lastPosition, t / duration);
            t += Time.deltaTime;
            yield return null;
        }

        clickedPiece.position = lastPosition;
        blankTransform.position = firstPosition;

        ChangeColor(clickedPiece.gameObject);
        CheckWin();

        moveCount++;
        Counter.text = moveCount.ToString();
    }

    public bool IsInCorrectPosition(Transform piece)
    {
        return correctPositions.TryGetValue(piece, out Vector2 correctPos) &&
               Vector2.Distance(piece.position, correctPos) < 0.01f;

    }

    public void ChangeColor(GameObject piece)
    {
        if (IsInCorrectPosition(piece.transform))
        {
            piece.GetComponent<SpriteRenderer>().color = new Color(0.7f, 1f, 0.7f, 1f); //optimize with dictionary?
            return;
        }
        piece.GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void ChangeAllColor()
    {
        foreach (GameObject piece in pieces)
        {
            ChangeColor(piece);
        }
    }

    public void Shuffle()
    {



        blankTransform.position = blankCorrectPosition;
        List<int> list = new List<int>();
        int random;

        while (list.Count != pieces.Length)
        {
            random = Random.Range(0, pieces.Length);
            if (!list.Contains(random))
                list.Add(random);
        }

        int a = 0;
        foreach (GameObject piece in pieces)
        {

            piece.transform.position = correctPositions.ElementAt(list[a]).Value;
            a++;

        }
        ChangeAllColor();
        moveCount = 0;
        Counter.text = moveCount.ToString();



    }

    //fix
    private void CheckWin()
    {
        int checkedCount = 0;
        foreach (GameObject piece in pieces)
        {
            if (piece.GetComponent<SpriteRenderer>().color == new Color(0.7f, 1f, 0.7f, 1f))
            {
                checkedCount++;
            }
            else
            {
                checkedCount = 0;
            }
        }
        if (checkedCount == pieces.Length)
        {

            WinPanel.SetActive(true);
        }
    }
}

