
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.VisualScripting;



public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    /*[SerializeField]*/ private Transform blankTransform;
    private Vector3 blankCorrectPositionLocal;
    /*[SerializeField]*/ public List<GameObject> allPieces;
    private List<GameObject> gamePieces;
    [SerializeField] private TMPro.TextMeshProUGUI Counter;
    [SerializeField] private GameObject WinPanel;

    private int CurrentLevel;
    private int moveCount = 0;

    private UnityEngine.Camera mCamera;
    private Dictionary<Transform, Vector2> correctPositionsLocal = new Dictionary<Transform, Vector2>();
    

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
        //
        allPieces = new List<GameObject>();
        gamePieces = new List<GameObject>();
        mCamera = UnityEngine.Camera.main;
    }

    
    private void Start()
    {
        
    }
    IEnumerator LateStart()
    {
        yield return null;
        Inýt();
    }

    public void Inýt()
    {
        Debug.Log("initçalýþtý");
        correctPositionsLocal.Clear();
        gamePieces.Clear();

        foreach (GameObject piece in allPieces)
        {
            //allPieces.first?

            if (!piece.CompareTag("Blank"))
            {
                gamePieces.Add(piece);
                correctPositionsLocal[piece.transform] = piece.transform.localPosition;
                Debug.Log("Doðru pozisyon " + piece.name + " =" + piece.transform.localPosition);
            }
            else
            {
                blankTransform=piece.transform;
                
                
            }

        }

        blankCorrectPositionLocal = blankTransform.localPosition;
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

                if (Vector2.Distance(blankTransform.localPosition, hit.transform.localPosition) < 2.9f)
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
        Vector3 firstPosition = clickedPiece.localPosition;
        Vector3 lastPosition = blankTransform.localPosition;
        float duration = 0.10f;
        float t = 0f;

        while (t < duration)
        {
            clickedPiece.localPosition = Vector3.Lerp(firstPosition, lastPosition, t / duration);
            t += Time.deltaTime;
            yield return null;
        }

        clickedPiece.localPosition = lastPosition;
        blankTransform.localPosition = firstPosition;

        ChangeColor(clickedPiece.gameObject);
        CheckWin();

        moveCount++;
        Counter.text=moveCount.ToString();
    }

    public bool IsInCorrectPosition(Transform piece)
    {
        return correctPositionsLocal.TryGetValue(piece, out Vector2 correctPos) &&
               Vector2.Distance(piece.localPosition, correctPos) < 0.02f;

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
        foreach (GameObject piece in gamePieces)
        {
            ChangeColor(piece);
        }
    }

    public void Shuffle()
     {
        Debug.Log(blankCorrectPositionLocal.ToString()+"blank local pozisyon");
        blankTransform.localPosition = blankCorrectPositionLocal;
        List<int> list = new List<int>();
        int random;

        while (list.Count!=correctPositionsLocal.Count)
        {
            random=Random.Range(0, correctPositionsLocal.Count);
            if (!list.Contains(random))
                list.Add(random);
        }

        int a = 0;
        foreach (GameObject piece in gamePieces)
        {

            piece.transform.localPosition = correctPositionsLocal.ElementAt(list[a]).Value;
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
        foreach (GameObject piece in gamePieces)
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
        if (checkedCount==gamePieces.Count)
        {

            WinPanel.SetActive(true);
        }
    }
}

